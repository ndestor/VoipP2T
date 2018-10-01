using System;
using System.Collections.Generic;
using System.Text;

namespace CommonProject.Scenario.Sip
{

    #region delegates
       
    /// <summary>
    /// Handler g�rant l'�v�nement d'�mission d'un appel
    /// </summary>
    public delegate void CallingHandler(int callID, object XMLdatas);
    /// <summary>
    /// Handler g�rant l'�v�nement de r�ception d'un appel
    /// </summary>
    public delegate void IncomingCallHandler(int nID, string callerName);
   


    #endregion


    class SipphoneEvents
    {
        #region Event
    
        #endregion
    }
}
