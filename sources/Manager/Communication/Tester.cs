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
