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
using System.Xml;

namespace CommonProject.Communication
{
    public abstract class TcpDatas
    {
        #region Tester Messages        
        /// <summary>
        /// Message décrivant le résultat d'un step exécuté sur un testeur
        /// </summary>
        public static String StepInfos(String _tester,String _datas)
        {

            String message = "<MS><Type>Message</Type><Name>StepInfos</Name><Source>" + _tester + "</Source><Datas><![CDATA[" + _datas + "]]></Datas></MS>";
            return message;
        }
        /// <summary>
        /// Message d'écrivant le status du testeur 
        /// </summary>
        public static String StatusAnswer(String _tester, String status)
        {
            String message = "<MS><Type>Message</Type><Name>Status</Name><Source>" + _tester + "</Source><Datas><StatusInfos>"
                             + status + "</StatusInfos></Datas></MS>";

            return message;
        }

        #endregion

        #region Common Messages
        /// <summary>
        /// Message décrivant un acquitement
        /// </summary>
        public static String Ack(String _tester, OrderResult _data)
        {
            String message = "<MS><Type>Message</Type><Name>Ack</Name><Source>" + _tester + "</Source><Datas>" + _data + "</Datas></MS>";

            return message;
        }

        #endregion

        #region Manager Messages

        #region Orders

        /// <summary>
        /// Message décrivant le démarrage du processus de lecture d'un scénario sur un testeur
        /// </summary>
        public static String StartScenario()
        {
            String message = "<MS><Type>Order</Type><Name>StartScenario</Name><Source>"+null+"</Source></MS>";

            return message;
        }

        /// <summary>
        /// Message décrivant l'ordre de fin du processus de lecture sur un testeur
        /// </summary>
        public static String StopScenario()
        {
            String message = "<MS><Type>Order</Type><Name>StopScenario</Name><Source>" + null + "</Source></MS>";

            return message;
        }

        /// <summary>
        /// Message décrivant l'ordre de lecture du scénario sur un testeur
        /// </summary>
        public static String PlayStep(Int32 _num)
        {
            String message = "<MS><Type>Order</Type><Name>PlayStep</Name><Source>" + null + "</Source><NumStep>" + _num + "</NumStep></MS>";

            return message;
        }

        /// <summary>
        /// Message décrivant l'ordre de chargement du scénario sur un testeur
        /// </summary>
        public static String LoadScenario()
        {
            String message = "<MS><Type>Order</Type><Name>LoadScenario</Name><Source>" + null + "</Source></MS>";

            return message;
        }

        /// <summary>
        /// Message décrivant la demande du status d'un testeur
        /// </summary>
        public static String StatusAsk()
        {
            String message = "<MS><Type>Order</Type><Name>Status Ask</Name><Source>" + null + "</Source></MS>";

            return message;
        }

        #endregion

        #endregion               
    }
}
