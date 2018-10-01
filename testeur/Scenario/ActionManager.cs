/*
 * Copyright � 2007, Nicolas Destor
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
using CommonProject.Scenario.ResultDatas;
using CommonProject.Scenario.ResultDatas.Steps;
using CommonProject.Tools;

using System.Threading;



namespace Tester.Scenario
{
    /// <summary>
    /// Classe abstraite pour effectuer un action 
    /// </summary>
    public abstract class ActionManager
    {

        //Variables caract�risants le r�sultant du step
        protected TestStatus status = TestStatus.Unknown;
        protected Int64 timeOut = Int64.MinValue;
        protected Object datas;

        protected List<String> listMsg = new List<string>(20);

        //Variable de travail de la classe
        protected Boolean isEConfEventsRegistered = false;

        //Handle pour la gestion du timer
        protected RegisteredWaitHandle timerHandle = null;
        protected ManualResetEvent _waitLock;
        protected AutoResetEvent autoWaitHandle;

      
        /// <summary>
        /// Lancement de l'action
        /// </summary>
        public GenericTesterResult Start()
        {
            GenericTesterResult result = new GenericTesterResult();
            
            //initialisation                      
            autoWaitHandle = new AutoResetEvent(false);
            _waitLock = new ManualResetEvent(false);

            try
            {
                Trace.WriteInfo("Start Action");
                //Enregitrements des instances de fonction de la classe aux �v�nement Econf
                Register();

                Console.WriteLine("TimeOut: " + timeOut);
                //Chargement du timer
                timerHandle = ThreadPool.RegisterWaitForSingleObject(autoWaitHandle, new WaitOrTimerCallback(WaitProc), null, timeOut, true);

                //Lancement de l'action
                Action();

                Trace.WriteInfo("Attente de r�sultat");
                _waitLock.WaitOne();

                //Si le Timer s'est d�clench�
                if (status == TestStatus.TimeOut)
                {
                    listMsg.Add("Timer d�clench�");
                    status = TestStatus.TimeOut;
                    Trace.WriteInfo("TIMEOUT :" + status);
                    result = new GenericTesterResult(status, listMsg);
                }
                else if (status == TestStatus.Failed || status == TestStatus.Unknown)
                {
                    Trace.WriteInfo("ECHEC :"+status );
                    result = new GenericTesterResult(status, listMsg);
                }
                else
                {
                    if (datas != null)
                    {
                        Trace.WriteInfo("SUCCES : " + status);
                        result = new GenericTesterResult(status, listMsg, datas);
                    }
                    else
                    {
                        result = new GenericTesterResult(status, listMsg);
                    }
                }
            }

            catch (Exception e)
            {
                status = TestStatus.Failed;
                listMsg.Add("Erreur innatendue");
                Trace.WriteError(e.ToString());
                result = new GenericTesterResult(status, listMsg);
            }

            finally
            {
                Trace.WriteInfo("Fin de l'action");
                //D�senregitrements des instances de fonction de la classe aux �v�nement Econf
                Unregister();
                //On d�sarme le Timer
                timerHandle.Unregister(null);
            }
            return result;

        }
        /// <summary>
        ///M�thode d�clench�e lors du d�clenchement du TimeOut;
        /// </summary>
        
        protected void WaitProc(object state, bool timedOut)
        {
            Trace.WriteInfo("Timeout d�clench�.");

            status = TestStatus.TimeOut;
            //Relache tous les timers
            this.ReleaseTimer();

            if (autoWaitHandle != null)
            {
                autoWaitHandle.Set();
            }
        }

        /// <summary>
        ///M�thode permettant l'arr�t du Timer
        /// </summary>
        protected void ReleaseTimer()
        {
            Trace.WriteInfo("Release Timer TestCall.");
            if (_waitLock != null)
            {
                _waitLock.Set();
            }

        }

        /// <summary>
        ///M�thode Abstraite devant �tre impl�ment� par les classes filles
        /// Contient l'action � faire
        /// </summary>
        
        protected abstract void Action();

        /// <summary>
        ///M�thode Abstraite devant �tre impl�ment� par les classes filles
        /// Contient les �v�nements � �couter
        /// </summary>
        protected abstract void Register();

        /// <summary>
        ///M�thode Abstraite devant �tre impl�ment� par les classes filles
        /// Contient les �v�nements � se d�senregister
        /// </summary>
        protected abstract void Unregister();

    }
}
