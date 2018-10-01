using System;
using System.Collections.Generic;
using System.Text;

namespace CommonProject.Scenario.Sip
{

    #region delegates
       
    /// <summary>
    /// Handler gérant l'événement d'émission d'un appel
    /// </summary>
    public delegate void CallingHandler(int callID, object XMLdatas);
    /// <summary>
    /// Handler gérant l'événement de réception d'un appel
    /// </summary>
    public delegate void IncomingCallHandler(int nID, string callerName);
   


    #endregion


    class SipphoneEvents
    {
        #region Event
    
        #endregion
    }
}
