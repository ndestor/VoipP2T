using System;
using System.Collections.Generic;
using System.Text;

using CommonProject.Scenario.Datas;
using CommonProject.Scenario.Datas.Steps;
using CommonProject.Scenario.ResultDatas;
using CommonProject.Tools;

using Tester.SipManager.EconfClassPlayer;
using Tester.SipManager.EconfDatas;

namespace Tester.Scenario.HangupManager
{
    public class ReceiveHangup : ActionManager
    {
        private GenericHangupStep hangupStep;

        #region Constructor

        public ReceiveHangup(GenericStep _step)
            : base()
        {
            hangupStep = new GenericHangupStep();
            hangupStep = (GenericHangupStep)_step;
            timeOut = hangupStep.TimeOut;
        }

        #endregion

        #region Override Functions

        protected override void Action()
        {
        }

        protected override void Register()
        {
            EConfPlayer.Instance.CallDisconnected += new GenericCallHandler(Instance_CallDisconnected);
            isEConfEventsRegistered = true;
        }

        protected override void Unregister()
        {
            if (isEConfEventsRegistered)
            {
                EConfPlayer.Instance.CallDisconnected -= new GenericCallHandler(Instance_CallDisconnected);
                isEConfEventsRegistered = false;
            }
        }

        #endregion

        #region Econf Events

        private Boolean disconnectedEvent= false;

        private void Instance_CallDisconnected(int callid)
        {
            if (!disconnectedEvent)
            {
                listMsg.Add("Communication arrétée");
                status = TestStatus.Success;
                _waitLock.Set();
                disconnectedEvent = true;
            }

        }

        #endregion
    }
}
