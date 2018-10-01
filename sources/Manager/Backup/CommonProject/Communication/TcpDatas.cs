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
