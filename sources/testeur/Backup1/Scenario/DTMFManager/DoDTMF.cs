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
