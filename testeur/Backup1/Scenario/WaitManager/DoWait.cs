using System;
using System.Collections;
using System.Text;

using CommonProject.Scenario.Datas;
using CommonProject.Scenario.Datas.Steps;

using Tester.SipManager.EconfClassPlayer;
using Tester.SipManager.EconfDatas;
using Tester.SipManager;

using CommonProject.Scenario.ResultDatas;
using CommonProject.Scenario.ResultDatas.Steps;
using CommonProject.Tools;

using System.Threading;

namespace Tester.Scenario.WaitManager
{
    public class DoWait : ActionManager
    {
        private System.Timers.Timer waitTimer;
        private GenericWaitStep WaitStep = new GenericWaitStep();
        

        public DoWait(GenericStep _step)
            : base()
        {
            waitTimer = new System.Timers.Timer();
            WaitStep = new GenericWaitStep();
            WaitStep = (GenericWaitStep)_step;
            timeOut = WaitStep.TimeOut;
        }


        protected override void Action()
        {           
            waitTimer.Interval = (WaitStep.WaitTime - 1000);
            // Démarage du timer

            waitTimer.Start();
        }

        protected override void Register()
        {
            waitTimer.Elapsed += new System.Timers.ElapsedEventHandler(waitTimer_Elapsed);

        }

        protected override void Unregister()
        {
            waitTimer.Elapsed -= new System.Timers.ElapsedEventHandler(waitTimer_Elapsed);
        }

        #region Events

        private void waitTimer_Elapsed(Object sender, System.Timers.ElapsedEventArgs e)
        {
            status = TestStatus.Success;
            listMsg.Add("Temps d'attente écoulé avec succés");
            Trace.WriteInfo("Temps d'attente écoulé avec succés");
            if (waitTimer != null)
            {
                waitTimer.Stop();
                waitTimer.Dispose();
            }
            _waitLock.Set();

        }

        #endregion
    }
}

