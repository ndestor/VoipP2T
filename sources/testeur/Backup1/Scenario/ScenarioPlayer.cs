using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Data;
using System.Timers;

using System.Xml.Serialization;
using System.Xml;
using System.IO;

using CommonProject.Scenario.Datas;
using CommonProject.Tools;
using CommonProject.Scenario.ResultDatas;
using CommonProject.Communication;

using Tester.SipManager.EconfClassPlayer;

namespace Tester.Scenario
{    
    public class ScenarioPlayer
    {

        #region Class Datas

        private Boolean isCrashed;
        private String crashMsg;
        private System.DateTime beginDatetime;
        private GenericScenario scenarioToPlay;

        private static ManualResetEvent wait;

        //Données propre au Scenario
        private String scenarioDatas;
        private GenericStep stepToPlay;
        private int IdOfPlayingStep;

        //Thread de lecture du scneario
        Thread threadStepPlayer = null;

        #endregion

        #region Constructor
        public ScenarioPlayer()
        {
            Trace.WriteDebug("Init ScenarioPlayer");
            //Initialisation           
            isCrashed = false;
            crashMsg = String.Empty;
            beginDatetime = DateTime.MinValue;
            scenarioToPlay = new GenericScenario();
            scenarioDatas = String.Empty;
            
            if (threadStepPlayer == null && !(isCrashed))
            {
                threadStepPlayer = new Thread(new ThreadStart(PlayScenario));
                threadStepPlayer.Start();
            }
            //PlayScenario();
        }
        #endregion

        #region Public functions

        public void PlayScenario()
        {
            wait = new ManualResetEvent(false);

            //On s'enregistre à lévénement reception d'un fichier scenario
            MainEntry._serverEvent.ScenarioReceiveEvent += new ScenarioReceiveHandler(OnReceiveScenario);

            Trace.WriteDebug("Attente");
            //On attend ....
            wait.WaitOne();

            //On se désenregistre à lévénement reception d'un fichier scenario
            MainEntry._serverEvent.ScenarioReceiveEvent -= new ScenarioReceiveHandler(OnReceiveScenario);

            if (!isCrashed)
            {
                //Enregistrement à l'événement de recetion de l'ordre LoadScenario
                MainEntry._serverEvent.LoadScenarioEvent += new LoadScenarioHandler(OnLoadScenarioOrder);


                //On attend ....
                Trace.WriteDebug("Attente1");
                wait.Reset();
                wait.WaitOne();

                //On se désenregistre à l'événement de recetion de l'ordre LoadScenario
                MainEntry._serverEvent.LoadScenarioEvent -= new LoadScenarioHandler(OnLoadScenarioOrder);
            }

            if (!isCrashed)
            {
                if (ReadXMLScenario(scenarioDatas))
                {
                    Trace.WriteInfo("lecture du scenario OK");
                }
                else
                {
                    isCrashed = true;
                    Trace.WriteError("lecture du scenario Impossible KO");
                }

                //Enregistrement à l'événement de recetion de l'ordre PlayStep
                MainEntry._serverEvent.PlayStepEvent += new PlayStepHandler(OnPlayStepOrder);

                while (!isCrashed)
                {
                    //On attend...
                    Trace.WriteDebug("Attente2");
                    wait.Reset();
                    wait.WaitOne();
                  
                    if (!isCrashed)
                    {
                        //Lecture du Step                
                        stepToPlay = new GenericStep();
                        stepToPlay = scenarioToPlay.Steps[IdOfPlayingStep];
                        PlayStep();
                    }
                }

                //désenregistrement à l'événement de recetion de l'ordre PlayStep
                MainEntry._serverEvent.PlayStepEvent -= new PlayStepHandler(OnPlayStepOrder);                
            }
        }
        public void Dispose()
        {
            if (EConfPlayer.Instance.GetNumberOfActiveCalls() > 0)
            {
                EConfPlayer.Instance.Hangup(0);
            }
         
            if (threadStepPlayer != null)
            {
                Trace.WriteInfo("Dispose ScenarioPlayer");
                //threadStepPlayer.Suspend();               
                isCrashed = true;
                wait.Set();
                wait.Close();
                threadStepPlayer = null;
            }
        }

        #endregion
        
        #region Private functions

