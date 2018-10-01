using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using CommonProject.Communication;


namespace Tester.Communication
{

    //Classe gérant les évennements TCP de reception d'info de type "Message" et "Ordre" entre le Tester et le Manager
    class TcpEvents : GenericTcpEvents
    {
       
        /// <summary>
        /// Constructeur de TcpEvents
        /// </summary>
        public TcpEvents()
        {
            MainEntry.server.ReceiveDataEvent += new _TcpReceiveDataEvent(base.OnReceiveDataEvent);
            MainEntry.server.ReceiveSpecialDataEvent += new _TcpReceiveSpecialDataEvent(base.OnReceiveSpecialDataEvent);            
        }     
    }
}
