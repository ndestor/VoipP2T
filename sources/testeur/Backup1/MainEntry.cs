using System;

using System.Text;
using System.Threading;
using CommonProject.Tools;


namespace Tester
{
    class MainEntry
    {
        #region Globals Datas

        //Declaration du server TCP pour la communication avec le Manager
        public static Communication.ServerTCP server= new Tester.Communication.ServerTCP();

        //Declaration du contrôleur d'événements de la liaison TCP
        public static Communication.TcpEvents _serverEvent = new Tester.Communication.TcpEvents();

        //Declaration du scenarioManager pour la lecture des scenarios
        public static Scenario.ScenarioManager _ScenarioManager = new Tester.Scenario.ScenarioManager();

        #endregion

        static void Main(string[] args)
        {
            Trace._Level = TraceLevel.Verbose;

            /* Lecture du Fcihier de Configuration  */
            server.Port = Tester.Tools.ConfigurationFile.GetPort();
            server.IpAddress = Tester.Tools.ConfigurationFile.GetIpAdressManager();
            /* Initialiation de Econf - Demarage */      
            Trace.WriteInfo("Econf Connected: " + SipManager.EconfClassPlayer.EConfPlayer.Instance.IsConnected);

            if (SipManager.EconfClassPlayer.EConfPlayer.Instance.IsConnected)
            {
                SipManager.EconfClassPlayer.EConfPlayer.Instance.Exit();
                SipManager.EconfClassPlayer.EConfPlayer.Instance.Restart();
            }

            try
            {               
                server.StartListen();
                Trace.WriteInfo("Ecoute sur le port "+ server.Port);
            }
            catch (Exception e)
            {
                Trace.WriteError("Ecoute sur le port "+server.Port+" impossible"); 
            }            

            Thread tidListen = new Thread(new ThreadStart(ListenStatus));
            tidListen.Start();
            //_serverEvent.StartScenarioEvent+= new CommonProject.Communication.StartScenarioHandler(Toto);

        }

        static protected void ListenStatus()
        {
            while (true)
            {
                Thread.Sleep(1000);
            }
        }

    }
}