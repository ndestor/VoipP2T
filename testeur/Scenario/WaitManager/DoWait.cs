/*
 * Copyright © 2007, Nicolas Destor
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, 
 * are permitted provided that the following conditions are met:
 *
 *    - Redistributions of source code must retain the above copyright notice, 
 *      this list of conditions and the following disclaimer.
 * 
 *    - Redistributions in binary form must reproduce the above copyright notice, 
 *      this list of conditions and the following disclaimer in the documentation 
 *      and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
 * IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
 * OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
 * OF SUCH DAMAGE.
 */
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

