using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using CommonProject.Communication;


namespace Manager.Communication 
{
    /// <summary>
    //Classe gérant les évennements TCP de reception d'infos de type "Message" et "Ordre" entre les testeurs et le Manager
    /// <summary>    
    class TcpEvents : GenericTcpEvents
    {     
        public TcpEvents()
        {
            foreach (Communication.Tester tester in MainEntry.listTesters.Tester)
            {
                tester.ReceiveDataEvent += new _TcpReceiveDataEvent(base.OnReceiveDataEvent);
                tester.ReceiveSpecialDataEvent += new _TcpReceiveSpecialDataEvent(base.OnReceiveSpecialDataEvent);
                tester.TcpNetworkStatusEvent += new _TcpNetworkStatusHandler(base.OnTcpNetworkStatusChange);
            }         
        }  

        public void  Register()
        {         
        }
    }
}
