using System;
using System.Xml;
using CommonProject.Tools;

namespace CommonProject.Communication
{

    #region  Generics Handlers
    
    /// <summary>
    /// Handler g�rant l'�v�nement de reception d'un ordre par le Manager
    /// </summary>
    public delegate void OrderReceivingHandler(Object sender, String XMLdatas);
    /// <summary>
    /// Handler g�rant l'�v�nement de reception d'un message Info par le Manager
    /// </summary>
    public delegate void MessageReceivingHandler(Object sender, String XMLdatas);
    /// <summary>
    /// Handler g�rant l'�v�nement d'envoi d'un message Info par le Manager
    /// </summary>
    public delegate void MessageSendindHandler(Object sender, String XMLdatas);
    /// <summary>
    /// Handler g�rant l'�v�nement de changement de status d'un testeur
    /// </summary>
    public delegate void _TcpNetworkStatusHandler(Object sender, EventArgs e); 

    #endregion

    #region Handler of Messages
    /// <summary>
    /// Handler g�rant l'�v�nement de reception de donn�es d'un scenario (Ordres ou R�sultats)
    /// </summary>
    public delegate void ScenarioReceiveHandler(Object sender, String XMLdatas);
    
    
    /// <summary>    
    /// Handler g�rant l'�v�nement de reception d'un acquitement
    /// </summary>
    public delegate void AckReceivingHandler(Object sender, String XMLdatas);
    
    /// <summary>
    /// Handler g�rant l'�v�nenement de r�ception d'un StepResult
    /// </summary>
    public delegate void StepResultReceiveHandler(String testerName, String XMLdatas);

    #endregion

    #region  Handler of orders infos
    /// <summary>
    /// Handler g�rant l'�v�nement de demande du status du Tester par le manager
    /// </summary>
    public delegate void StatusAskingHandler(Object sender);
    /// <summary>
    /// Handler g�rant l'�v�nement d'ordre de lancement de la lecture scenario 
    /// </summary>
    public delegate void StartScenarioHandler(Object sender);
    /// <summary>
    /// Handler g�rant l'�v�nement d'ordre d'arr�t de la lecture scenario
    /// </summary>
    public delegate void StopScenarioHandler(Object sender);



    /// <summary>
    /// Handler g�rant l'ordre de chargement d'un scenario
    /// </summary>
    public delegate void LoadScenarioHandler(Object sender);

    /// <summary>
    /// Handler g�rant l'ordre d'ex�cution d'un step 
    /// </summary>
    public delegate void PlayStepHandler(Object sender,Int32 numStep);


    #endregion

    public class GenericTcpEvents
    {
        
        //Variables de sctokage pour les donn�es re�ues
        private static string typeData = null;
        private static string name = null;
        private static string datas = null;


        #region Events generals

        public event OrderReceivingHandler OrderReceiveEvent;
        public event MessageReceivingHandler MessageReceiveEvent;
        public event MessageSendindHandler MessageSendEvent;
        public event _TcpNetworkStatusHandler TcpNetworkStatusEvent;
       // public event StatusTesterChangingHandler StatusChangeEvents;

        #endregion

        #region Events of orders

        public event StatusAskingHandler StatusAskEvent;
        public event StartScenarioHandler StartScenarioEvent;
        public event StopScenarioHandler StopScenarioEvent;
        public event PlayStepHandler PlayStepEvent;
        public event LoadScenarioHandler LoadScenarioEvent;
       
        #endregion

        #region Events of Messages 
        
        public event AckReceivingHandler AckReceiveEvent;
        public event ScenarioReceiveHandler ScenarioReceiveEvent;
        public event StepResultReceiveHandler StepResultReceiveEvent;

        #endregion

        /// <summary>
        /// Constructeur de TcpEvents
        /// </summary>
        public GenericTcpEvents()
        {            
        }

        #region Generics Datas Functions


        public virtual void OnReceiveSpecialDataEvent(Object sender, String XMLdatas)
        {
            if(ScenarioReceiveEvent!=null)
            {
                ScenarioReceiveEvent(sender, XMLdatas);
            }
        }
        
