using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;

using CommonProject.Communication;
using CommonProject.Tools;



namespace Manager.Communication
{
    /// <summary>
    //Classe définissant une entité testeur pour le manager
    /// <summary>  
    class Tester : GenericTcpCore
    {        
        //Variables de données
        private Int16 id;
        private String alias;

        //Variables utiles pour la connection TCP
        private TcpClient Client;      

        #region public functions

        public Tester()
       {   
       }      

        public void ConnectToTester()
       {
           if (!this.IsConnected)
           {
               Trace.WriteInfo("Essai de connection au testeur nommé " + this.Name);
               connect();            
           }
       }

        public String Alias
        {
            get { return alias; }
            set { alias = value; }
        }

        public Int16 Id
        {
            get { return id; }
            set { id = value; }
        }

        #endregion

        #region Private functions

        private void connect()
        {
            try
            {
                /* Connecting to server (will crash if address/name is incorrect) */
                Client = new TcpClient(this.ipAddress, this.port);
                Msg = "Connecté au testeur d'adresse IP " + this.ipAddress + " sur le port " + this.port;
                /* Store the NetworkStream */
                NS = Client.GetStream();
                //Changement du status
                IsConnected = true;
                /* Create data buffer */
                base.WaitForData();
            }
            catch (Exception e)
            {
                Trace.WriteError(e.Message);
                Msg = e.Message;
                IsConnected = false;
                
            }
            finally
            {
                base.OnTcpNetworkStatusChange(this, null);
            }
        }

        #endregion

        #region SendingFunctions

        public void Send_StatusAsk()
        {
            try
            {
                SendString(TcpDatas.StartScenario());
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void StartScenario() 
        {
            SendString(TcpDatas.StartScenario());
        }

        public void StopScenario()
        {
            SendString(TcpDatas.StopScenario());
        }

        public void PlayStep(Int32 num)
        {
            SendString(TcpDatas.PlayStep(num));
        }

        public void LoadScenario()
        {
            SendString(TcpDatas.LoadScenario());
        }

        #endregion

      
      
    }    
}
