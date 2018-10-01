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
    /// Classe d�finissant les status possibles du Sc�narioPlayer
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
        /// jou�
        /// </summary>
        played,
        /// <summary>
        /// Step jou�
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
    /// Classe g�rant la lecture d'un sc�nario avec g�n�ration d'un r�sultat
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
        /// M�thode qui permet le changement de status du player (voir classe ScenarioPlayerStatus)
        /// </summary>
        public void ChangeStatus(ScenarioPlayerSatus _status)
        {
            status = _status;
            MainEntry._ScenarioEvents.OnPlayerStatusChange(this, null);
        }

        /// <summary>
        /// M�thode de d�part pour le lancement de la lecture d'un sc�nario
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
                    Trace.WriteInfo("Testeurs pr�t");
                }
                else
                {
                    isCrashed = true;
                    crashMsg = "Testeurs non pr�t";
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
                        //On copie le r�sultat du step dans scenarioResult
                        scenarioResult.AddStepResults(stepResult);

                        //On indique qu'un step � �t� jou�
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
                //On enregistre les donn�es si le scenario a �t� valid�
                if (scenarioToPlay.IsValidate)
                {
                    MainEntry.scenarioSolution.Scenarios[scenarioResult.IdScenario].AddResult(scenarioResult);
                }
            }

            //On ferme les threads ouverts par les testeurs
            if (StopScenario())
            {
                Trace.WriteInfo("Player bien termin�");
                //Fin du scenario - Etape 6 
                this.ChangeStatus(ScenarioPlayerSatus.played);
            }
            else
            {
                Trace.WriteInfo("Probl�me lors de la fermeture du Player pour le scenario");
            }
        }

        /// <summary>
        /// M�thode arr�tant la lecture du sc�nario
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
        /// M�thode effectuant des pr�parations avant la lecture du sc�nario 
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
        /// M�thode qui envoit et charge le sc�nario vers les testeurs sources et destinations
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
        /// Envois du sc�nario en format XML vers les testeurs sources et destinations
        /// </summary>
        private bool SendScenario()
        {

            Trace.WriteLine("Parser GenericScenario");
            //On transforme le Scenario en un fichier de donn�es XML
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

                        //On s'enregistre � l'�venement correspondant � la r�ponse � cet ordre
                        MainEntry._TcpEvents.AckReceiveEvent += new AckReceivingHandler(OnReceiveAck);
                        wait = new AutoResetEvent(false);

                        //On envois le scenario                          
                        MainEntry.listTesters.Tester[testerId].SendScenarioDatas(encoding.GetString(ms.ToArray()));


                        //On attend l'acquitement du testeur (Chargement OK, KO, No response)
                        wait.WaitOne();

                        //On d�senregistre � l'�venement correspondant � la r�ponse � cet ordre
                        MainEntry._TcpEvents.AckReceiveEvent -= new AckReceivingHandler(OnReceiveAck);

                        //RESET WAITONE 
                        wait.Reset();

                    }
                    catch
                    {
                        isCrashed = true;
                        crashMsg = "L'envoi du fichier d'ordre au tester " + MainEntry.listTesters.Tester[testerId].Name + " a �chou�";
                        Trace.WriteError(crashMsg);
                        break;
                    }

                    if (isTimeOut)
                    {
                        isCrashed = true;
                        crashMsg = "Aucune r�ponse du testeur " + MainEntry.listTesters.Tester[testerId].Name;
                        break;
                    }
                }

                else
                {
                    isCrashed = true;
                    crashMsg = "Impossible de joindre le testeur nomm� " + MainEntry.listTesters.Tester[testerId].Name;
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
        /// Chargement du sc�nario par les testeurs sources et destinations
        /// </summary>
        private bool LoadScenario()
        {
            //On intialise le thread wait
            wait = new AutoResetEvent(false);

            //On charge le handle
            sti.Handle = ThreadPool.RegisterWaitForSingleObject(wait, new WaitOrTimerCallback(OnTimeOut), sti, 10000, true);

            //On s'enregistre � l'�venement correspondant � la r�ponse � cet ordre

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
                        // Aucun int�r�t d'attendre... sauf si analyse de la r�ponse ACK (OK ou KO pour le load)

                        if (isTimeOut)
                        {
                            isCrashed = true;
                            crashMsg = "Aucune r�ponse du testeur " + MainEntry.listTesters.Tester[testerId].Name;
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

            //On d�senregistre � l'�venement correspondant � la r�ponse � cet ordre
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
        /// M�thode qui ex�cute un step sur les testeurs sources et destinations
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

                //On d�clare un nouveau Step contenant le step num
                GenericStep step = scenarioToPlay.Steps[num];

                //On enregistre les noms des testers source et destination
                testerDestinationName = step.TesterDestination;
                testerSourceName = step.TesterSource;

                //on r�cup�re l'identifiant du testeur source et destionation
                int idTesterSource = MainEntry.listTesters.GetIdFromName(step.TesterSource);
                int idTesterDestination = MainEntry.listTesters.GetIdFromName(step.TesterDestination);

                //On s'enregistre � l'�venement OnReceiveStepResult
                MainEntry._TcpEvents.StepResultReceiveEvent += new CommonProject.Communication.StepResultReceiveHandler(OnReceiveStepResults);

                //On charge un timer qui d�clenchera un timeOut au bout d'un temps donn�es
                //sti.Handle = ThreadPool.RegisterWaitForSingleObject(wait, new WaitOrTimerCallback(OnTimeOut), sti, step.TimeOut, true);

                //Envoi de l'ordre d'ex�cuter le step
                MainEntry.listTesters.Tester[idTesterSource].PlayStep(num);
                MainEntry.listTesters.Tester[idTesterDestination].PlayStep(num);

                //Attente des r�sultat de ce Step ex�cut�e par les deux testeurs 
                wait.WaitOne();
                wait.Reset();
                wait.WaitOne();
                wait.Reset();

                MainEntry._TcpEvents.StepResultReceiveEvent -= new CommonProject.Communication.StepResultReceiveHandler(OnReceiveStepResults);

                //On instancie StepResult avec les r�sultat des actions efectu� par les testeurs
                stepResult.NumStep = step.NumStep;
                stepResult.NameId = step.NameId;
                stepResult.NameId = step.NameId;
                stepResult.Status = TestStatus.Success;
                List<GenericTesterResult> tempList = new List<GenericTesterResult>(2);
                tempList.Add(testerSourceResults);
                tempList.Add(testerDestinationResults);
                stepResult.TestersResults = tempList.ToArray();

                Trace.WriteLine("D�but de l'analyse des r�sultats");

                foreach (GenericTesterResult current in stepResult.TestersResults)
                {
                    if (current.Status == TestStatus.Failed)
                    {
                        stepResult.Status = TestStatus.Failed;
                        stepResult.Msg = "La lecture du step a �chou�";
                    }
                    else if (current.Status == TestStatus.TimeOut)
                    {
                        stepResult.Status = TestStatus.TimeOut;
                        stepResult.Msg = "Un timeOut s'est d�clench�";
                    }
                    else
                    {
                        stepResult.Msg = "Step termin� avec succ�s";
                    }
                }

                //Test de v�rification des DTMF re�us et envoy�
                if (stepResult.NameId == (int)StepsName.DTMF && stepResult.Status == TestStatus.Success)
                {

                    if (((GenericDTMFResult)testerSourceResults.Datas).DTMF != ((GenericDTMFResult)testerDestinationResults.Datas).DTMF)
                    {
                        stepResult.Status = TestStatus.Failed;
                        stepResult.Msg = "Le DTMF re�u ne correspond pas au DTMF envoy�";
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
                                stepResult.Msg = "L'appel en mode \"pr�sentation du num�ro\" a �chou�";
                            }
                            else
                            {
                                stepResult.Msg = "L'appel n'a pas �t� re�u en mode OIP";
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
                                stepResult.Msg = "L'appel a �t� re�u en mode OIP";
                            }
                            else
                            {
                                stepResult.Msg = "L'appel en mode OIR a �chou�";
                            }
                        }
                    }
                }
                return true;
                /*
                //Analyse du r�sultat pour identifier un �chec fatal
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
                stepResult.Msg = "Erreur g�n�rale - L'appel n'a pas abouti";
                stepResult.Status = TestStatus.Failed;
                //Echec Fatal
                return false;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// M�thode ex�cut�e lors de la reception d'un r�sultat d'un step provenant d'un testeur
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

                Trace.WriteInfo("Une donn�e ActionResult a �t� re�us, d�bloquage du wait");
                wait.Set();
            }
            catch (Exception e)
            {
                Trace.WriteError(_datas);
                Trace.WriteError("Impossible de lire le fichier XML d�crivant le r�sultat du step, format incorect");
                Trace.WriteError(e.ToString());
            }
        }

        /// <summary>
        /// M�thode ex�cut�e lors de la r�ception d'un acquitement provenant d'un testeur
        /// </summary>
        private void OnReceiveAck(object sender, String datas)
        {

            //On d�bloque la fonction attendant un ack
            wait.Set();
            Trace.WriteInfo(datas);
        }

        /// <summary>
        /// M�thode ex�cut�e lors du d�clenchement d'un TimeOut (aucune r�ponse d'un testeur)
        /// </summary>
        private void OnTimeOut(Object state, bool timedOut)
        {
            if (timedOut)
            {
                Trace.WriteInfo("TimeOut d�clench�");
                isTimeOut = true;
                wait.Set();
            }
        }

        #endregion
    }


}
