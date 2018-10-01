using System;
using System.Collections.Generic;
using System.Text;

using CommonProject.Scenario.Datas;
using CommonProject.Scenario.ResultDatas;
using CommonProject.Scenario.ResultDatas.Steps;
using CommonProject.Tools;

using System.Threading;



namespace Tester.Scenario
{
    /// <summary>
    /// Classe abstraite pour effectuer un action 
    /// </summary>
    public abstract class ActionManager
    {

        //Variables caractérisants le résultant du step
        protected TestStatus status = TestStatus.Unknown;
        protected Int64 timeOut = Int64.MinValue;
        protected Object datas;

        protected List<String> listMsg = new List<string>(20);

        //Variable de travail de la classe
        protected Boolean isEConfEventsRegistered = false;

        //Handle pour la gestion du timer
        protected RegisteredWaitHandle timerHandle = null;
        protected ManualResetEvent _waitLock;
        protected AutoResetEvent autoWaitHandle;

      
        /// <summary>
        /// Lancement de l'action
        /// </summary>
        public GenericTesterResult Start()
        {
            GenericTesterResult result = new GenericTesterResult();
            
            //initialisation                      
            autoWaitHandle = new AutoResetEvent(false);
            _waitLock = new ManualResetEvent(false);

            try
            {
                Trace.WriteInfo("Start Action");
                //Enregitrements des instances de fonction de la classe aux événement Econf
                Register();

                Console.WriteLine("TimeOut: " + timeOut);
                //Chargement du timer
                timerHandle = ThreadPool.RegisterWaitForSingleObject(autoWaitHandle, new WaitOrTimerCallback(WaitProc), null, timeOut, true);

                //Lancement de l'action
                Action();

                Trace.WriteInfo("Attente de résultat");
                _waitLock.WaitOne();

                //Si le Timer s'est déclenché
                if (status == TestStatus.TimeOut)
                {
                    listMsg.Add("Timer déclenché");
                    status = TestStatus.TimeOut;
                    Trace.WriteInfo("TIMEOUT :" + status);
                    result = new GenericTesterResult(status, listMsg);
                }
                else if (status == TestStatus.Failed || status == TestStatus.Unknown)
                {
                    Trace.WriteInfo("ECHEC :"+status );
                    result = new GenericTesterResult(status, listMsg);
                }
                else
                {
                    if (datas != null)
                    {
                        Trace.WriteInfo("SUCCES : " + status);
                        result = new GenericTesterResult(status, listMsg, datas);
                    }
                    else
                    {
                        result = new GenericTesterResult(status, listMsg);
                    }
                }
            }

            catch (Exception e)
            {
                status = TestStatus.Failed;
                listMsg.Add("Erreur innatendue");
                Trace.WriteError(e.ToString());
                result = new GenericTesterResult(status, listMsg);
            }

            finally
            {
                Trace.WriteInfo("Fin de l'action");
                //Désenregitrements des instances de fonction de la classe aux événement Econf
                Unregister();
                //On désarme le Timer
                timerHandle.Unregister(null);
            }
            return result;

        }
        /// <summary>
        ///Méthode déclenchée lors du déclenchement du TimeOut;
        /// </summary>
        
        protected void WaitProc(object state, bool timedOut)
        {
            Trace.WriteInfo("Timeout déclenché.");

            status = TestStatus.TimeOut;
            //Relache tous les timers
            this.ReleaseTimer();

            if (autoWaitHandle != null)
            {
                autoWaitHandle.Set();
            }
        }

        /// <summary>
        ///Méthode permettant l'arrêt du Timer
        /// </summary>
        protected void ReleaseTimer()
        {
            Trace.WriteInfo("Release Timer TestCall.");
            if (_waitLock != null)
            {
                _waitLock.Set();
            }

        }

        /// <summary>
        ///Méthode Abstraite devant être implémenté par les classes filles
        /// Contient l'action à faire
        /// </summary>
        
        protected abstract void Action();

        /// <summary>
        ///Méthode Abstraite devant être implémenté par les classes filles
        /// Contient les événements à écouter
        /// </summary>
        protected abstract void Register();

        /// <summary>
        ///Méthode Abstraite devant être implémenté par les classes filles
        /// Contient les événements à se désenregister
        /// </summary>
        protected abstract void Unregister();

    }
}
