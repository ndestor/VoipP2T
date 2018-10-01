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
using System.Xml;
using CommonProject.Tools;

namespace CommonProject.Communication
{

    #region  Generics Handlers
    
    /// <summary>
    /// Handler gérant l'événement de reception d'un ordre par le Manager
    /// </summary>
    public delegate void OrderReceivingHandler(Object sender, String XMLdatas);
    /// <summary>
    /// Handler gérant l'événement de reception d'un message Info par le Manager
    /// </summary>
    public delegate void MessageReceivingHandler(Object sender, String XMLdatas);
    /// <summary>
    /// Handler gérant l'événement d'envoi d'un message Info par le Manager
    /// </summary>
    public delegate void MessageSendindHandler(Object sender, String XMLdatas);
    /// <summary>
    /// Handler gérant l'événement de changement de status d'un testeur
    /// </summary>
    public delegate void _TcpNetworkStatusHandler(Object sender, EventArgs e); 

    #endregion

    #region Handler of Messages
    /// <summary>
    /// Handler gérant l'événement de reception de données d'un scenario (Ordres ou Résultats)
    /// </summary>
    public delegate void ScenarioReceiveHandler(Object sender, String XMLdatas);
    
    
    /// <summary>    
    /// Handler gérant l'événement de reception d'un acquitement
    /// </summary>
    public delegate void AckReceivingHandler(Object sender, String XMLdatas);
    
    /// <summary>
    /// Handler gérant l'événenement de réception d'un StepResult
    /// </summary>
    public delegate void StepResultReceiveHandler(String testerName, String XMLdatas);

    #endregion

    #region  Handler of orders infos
    /// <summary>
    /// Handler gérant l'événement de demande du status du Tester par le manager
    /// </summary>
    public delegate void StatusAskingHandler(Object sender);
    /// <summary>
    /// Handler gérant l'événement d'ordre de lancement de la lecture scenario 
    /// </summary>
    public delegate void StartScenarioHandler(Object sender);
    /// <summary>
    /// Handler gérant l'événement d'ordre d'arrêt de la lecture scenario
    /// </summary>
    public delegate void StopScenarioHandler(Object sender);



    /// <summary>
    /// Handler gérant l'ordre de chargement d'un scenario
    /// </summary>
    public delegate void LoadScenarioHandler(Object sender);

    /// <summary>
    /// Handler gérant l'ordre d'exécution d'un step 
    /// </summary>
    public delegate void PlayStepHandler(Object sender,Int32 numStep);


    #endregion

    public class GenericTcpEvents
    {
        
        //Variables de sctokage pour les données reçues
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

            Trace.WriteDebug("Analyse des données reçues - TCP Events");

            try
            {
                //Anayse des données XML reçues
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
                Trace.WriteDebug("Le message reçu a un format incorrect");
            }
        }
        
        private void OnOrderReceiveEvent(Object sender, String XMLdatas)
        {           
            //Anayse des données XML reçues
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(XMLdatas);

            //Déclenchement de l'événement
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
            Trace.WriteDebug("Message reçus");
            //Anayse des données XML reçues
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
            Trace.WriteDebug("Ordre reçu: START Scenario");
            if (StartScenarioEvent != null)
            {                
                StartScenarioEvent(sender);
            }
        }

        private void OnStopScenarioEvent(Object sender)
        {
            Trace.WriteDebug("Ordre reçu: STOP Scenario");
            if (StopScenarioEvent != null)
            {
                StopScenarioEvent(sender);
            }
        }

        private void OnPlayStepEvent(Object sender,Int32 numStep)
        {
            Trace.WriteDebug("Ordre reçu: PlayStep");
            if (PlayStepEvent != null)
            {
                PlayStepEvent(sender,numStep);
            }
        }

        private void OnLoadScenarioEvent(Object sender)
        {
            Trace.WriteDebug("Ordre Reçu: LoadScenario");

            if (LoadScenarioEvent != null)
            {
                LoadScenarioEvent(sender);
            }
        }

        #endregion
    }
}
