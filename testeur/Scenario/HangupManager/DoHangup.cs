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


