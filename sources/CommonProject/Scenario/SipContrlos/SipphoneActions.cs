using System;
using System.Collections.Generic;
using System.Text;

namespace CommonProject.Scenario.Sip
{
    public interface SipphoneActions
    {
        //Etablissement d'un appel
        void PerformCall(string address, string callType);
       
        //Raccrochage de l'appel
        void Hangup(int callID);

        //Accepte l'appel 
        void AcceptCall(int callID);

        //Rejette l'appel
        void RejectCall(int callID);
    }
}
