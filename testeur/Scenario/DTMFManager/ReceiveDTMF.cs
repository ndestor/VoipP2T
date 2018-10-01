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
