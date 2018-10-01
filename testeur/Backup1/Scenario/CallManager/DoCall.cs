using System;
using System.Collections;
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
    public class DoCall : ActionManager
    {
        private GenericCallStep callStep = new GenericCallStep();
        
        #region Constructor
        public DoCall(GenericStep _step)
            : base()
        {
            callStep = new GenericCallStep();
            callStep = (GenericCallStep)_step;
            timeOut = callStep.TimeOut;
            Console.WriteLine("Test " + ((eConf.SipConfig)EConfPlayer.Instance._Terminal.SipConfig).AnonymousCall);
        }
        #endregion

        #region Override Functions
        protected override void Action()
        {
            try
            {
                EConfPlayer.Instance.ResetAllCodecs();
                EConfPlayer.Instance.ActivateCodec(eConf.eCodecType.eCODEC_AUDIOG711);
                EConfPlayer.Instance.ActivateCodec(eConf.eCodecType.eCODEC_AUDIORFC2833);
                
                listMsg.Add("Lancement de l'appel - SIP URI: " + callStep.Alias);
                Trace.WriteInfo("PerformCall -SIP URI: " + callStep.Alias);
                //Lancement de l'appel
                EConfPlayer.Instance.PerformCall(CallConverter.GetEconfProtocol(callStep.Protocol), callStep.Alias, CallConverter.GetEconfCallType(callStep.CallType));

            }

            catch (Exception e)
            {
                Trace.WriteDebug(e.Message);
                throw new Exception("L'exécution de l'action a échoué");
            }
        }
        
        protected override void Register()
        {
            // _ReasonFailed = new ArrayList();
            EConfPlayer.Instance.CallConnected += new GenericCallHandler(Instance_CallConnected);
            EConfPlayer.Instance.CallDisconnected += new GenericCallHandler(Instance_CallDisconnected);
            EConfPlayer.Instance.LocalRejected += new GenericCallHandler(Instance_LocalRejected);
            EConfPlayer.Instance.CallFailed += new CallFailedHandler(Instance_CallFailed);
            EConfPlayer.Instance.CallRejected += new GenericCallHandler(Instance_CallRejected);
            EConfPlayer.Instance.RemoteRinging+=new GenericIntegerHandler(Instance_RemoteRinging);
            isEConfEventsRegistered = true;

        }

        protected override void Unregister()
        {
            if (isEConfEventsRegistered)
            {               
                EConfPlayer.Instance.CallConnected -= new GenericCallHandler(Instance_CallConnected);
                EConfPlayer.Instance.CallDisconnected -= new GenericCallHandler(Instance_CallDisconnected);
                EConfPlayer.Instance.LocalRejected -= new GenericCallHandler(Instance_LocalRejected);
                EConfPlayer.Instance.CallFailed -= new CallFailedHandler(Instance_CallFailed);
                EConfPlayer.Instance.CallRejected -= new GenericCallHandler(Instance_CallRejected);
                EConfPlayer.Instance.RemoteRinging -= new GenericIntegerHandler(Instance_RemoteRinging);
                isEConfEventsRegistered = false;
            }
        }
        #endregion

        #region Econf Events
        private void Instance_CallConnected(int nID)
        {
            listMsg.Add("Appel établit");
            
            MainEntry._ScenarioManager.callId = nID;
            status = TestStatus.Success;

            this.ReleaseTimer();
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

        private void Instance_LocalRejected(int nID)
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

        private void Instance_CallFailed(int nID, short failureReason)
        {
            listMsg.Add("Appel non établit (" + (FailureReason)failureReason+")");
            status = TestStatus.Failed;

            this.ReleaseTimer();
        }

        private void Instance_CallRejected(int nID)
        {
            listMsg.Add("Appel non établit");
            status = TestStatus.Failed;
            try
            {
                this.ReleaseTimer();
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.ToString());
            }
        }

        Boolean ringingEvent = false;

        private void Instance_RemoteRinging(int intParam) 
        {
            if (!ringingEvent)
            {
                listMsg.Add("Le terminal distant sonne");
                ringingEvent = true;
            }
        } 

        #endregion
    }
}

