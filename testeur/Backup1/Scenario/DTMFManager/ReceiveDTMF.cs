using System;
using System.Collections.Generic;
using System.Text;

using CommonProject.Scenario.Datas;
using CommonProject.Scenario.Datas.Steps;
using CommonProject.Scenario.ResultDatas;
using CommonProject.Scenario.ResultDatas.Steps;
using CommonProject.Tools;

using Tester.SipManager.EconfClassPlayer;
using Tester.SipManager.EconfDatas;

namespace Tester.Scenario.DTMFManager
{
    public class ReceiveDTMF : ActionManager
    {
        public GenericDTMFStep DTMFStep;

        #region Constructor

        public ReceiveDTMF(GenericStep _step)
            : base()
        {
            DTMFStep = new GenericDTMFStep();
            DTMFStep = (GenericDTMFStep)_step;
            timeOut = DTMFStep.TimeOut;
        }

        #endregion

        #region Override Functions

        protected override void Action()
        {
            try
            {
            }
            catch (Exception)
            {
                throw new Exception("L'exécution de l'action a échoué");
            }
        }

        protected override void Register()
        {
            isEConfEventsRegistered = true;
            EConfPlayer.Instance.DTMFReceived += new DTMFReceivedHandler(Instance_DTMFReceived);
            EConfPlayer.Instance.SIP_DTMFOutbandReceived += new DTMFOutbandReceivedHandler(Instance_SIP_DTMFOutbandReceived);
        
            EConfPlayer.Instance.DTMFOutbandReceived+=new DTMFOutbandReceivedHandler(Instance_DTMFOutbandReceived);
             
        }

        protected override void Unregister()
        {
            if (isEConfEventsRegistered)
            {
                EConfPlayer.Instance.DTMFReceived -= new DTMFReceivedHandler(Instance_DTMFReceived);
                EConfPlayer.Instance.SIP_DTMFOutbandReceived -= new DTMFOutbandReceivedHandler(Instance_SIP_DTMFOutbandReceived);
                EConfPlayer.Instance.DTMFOutbandReceived -= new DTMFOutbandReceivedHandler(Instance_DTMFOutbandReceived);
                isEConfEventsRegistered = false;
            }
        }

        #endregion

        #region Econf Events



        private void Instance_SIP_DTMFOutbandReceived(string strDTMF, int duration)
        {
            GenericDTMFResult DTMFDatas = new GenericDTMFResult(strDTMF);
            datas = DTMFDatas;
            listMsg.Add("Un DTMF a été reçu");
            listMsg.Add("DTMF \"" + strDTMF + " dans le flux SIP outband");
            Trace.WriteDebug("Un DTMF à bien été reçu dans le flux RTP: " + strDTMF);
            Trace.WriteDebug(strDTMF);
            status = TestStatus.Success;
            this.ReleaseTimer();
        }

        private void Instance_DTMFOutbandReceived(string strDTMF, int duration)
        {
            GenericDTMFResult DTMFDatas = new GenericDTMFResult(strDTMF);
            datas = DTMFDatas;
            listMsg.Add("Un DTMF a été reçu");
            listMsg.Add("DTMF \"" + strDTMF + "\" dans le flux RTP outband");
            Trace.WriteDebug("Un DTMF à bien été reçu dans le flux RTP: " + strDTMF);
            Trace.WriteDebug(strDTMF);
            status = TestStatus.Success;
            this.ReleaseTimer();
        }

        private void Instance_DTMFReceived(string strDTMF)
        {
            GenericDTMFResult DTMFDatas = new GenericDTMFResult(strDTMF);
            datas = DTMFDatas;

            listMsg.Add("Un DTMF a été reçu: " + strDTMF);
            listMsg.Add("Flux d'origine de reception  du DTMF inconnue");
            Trace.WriteDebug("Un DTMF a été reçu: " + strDTMF);
            status = TestStatus.Success;
            this.ReleaseTimer();
        }

        #endregion
    }
}
