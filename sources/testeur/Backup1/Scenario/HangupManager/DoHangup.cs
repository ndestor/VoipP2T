using System;
using System.Collections.Generic;
using System.Text;

using CommonProject.Scenario.Datas.Steps;
using CommonProject.Scenario.Datas;
using CommonProject.Scenario.ResultDatas;
using CommonProject.Tools;

using Tester.SipManager.EconfClassPlayer;

namespace Tester.Scenario.HangupManager
{
    /// <summary>
    /// Raccrochage
    /// </summary>
    public class DoHangup : ActionManager
    {
        private GenericHangupStep HangupStep;

        #region Constructor

        public DoHangup(GenericStep _step)
            : base()
        {
            HangupStep = new GenericHangupStep();
            HangupStep = (GenericHangupStep)_step;
            timeOut = HangupStep.TimeOut;
        }

        #endregion

        #region Override Functions

        protected override void Action()
        {
            try
            {
                Trace.WriteInfo(MainEntry._ScenarioManager.callId.ToString());
                EConfPlayer.Instance.Hangup(MainEntry._ScenarioManager.callId);
                listMsg.Add("Raccrochage en cours");
            }
            catch (Exception)
            {
                listMsg.Add("L'exécution de l'action a échoué.");
                throw new Exception("L'exécution de l'action a échoué.");
            }
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

        private Boolean disconnectedEvent = false;

        private void Instance_CallDisconnected(int callid)
        {
            if (!disconnectedEvent)
            {
                listMsg.Add("La communication est arrété");
                Trace.WriteInfo("FIN d'appel détecté");
                status = TestStatus.Success;
                _waitLock.Set();
                disconnectedEvent = true;
            }
        }

        #endregion
    }
}