        protected virtual void OnReceiveDataEvent(Object sender, String XMLdatas)
        {

            Trace.WriteDebug("Analyse des donn�es re�ues - TCP Events");

            try
            {
                //Anayse des donn�es XML re�ues
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(XMLdatas);
                typeData = xDoc.GetElementsByTagName("Type")[0].InnerText;
                name = xDoc.GetElementsByTagName("Name")[0].InnerText;
               

                switch (typeData)
                {
                    case "Order": OnOrderReceiveEvent(null, XMLdatas); break;
                    case "Message": OnMessageReceiveEvent(null, XMLdatas); break;
                    default: break;
                }
            }
            catch (Exception e)
            {
                Trace.WriteDebug(e.ToString());
                Trace.WriteDebug("Le message re�u a un format incorrect");
            }
        }
        
        private void OnOrderReceiveEvent(Object sender, String XMLdatas)
        {           
            //Anayse des donn�es XML re�ues
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(XMLdatas);

            //D�clenchement de l'�v�nement
            if (OrderReceiveEvent != null)
            {
                OrderReceiveEvent(sender, XMLdatas);
            }
                
            switch (name)
            {
                case "StartScenario": OnStartScenarioEvent(sender); break;
                case "StopScenario": OnStopScenarioEvent(sender); break;
                case "PlayStep": { Int32 numStep = Convert.ToInt32(xDoc.GetElementsByTagName("NumStep")[0].InnerText); OnPlayStepEvent(sender, numStep); break; }
                case "LoadScenario": OnLoadScenarioEvent(sender); break;               
                case "StopStep": break;
                case "RestartEconf": break;
                case "RestartTCPServer": break;
                case "AskStatus": StatusAskEvent(sender); break;
                case "SynchroniseTime": break;

                default: break;
            }            
        }

        private void OnMessageReceiveEvent(Object sender, String XMLdatas)
        {
            Trace.WriteDebug("Message re�us");
            //Anayse des donn�es XML re�ues
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(XMLdatas);
            String tester = xDoc.GetElementsByTagName("Source")[0].InnerText;
            datas = xDoc.GetElementsByTagName("Datas")[0].InnerText;

            if (MessageReceiveEvent != null)
            {
                MessageReceiveEvent(sender, XMLdatas);                
            }

            switch (name)
            {
                //case "Ack": On (sender, XMLdatas); break;
                case "StepInfos": OnStepResultReceiveEvent(tester, datas); break;
                case "Ack": OnAckReceiveEvent(tester, datas); break;
                default: Console.WriteLine("Message inconnue "); break;
            }           
        }

        private void OnMessageSendEvent(Object sender, String XMLdatas)
        {
            if (MessageSendEvent != null)
            {
                MessageSendEvent(sender, XMLdatas);
            }
        }

        protected virtual void OnTcpNetworkStatusChange(Object sender, EventArgs e)
        {
            if (TcpNetworkStatusEvent != null)
            {
                TcpNetworkStatusEvent(sender, e);
            }
        }

        #endregion

        #region Message functions

        private void OnScenarioReceiveEvent(Object sender, String XMLdatas)
        {
            Trace.WriteDebug("Reception d'un scenario");
            if (ScenarioReceiveEvent != null)
            {                
                ScenarioReceiveEvent(sender, XMLdatas);
            }
        }

        private void OnStepResultReceiveEvent(String testerName, String XMLdatas) 
        {
            Trace.WriteDebug("Reception d'un StepResult");
            if (StepResultReceiveEvent != null)
            {
                StepResultReceiveEvent(testerName, XMLdatas);
            }
        }

        private void OnAckReceiveEvent(Object sender,String XMLdatas)
        {
            Trace.WriteDebug("Reception d'un acquitement");
            if (AckReceiveEvent != null)
            {
                AckReceiveEvent(sender, XMLdatas);
            }
        }

        #endregion

        #region Orders-infos functions

        private void OnStartScenarioEvent(Object sender)
        {
            Trace.WriteDebug("Ordre re�u: START Scenario");
            if (StartScenarioEvent != null)
            {                
                StartScenarioEvent(sender);
            }
        }

        private void OnStopScenarioEvent(Object sender)
        {
            Trace.WriteDebug("Ordre re�u: STOP Scenario");
            if (StopScenarioEvent != null)
            {
                StopScenarioEvent(sender);
            }
        }

        private void OnPlayStepEvent(Object sender,Int32 numStep)
        {
            Trace.WriteDebug("Ordre re�u: PlayStep");
            if (PlayStepEvent != null)
            {
                PlayStepEvent(sender,numStep);
            }
        }

        private void OnLoadScenarioEvent(Object sender)
        {
            Trace.WriteDebug("Ordre Re�u: LoadScenario");

            if (LoadScenarioEvent != null)
            {
                LoadScenarioEvent(sender);
            }
        }

        #endregion
    }
}
