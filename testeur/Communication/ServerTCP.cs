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
using System.Net;
using System.Net.Sockets;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

using CommonProject.Communication;
using CommonProject.Tools;

using CommonProject.Scenario.ResultDatas;

namespace Tester.Communication
{
    public delegate void _ServerReceiveDataEvent(Object sender, String XMLdatas); 

    class ServerTCP : GenericTcpCore
    {
        private TcpListener TcpL;
        private TcpClient TcpC;       

        private String testerName;

        public ServerTCP()
        {
            testerName = Tools.ConfigurationFile.GetName();
            base.TcpNetworkStatusEvent += new _TcpNetworkStatusHandler(OnStatusChange);
        }

        private void OnStatusChange(Object sender, EventArgs e)
        {
            if (!IsConnected)
            {
                Trace.WriteInfo("Redémarrage du serveur TCP");
                ResetServer();
            }
        }

        public void StartListen()
        {
            try
            {
                //start listening...
                TcpL = new TcpListener(IPAddress.Any, this.port);
                TcpL.Start();
                // create the call back for any client connections...               
                TcpL.BeginAcceptTcpClient(new AsyncCallback(OnClientConnect), null);
                
            }
            catch (Exception se)
            {
                ResetServer();
                IsConnected = false;
            }
        }  

        private void ResetServer()
        {
            
            TcpL.Stop();
            TcpC.Close();
            base.Reset();
            StartListen();

           // MainEntry._serverEvent = new TcpEvents();
           // MainEntry._ScenarioManager = new Tester.Scenario.ScenarioManager();
        }

        private void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                TcpC = TcpL.EndAcceptTcpClient(asyn);

                base.NS = TcpC.GetStream();

                Trace.WriteInfo("Connection au Manager établit");
                IsConnected = true;
                base.WaitForData();
            }
            catch (ObjectDisposedException)
            {
                Trace.WriteDebug("\n OnClientConnection: Socket has been closed\n");
                IsConnected = false;
                base.OnTcpNetworkStatusChange(this, null);                
            }
            catch (SocketException se)
            {
                Trace.WriteDebug(se.Message);
                IsConnected = false;
                base.OnTcpNetworkStatusChange(this, null);
            }
        }

        public void SendStepResult(GenericTesterResult _stepResults)
        {
            try
            {
                XmlSerializer s = new XmlSerializer(typeof(GenericTesterResult));
                MemoryStream ms = new MemoryStream();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(ms, Encoding.Unicode);
                s.Serialize(xmlTextWriter, _stepResults);
                ms = (MemoryStream)xmlTextWriter.BaseStream;

                UnicodeEncoding encoding = new UnicodeEncoding();
                String XmlStepResults = encoding.GetString(ms.ToArray());

                base.SendString(TcpDatas.StepInfos(testerName, XmlStepResults));
            }
            catch (Exception e)
            {
                Trace.WriteError(e.ToString());
            }
        }

        public void SendAck(OrderResult _res)
        {
            try
            {
                base.SendString(CommonProject.Communication.TcpDatas.Ack(testerName, _res));
            }
            catch (Exception e)
            {
                Trace.WriteError(e.ToString());
            }
        }        
    
    }
}