        //Fonction ReadXMLScenario()               
        private bool ReadXMLScenario(String _datas)
        {
            bool error = false;

            //On désérialise le fichier XML pour obtenir l'objet GenericScenario
            if (_datas != null)
            {
                try
                {
                    XmlSerializer s = new XmlSerializer(typeof(GenericScenario));
                    byte[] buf = System.Text.Encoding.Unicode.GetBytes(_datas);
                    MemoryStream ms = new MemoryStream(buf);
                    scenarioToPlay = (GenericScenario)s.Deserialize((Stream)ms);

                    //Envois d'un Acquittement OK
                    MainEntry.server.SendAck(OrderResult.OK);
                }
                catch (Exception e)
                {
                    Trace.WriteError("Impossible de lire le fichier XML décrivant le scenario, format incorect");
                    error = true;
                }
            }
            else
            {
                Trace.WriteError("Le scenario n'a pas été reçu");
                error = true;
            }

            if (!error)
            {
                
                return true;
            }

            else
            {
                //Envois d'un Acquittement KO
                MainEntry.server.SendAck(OrderResult.KO);
                return false  ;
            }
        }

        //Fonction PlayStep 
        public void PlayStep()
        {
            //Initialisation variable de travail
            GenericTesterResult stepResult = new GenericTesterResult();          
            Boolean doAction=false;

            Console.WriteLine(stepToPlay.TesterSource);
            Console.WriteLine(Tester.Tools.ConfigurationFile.GetName());
            if(stepToPlay.TesterSource==Tester.Tools.ConfigurationFile.GetName())
            {
                doAction= true;
                Console.WriteLine("Do ACTION");
            }

            // 1. On identidie l'action (appel, attente de connexion, etc...) - Et Appel de fonction Bloqante


            switch ((StepsName)stepToPlay.NameId)
            {
                case StepsName.Appel:
                    {
                        if (doAction)
                        {
                            CallManager.DoCall job = new CallManager.DoCall(stepToPlay);
                            stepResult = job.Start();
                        }
                        else
                        {
                            Trace.WriteInfo("ACTION RECEPTION APPEL");
                            CallManager.ReceiveCall job = new CallManager.ReceiveCall(stepToPlay);
                            stepResult = job.Start();                          
                        }
                        break;
                    }

                case StepsName.Attente:
                    {
                        Trace.WriteInfo("Action Attente");
                        if (doAction)
                        {
                            WaitManager.DoWait job = new WaitManager.DoWait(stepToPlay);
                            stepResult = job.Start();
                        }
                        else
                        {
                        }
                        break;
                    }

                case StepsName.DTMF  :
                    {
                        Trace.WriteInfo("Action DTMF");
                        if (doAction)
                        {
                            DTMFManager.DoDTMF job = new DTMFManager.DoDTMF(stepToPlay);
                            stepResult = job.Start();
                        }
                        else
                        {
                            DTMFManager.ReceiveDTMF job = new Tester.Scenario.DTMFManager.ReceiveDTMF(stepToPlay);
                            stepResult = job.Start();
                        }
                        break;
                    }
                case StepsName.Raccrochage:
                    {
                        Trace.WriteInfo("Action Raccrochage");
                        if (doAction)
                        {
                            HangupManager.DoHangup job = new HangupManager.DoHangup(stepToPlay);
                            stepResult = job.Start();
                        }
                        else
                        {
                            HangupManager.ReceiveHangup job = new HangupManager.ReceiveHangup(stepToPlay);
                            stepResult = job.Start();
                        }
                        break;
                    }

                default:
                    {
                        Trace.WriteError("Erreur Lors de la lecture du Step - Step indéfinis");
                        isCrashed = true;
                        stepResult = null;
                        break;
                    }
            }

            //Fin de la lecture du Test, tout est OK ?
            if (!isCrashed && stepResult != null)
            {
                Trace.WriteInfo("Envois du résultat");
                MainEntry.server.SendStepResult(stepResult);
            }
            //Si plantage
            else if (isCrashed)
            {
                Trace.WriteInfo("Erreur");
                //Envoi du mesage ERROR
            }
            Trace.WriteInfo("Fin de la fonction PlayStep");
        }

        #endregion

        #region Events

        private void OnReceiveScenario(Object sender, String _datas)
        {
            if (_datas != null)
            {
                wait.Set();
                Trace.WriteInfo("Un scenario à été reçus");
                scenarioDatas = _datas;

                //Envois d'un Acquittement OK
                MainEntry.server.SendAck(OrderResult.OK);
            }
            else
            {
                Trace.WriteInfo("Erreur lors de la reception du scenario");
            }
        }

        private void OnLoadScenarioOrder(Object sender)
        {
            //On débloque
            wait.Set();
        }

        private void OnPlayStepOrder(Object sender, int num)
        {
            Trace.WriteInfo("Reception de l'ordre de lancement du step");
            IdOfPlayingStep = num;
            wait.Set();

        }

        #endregion
    }
}
