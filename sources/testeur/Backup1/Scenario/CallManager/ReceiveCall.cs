using System;
using System.Collections.Generic;
using System.Text;

using Tester.SipManager.EconfClassPlayer;
using Tester.SipManager.EconfDatas;
using Tester.SipManager;

using CommonProject.Scenario.Datas;
using CommonProject.Scenario.Datas.Steps;
using CommonProject.Scenario.ResultDatas;
using CommonProject.Scenario.ResultDatas.Steps;
using CommonProject.Tools;

using System.Threading;

namespace Tester.Scenario.CallManager
{
    class ReceiveCall : ActionManager
    {
        private GenericCallStep callStep = new GenericCallStep();

        #region Constructor

        public ReceiveCall(GenericStep _step)
            : base()
        {
            callStep = new GenericCallStep();
            callStep = (GenericCallStep)_step;
            timeOut = callStep.TimeOut;
           
            timeOut += 10000;
            Trace.WriteLine(timeOut.ToString());

            EConfPlayer.Instance.ResetAllCodecs();
            EConfPlayer.Instance.ActivateCodec(eConf.eCodecType.eCODEC_AUDIOG711);
            EConfPlayer.Instance.ActivateCodec(eConf.eCodecType.eCODEC_AUDIORFC2833);
            EConfPlayer.Instance.ActivateCodec(eConf.eCodecType.eCODEC_AUDIOG722);
            Console.WriteLine("Test " + ((eConf.SipConfig)EConfPlayer.Instance._Terminal.SipConfig).AnonymousCall);
            Console.WriteLine("Test1 " + ((eConf.SipConfig)EConfPlayer.Instance._Terminal.SipConfig).CallInfo);
            Console.WriteLine("Test2 " + ((eConf.SipConfig)EConfPlayer.Instance._Terminal.SipConfig).DisplayName);
            Console.WriteLine("Test1 " + ((eConf.SipConfig)EConfPlayer.Instance._Terminal.SipConfig).AllowPresence);
        }

        #endregion

        #region Override Functions

        protected override void Action()
        {
            try
            {
                listMsg.Add("Configuration des codecs");
                
            }
            catch (Exception)
            {
                listMsg.Add("L'exécution de l'action a échoué");
                throw new Exception("L'exécution de l'action a échoué");
            }
        }

        protected override void Register()
        {
            EConfPlayer.Instance.IncomingCall += new IncomingCallHandler(Instance_IncomingCall);
           EConfPlayer.Instance.IncomingCallEx+=new IncomingCallExHandler(Instance_IncomingCallEx);
            EConfPlayer.Instance.CallDisconnected += new GenericCallHandler(Instance_CallDisconnected);
            EConfPlayer.Instance.InfoCardReceived += new PeerInfoReceivedHandler(Instance_InfoCardReceived);
            isEConfEventsRegistered = true;

        }

        protected override void Unregister()
        {
            if (isEConfEventsRegistered)
            {
                EConfPlayer.Instance.IncomingCall -= new IncomingCallHandler(Instance_IncomingCall);
                EConfPlayer.Instance.IncomingCallEx -= new IncomingCallExHandler(Instance_IncomingCallEx);
                EConfPlayer.Instance.CallDisconnected -= new GenericCallHandler(Instance_CallDisconnected);
                EConfPlayer.Instance.InfoCardReceived -= new PeerInfoReceivedHandler(Instance_InfoCardReceived);
                
                isEConfEventsRegistered = false;
            }
        }

        #endregion

        #region Econf Events

        private void Instance_InfoCardReceived(int callId, string info)
        {
            Trace.WriteInfo("infoCards: "+info);
            this.ReleaseTimer();
        }

        private void Instance_IncomingCallEx(int nID, eConf.IRemotePartyInfo XMLdatas)
        {
         
            
        }

        private void Instance_IncomingCall(int nID, string callerName)
        {
            listMsg.Add("Appel entrant détecté de " + callerName);      
            
            status = TestStatus.Success;
            EConfPlayer.Instance.AcceptCall(nID);

            GenericCallResult calldatas = new GenericCallResult(callerName);
            datas = (Object)calldatas;
            
            Trace.WriteInfo("Appel de " + callerName);
          
        }

        private void Instance_CallDisconnected(int nID)
        {
            listMsg.Add( "Appel non établit");
            status = TestStatus.Failed;
                    
            try
            {
                this.ReleaseTimer();
            }
            catch (Exception exception)
            {
                Trace.WriteDebug(exception.ToString());
            }
        }

        #endregion

    }
}
