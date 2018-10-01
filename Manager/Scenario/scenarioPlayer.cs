/*
 * Copyright © 2007, Nicolas Destor
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, 
 * are permitted provided that the following conditions are met:
 *
 *    - Redistributions of source code must retain the above copyright notice, 
 *      this list of conditions and the following disclaimer.
 * 
 *    - Redistributions in binary form must reproduce the above copyright notice, 
 *      this list of conditions and the following disclaimer in the documentation 
 *      and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
 * IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
 * OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
 * OF SUCH DAMAGE.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Timers;

using CommonProject.Scenario.Datas;
using CommonProject.Scenario.Datas.Steps;
using CommonProject.Communication;

using CommonProject.Scenario.ResultDatas;
using CommonProject.Scenario.ResultDatas.Steps;

using Manager.Scenario.ResultDatas;


using CommonProject.Tools;

namespace Manager.Scenario
{
    /// <summary>
    /// Classe définissant les status possibles du ScénarioPlayer
    /// </summary>
    public enum ScenarioPlayerSatus
    {
        /// <summary>
        /// Verification du scenario
        /// </summary>
        VerifyScenario,
        /// <summary>
        /// Initialisation des testers
        /// </summary>
        initTesters,
        /// <summary>
        /// Initialisation
        /// </summary>
        sendScenario,
        /// <summary>
        /// Initialisation
        /// </summary>
        loadScenario,
        /// <summary>
        /// En cours de lecture
        /// </summary>
        running,
        /// <summary>
        /// stop
        /// </summary>
        stop,
        /// <summary>
        /// joué
        /// </summary>
        played,
        /// <summary>
        /// Step joué
        /// </summary>
        stepPlayed,
        /// <summary>
        /// En erreur
        /// </summary>
        error,
        /// AllScenarioPlayed
        /// </summary>
        allPlayed
    }

    /// <summary>
    /// Classe Handle
    /// </summary>
    class StepTaskInfo
    {
        public RegisteredWaitHandle Handle = null;
        public String Infos = "default";
    }

    /// <summary>
    /// Classe gérant la lecture d'un scénario avec génération d'un résultat
    /// </summary>
    class scenarioPlayer
    {
        #region Class Datas

        private Boolean isCrashed = false;
        private Boolean isTimeOut = false;
        private String msg = null;
        private String crashMsg = null;
        private ScenarioPlayerSatus status;
        private Int16 playIndex;

        private StepTaskInfo sti;
        private AutoResetEvent wait;

        private Datas.Scenario scenarioToPlay;
        private ScenarioResult scenarioResult;

        public StepResult stepResult;

        private String testerSourceName;
        private String testerDestinationName;
        private GenericTesterResult testerSourceResults;
        private GenericTesterResult testerDestinationResults;

        List<short> listOfActorsID = new List<short>();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur scenarioPlayer
        /// </summary>
        public scenarioPlayer(Int16 _playIndex, Datas.Scenario _scenarioToPlay)
        {
            playIndex = _playIndex;
            scenarioToPlay = new Scenario.Datas.Scenario();
            scenarioToPlay = _scenarioToPlay;
            status = new ScenarioPlayerSatus();
        }

        #endregion

        #region Public functions

        /// <summary>
        /// Méthode qui permet le changement de status du player (voir classe ScenarioPlayerStatus)
        /// </summary>
        public void ChangeStatus(ScenarioPlayerSatus _status)
        {
            status = _status;
            MainEntry._ScenarioEvents.OnPlayerStatusChange(this, null);
        }

        /// <summary>
        /// Méthode de départ pour le lancement de la lecture d'un scénario
        /// </summary>
        public void PlayScenario()
        {
            isCrashed = false;

            this.ChangeStatus(ScenarioPlayerSatus.VerifyScenario);

            //Verification du scenario - Etape 1
            if (ScenarioTools.VerifyScenario(scenarioToPlay).IsCorrect)
            {
                msg = "Scenario Valide";
            }
            else
            {
                isCrashed = true;
                crashMsg = "Scenario non valide";
                this.ChangeStatus(ScenarioPlayerSatus.error);
            }

            //Initialisation des testeurs - Etape 2            
            if (isCrashed == false)
            {
                this.ChangeStatus(ScenarioPlayerSatus.initTesters);
                if (Preliminaries())
                {
                    Trace.WriteInfo("Testeurs prêt");
                }
                else
                {
                    isCrashed = true;
                    crashMsg = "Testeurs non prêt";
                    Trace.WriteInfo(crashMsg);
                    this.ChangeStatus(ScenarioPlayerSatus.error);
                }
            }


            if (!isCrashed)
            {
                //On donne l'ordre de charger le scenario sur chaque tester - Etape 3
                this.ChangeStatus(ScenarioPlayerSatus.sendScenario);
                if (SendAndLoadScenario())
                {
                    Trace.WriteInfo("Envoi et chargement du scenario OK");
                }
                else
                {
                    isCrashed = true;
                    Trace.WriteError("Envoi et chargement du scenario KO");
                }
            }

            //On joue les steps - Etape 4
            this.ChangeStatus(ScenarioPlayerSatus.running);

            if (!isCrashed)
            {
                foreach (GenericStep currentStep in scenarioToPlay.Steps)
                {
                    if (PlayStep(currentStep.NumStep))
                    {
                        Trace.WriteInfo("Lecture du Step " + ((StepsName)currentStep.NameId).ToString() + " OK");
                        //On copie le résultat du step dans scenarioResult
                        scenarioResult.AddStepResults(stepResult);

                        //On indique qu'un step à été joué
                        this.ChangeStatus(ScenarioPlayerSatus.stepPlayed);
                    }
                    else
                    {
                        //erreur fatal
                        Trace.WriteError("Lecture du Step " + ((StepsName)currentStep.NameId).ToString() + " KO");
                        //isCrashed = true;
                        scenarioResult.AddStepResults(stepResult);
                        break;
                    }
                    Thread.Sleep(2000);
                }
            }

            if (!isCrashed)
            {
                //On affiche le scenario dans tout les cas dans l'IHM
                MainEntry._ScenarioEvents.OnNewScenarioResultToView(scenarioResult, null);
                //On enregistre les données si le scenario a été validé
                if (scenarioToPlay.IsValidate)
                {
                    MainEntry.scenarioSolution.Scenarios[scenarioResult.IdScenario].AddResult(scenarioResult);
                }
            }

            //On ferme les threads ouverts par les testeurs
            if (StopScenario())
            {
                Trace.WriteInfo("Player bien terminé");
                //Fin du scenario - Etape 6 
                this.ChangeStatus(ScenarioPlayerSatus.played);
            }
            else
            {
                Trace.WriteInfo("Problème lors de la fermeture du Player pour le scenario");
            }
        }

        /// <summary>
        /// Méthode arrétant la lecture du scénario
        /// </summary>
        public bool StopScenario()
        {
            try
            {
                foreach (Communication.Tester current in MainEntry.listTesters.Tester)
                {
                    Console.WriteLine("Tester Status :" + current.IsConnected);

                    if (current.IsConnected)
                    {
                        current.SendString(TcpDatas.StopScenario());
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Public generic functions

        public ScenarioPlayerSatus Status
        {
            get { return status; }
        }

        public Boolean IsCrashed
        {
            get { return isCrashed; }
        }

        public String Msg
        {
            get { return msg; }
        }

        public String CrashMsg
        {
            get { return crashMsg; }
        }

        public Boolean IsTimeOut
        {
            get { return isTimeOut; }
        }

        public Int16 PlayIndex
        {
            get { return playIndex; }
        }

        public ScenarioResult Result
        {
            get { return scenarioResult; }
        }

        public Int32 TotalSteps
        {
            //5 + nombre de step du scenario
            get { return scenarioToPlay.Steps.Count + 5; }
        }
        #endregion

        #region Private functions

        /// <summary>
        /// Méthode effectuant des préparations avant la lecture du scénario 
        /// </summary>
        private bool Preliminaries()
        {
            try
            {
                //Initialisation

                sti = new StepTaskInfo();

                scenarioResult = new ScenarioResult(scenarioToPlay.Name + "_Results", scenarioToPlay.Id);
                scenarioResult.BeginTime = DateTime.Now;
                listOfActorsID = ScenarioTools.GetActorsOfScenario(scenarioToPlay);

                //Envois du message StardScenario aux testeurs acteur
                foreach (short testerId in listOfActorsID)
                {
                    if (MainEntry.listTesters.Tester[testerId].IsConnected)
                    {
                        MainEntry.listTesters.Tester[testerId].StartScenario();
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Méthode qui envoit et charge le scénario vers les testeurs sources et destinations
        /// </summary>
        private bool SendAndLoadScenario()
        {
            if (!SendScenario())
            {
                return false;
            }
            if (!LoadScenario())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Envois du scénario en format XML vers les testeurs sources et destinations
        /// </summary>
        private bool SendScenario()
        {

            Trace.WriteLine("Parser GenericScenario");
            //On transforme le Scenario en un fichier de données XML
            XmlSerializer s = new XmlSerializer(typeof(GenericScenario));
            MemoryStream ms = new MemoryStream();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(ms, Encoding.Unicode);
            s.Serialize(xmlTextWriter, scenarioToPlay.ToGeneric());
            ms = (MemoryStream)xmlTextWriter.BaseStream;
            System.Text.UnicodeEncoding encoding = new System.Text.UnicodeEncoding();
            String ordersString = encoding.GetString(ms.ToArray());


            //On intialise le thread wait
            wait = new AutoResetEvent(false);

            //On charge le handle
            sti.Handle = ThreadPool.RegisterWaitForSingleObject(wait, new WaitOrTimerCallback(OnTimeOut), sti, 10000, true);

            //Pour chaque acteur du scenario, on envois le fichier d'ordres XML
            foreach (short testerId in listOfActorsID)
            {
                if (MainEntry.listTesters.Tester[testerId].IsConnected)
                {
                    try
                    {
                        Trace.WriteInfo("Envois des fichiers XML aux acteurs");

                        //On s'enregistre à l'évenement correspondant à la réponse à cet ordre
                        MainEntry._TcpEvents.AckReceiveEvent += new AckReceivingHandler(OnReceiveAck);
                        wait = new AutoResetEvent(false);

                        //On envois le scenario                          
                        MainEntry.listTesters.Tester[testerId].SendScenarioDatas(encoding.GetString(ms.ToArray()));


                        //On attend l'acquitement du testeur (Chargement OK, KO, No response)
                        wait.WaitOne();

                        //On désenregistre à l'évenement correspondant à la réponse à cet ordre
                        MainEntry._TcpEvents.AckReceiveEvent -= new AckReceivingHandler(OnReceiveAck);

                        //RESET WAITONE 
                        wait.Reset();

                    }
                    catch
                    {
                        isCrashed = true;
                        crashMsg = "L'envoi du fichier d'ordre au tester " + MainEntry.listTesters.Tester[testerId].Name + " a échoué";
                        Trace.WriteError(crashMsg);
                        break;
                    }

                    if (isTimeOut)
                    {
                        isCrashed = true;
                        crashMsg = "Aucune réponse du testeur " + MainEntry.listTesters.Tester[testerId].Name;
                        break;
                    }
                }

                else
                {
                    isCrashed = true;
                    crashMsg = "Impossible de joindre le testeur nommé " + MainEntry.listTesters.Tester[testerId].Name;
                    Trace.WriteError(crashMsg);
                    break;
                }
            }

            if (sti.Handle != null)
            {
                Trace.WriteDebug("sti.Handle.Unregister(null);");
                sti.Handle.Unregister(null);
                sti.Handle = null;
            }
            if (wait != null)
            {
                wait.Reset();
                wait = null;
            }
            Boolean result = (isCrashed) ? false : true;
            return result;
        }

        /// <summary>
        /// Chargement du scénario par les testeurs sources et destinations
        /// </summary>
        private bool LoadScenario()
        {
            //On intialise le thread wait
            wait = new AutoResetEvent(false);

            //On charge le handle
            sti.Handle = ThreadPool.RegisterWaitForSingleObject(wait, new WaitOrTimerCallback(OnTimeOut), sti, 10000, true);

            //On s'enregistre à l'évenement correspondant à la réponse à cet ordre

            MainEntry._TcpEvents.AckReceiveEvent += new AckReceivingHandler(OnReceiveAck);
            foreach (short testerId in listOfActorsID)
            {
                if (MainEntry.listTesters.Tester[testerId].IsConnected)
                {
                    try
                    {
                        Trace.WriteDebug("ENVOIS LOAD SCENARIO");


                        wait = new AutoResetEvent(false);

                        //On envois l'ordre de chargement du scenario

                        MainEntry.listTesters.Tester[testerId].LoadScenario();

                        //On attend l'acquitement du testeur (Chargement OK, KO, No response)
                        wait.WaitOne();


                        //RESET WAITONE 
                        wait.Reset();

                        //REMETTRE TOUT LES WAIT DE LA FONCTION LOAD SCENARIO EN COMMENTAIRES-
                        // Aucun intêrét d'attendre... sauf si analyse de la réponse ACK (OK ou KO pour le load)

                        if (isTimeOut)
                        {
                            isCrashed = true;
                            crashMsg = "Aucune réponse du testeur " + MainEntry.listTesters.Tester[testerId].Name;
                            break;
                        }
                    }
                    catch
                    {
                        isCrashed = true;
                        break;
                    }
                }
                else
                {
                    isCrashed = true;
                    break;
                }
            }

            //On désenregistre à l'évenement correspondant à la réponse à cet ordre
            MainEntry._TcpEvents.AckReceiveEvent -= new AckReceivingHandler(OnReceiveAck);

            if (sti.Handle != null)
            {
                Trace.WriteDebug("sti.Handle.Unregister(null);");
                sti.Handle.Unregister(null);
                sti.Handle = null;
            }

            if (wait != null)
            {
                Trace.WriteDebug("wait.Reset();");
                wait.Reset();
                wait = null;
            }
            Boolean result = (isCrashed) ? false : true;
            return result;
        }

        /// <summary>
        /// Méthode qui exécute un step sur les testeurs sources et destinations
        /// </summary>
        private bool PlayStep(int num)
        {
            try
            {
                //On initialise les variables de travails
                testerSourceResults = new GenericTesterResult();
                testerDestinationResults = new GenericTesterResult();

                stepResult = new StepResult();

                //On intialise le thread wait
                wait = new AutoResetEvent(false);

                //On déclare un nouveau Step contenant le step num
                GenericStep step = scenarioToPlay.Steps[num];

                //On enregistre les noms des testers source et destination
                testerDestinationName = step.TesterDestination;
                testerSourceName = step.TesterSource;

                //on récupére l'identifiant du testeur source et destionation
                int idTesterSource = MainEntry.listTesters.GetIdFromName(step.TesterSource);
                int idTesterDestination = MainEntry.listTesters.GetIdFromName(step.TesterDestination);

                //On s'enregistre à l'évenement OnReceiveStepResult
                MainEntry._TcpEvents.StepResultReceiveEvent += new CommonProject.Communication.StepResultReceiveHandler(OnReceiveStepResults);

                //On charge un timer qui déclenchera un timeOut au bout d'un temps données
                //sti.Handle = ThreadPool.RegisterWaitForSingleObject(wait, new WaitOrTimerCallback(OnTimeOut), sti, step.TimeOut, true);

                //Envoi de l'ordre d'exécuter le step
                MainEntry.listTesters.Tester[idTesterSource].PlayStep(num);
                MainEntry.listTesters.Tester[idTesterDestination].PlayStep(num);

                //Attente des résultat de ce Step exécutée par les deux testeurs 
                wait.WaitOne();
                wait.Reset();
                wait.WaitOne();
                wait.Reset();

                MainEntry._TcpEvents.StepResultReceiveEvent -= new CommonProject.Communication.StepResultReceiveHandler(OnReceiveStepResults);

                //On instancie StepResult avec les résultat des actions efectué par les testeurs
                stepResult.NumStep = step.NumStep;
                stepResult.NameId = step.NameId;
                stepResult.NameId = step.NameId;
                stepResult.Status = TestStatus.Success;
                List<GenericTesterResult> tempList = new List<GenericTesterResult>(2);
                tempList.Add(testerSourceResults);
                tempList.Add(testerDestinationResults);
                stepResult.TestersResults = tempList.ToArray();

                Trace.WriteLine("Début de l'analyse des résultats");

                foreach (GenericTesterResult current in stepResult.TestersResults)
                {
                    if (current.Status == TestStatus.Failed)
                    {
                        stepResult.Status = TestStatus.Failed;
                        stepResult.Msg = "La lecture du step a échoué";
                    }
                    else if (current.Status == TestStatus.TimeOut)
                    {
                        stepResult.Status = TestStatus.TimeOut;
                        stepResult.Msg = "Un timeOut s'est déclenché";
                    }
                    else
                    {
                        stepResult.Msg = "Step terminé avec succès";
                    }
                }

                //Test de vérification des DTMF reçus et envoyé
                if (stepResult.NameId == (int)StepsName.DTMF && stepResult.Status == TestStatus.Success)
                {

                    if (((GenericDTMFResult)testerSourceResults.Datas).DTMF != ((GenericDTMFResult)testerDestinationResults.Datas).DTMF)
                    {
                        stepResult.Status = TestStatus.Failed;
                        stepResult.Msg = "Le DTMF reçu ne correspond pas au DTMF envoyé";
                    }
                }


                if (stepResult.NameId == (int)StepsName.Appel)
                {
                    Datas.Steps.CallStep callStep = (Datas.Steps.CallStep)step;

                    if (callStep.CallerIdentitie)
                    {
                        if (((GenericCallResult)testerDestinationResults.Datas).CallerName == "Anonymous")
                        {
                            stepResult.Status = TestStatus.Failed;
                            if (callStep.CallMode == CallMode.Normal)
                            {
                                stepResult.Msg = "L'appel en mode \"présentation du numéro\" a échoué";
                            }
                            else
                            {
                                stepResult.Msg = "L'appel n'a pas été reçu en mode OIP";
                            }
                        }
                    }
                    else
                    {
                        if (((GenericCallResult)testerDestinationResults.Datas).CallerName != "Anonymous")
                        {
                            stepResult.Status = TestStatus.Failed;
                            if (callStep.CallMode == CallMode.Normal)
                            {
                                stepResult.Msg = "L'appel a été reçu en mode OIP";
                            }
                            else
                            {
                                stepResult.Msg = "L'appel en mode OIR a échoué";
                            }
                        }
                    }
                }
                return true;
                /*
                //Analyse du résultat pour identifier un échec fatal
                if (stepResult.Status == TestStatus.Failed && stepResult.NameId == (int)StepsName.Appel)
                {   //Echec Fatal                   
                    return false;
                }
                else
                {                                      
                    return true;
                }  */
            }
            catch (Exception e)
            {
                Trace.WriteDebug("Erreur PLAYSTEP KO");
                stepResult.Msg = "Erreur générale - L'appel n'a pas abouti";
                stepResult.Status = TestStatus.Failed;
                //Echec Fatal
                return false;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Méthode exécutée lors de la reception d'un résultat d'un step provenant d'un testeur
        /// </summary>
        private void OnReceiveStepResults(String _testerName, string _datas)
        {
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(GenericTesterResult));
                byte[] buf = System.Text.Encoding.Unicode.GetBytes(_datas);
                MemoryStream ms = new MemoryStream(buf);

                if (_testerName == testerDestinationName)
                {
                    testerDestinationResults = new GenericTesterResult();
                    testerDestinationResults = (GenericTesterResult)s.Deserialize((Stream)ms);
                }
                else
                {
                    testerSourceResults = new GenericTesterResult();
                    testerSourceResults = (GenericTesterResult)s.Deserialize((Stream)ms);
                }

                Trace.WriteInfo("Une donnée ActionResult a été reçus, débloquage du wait");
                wait.Set();
            }
            catch (Exception e)
            {
                Trace.WriteError(_datas);
                Trace.WriteError("Impossible de lire le fichier XML décrivant le résultat du step, format incorect");
                Trace.WriteError(e.ToString());
            }
        }

        /// <summary>
        /// Méthode exécutée lors de la réception d'un acquitement provenant d'un testeur
        /// </summary>
        private void OnReceiveAck(object sender, String datas)
        {

            //On débloque la fonction attendant un ack
            wait.Set();
            Trace.WriteInfo(datas);
        }

        /// <summary>
        /// Méthode exécutée lors du déclenchement d'un TimeOut (aucune réponse d'un testeur)
        /// </summary>
        private void OnTimeOut(Object state, bool timedOut)
        {
            if (timedOut)
            {
                Trace.WriteInfo("TimeOut déclenché");
                isTimeOut = true;
                wait.Set();
            }
        }

        #endregion
    }


}
