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
