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
    public class DoDTMF : Scenario.ActionManager
    {
        private GenericDTMFStep DTMFStep;

        #region Constructor

        public DoDTMF(GenericStep _step)
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
            //Variable local          
            string strDTMF = DTMFConverter.ConvertDTMFToString(DTMFStep.DTMFVal);
            
            try
            {
                //Lancement du DTMF

                switch(DTMFStep.DTMFSignalType)
					{
						case DTMFSignalType.Audio:
                        {
                            listMsg.Add("Envoi du DTMF \""+strDTMF+" \"de type "+DTMFSignalType.Audio );
                            EConfPlayer.Instance.SendDTMFInBand(0, strDTMF, 2000);
							break;
                        }
						case DTMFSignalType.Numeric:
                        {
                            listMsg.Add("Envoi du DTMF \""+strDTMF+" \"de type "+DTMFSignalType.Numeric );
							EConfPlayer.Instance.SendDTMF(0,strDTMF);
							break;				
                        }
						case DTMFSignalType.SipInfoRFC2833:
                        {
                            listMsg.Add("Envoi du DTMF \"" + strDTMF + " \"de type " + DTMFSignalType.SipInfoRFC2833);
							EConfPlayer.Instance.SendDTMFRFC2833Info(0,strDTMF,2000);
							break;
                        }
						case DTMFSignalType.SIPInfoRelay:
                        {
                            listMsg.Add("Envoi du DTMF \""+strDTMF+" \"de type "+DTMFSignalType.SIPInfoRelay );
							EConfPlayer.Instance.SendDTMFRelay(0,strDTMF,DTMFStep.TapDuration);
							break;
                        }
					}
                
                status = TestStatus.Success;
                GenericDTMFResult DTMFDatas = new GenericDTMFResult(strDTMF);
                datas = DTMFDatas;
                listMsg.Add("DTMF Envoyé");
                _waitLock.Set();
            }
            catch (Exception)
            {
                listMsg.Add("L'exécution de l'action a échoué");
                status = TestStatus.Failed;
                throw new Exception("L'exécution de l'action a échoué");
            }
        }

        protected override void Register()
        {
            isEConfEventsRegistered = true;
            EConfPlayer.Instance.DTMFSent += new DTMFSentHandler(Instance_DTMFSent);
            
          
        }

        protected override void Unregister()
        {
            if (isEConfEventsRegistered)
            {
                EConfPlayer.Instance.DTMFSent -= new DTMFSentHandler(Instance_DTMFSent);
                isEConfEventsRegistered = false;
            }
        }

        #endregion

        #region Econf Events

        private void Instance_DTMFSent(int callID, string strDTMF, eConf.eDTMFKind kind, int duration)
        {
            GenericDTMFResult DTMFDatas = new GenericDTMFResult(strDTMF);
            datas = DTMFDatas;

            listMsg.Add("Un DTMF à bien été envoyé" + strDTMF);
            status = TestStatus.Success;
            this.ReleaseTimer();
        }
        #endregion
    }
}
