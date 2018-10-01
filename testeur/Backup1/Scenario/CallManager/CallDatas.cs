using System;
using System.Collections.Generic;
using System.Text;

using CommonProject.Scenario.Datas.Steps;
using CommonProject.Scenario.Datas;

namespace Tester.Scenario.CallManager
{    
    class CallConverter
    {
        public static eConf.eProtocol GetEconfProtocol(CallProtocol _protocol)
        {
            eConf.eProtocol protocol = eConf.eProtocol.ePROTOCOL_SIP;
            switch (_protocol)
            {
                case CallProtocol.Sip: protocol = eConf.eProtocol.ePROTOCOL_SIP; break;             
            }

            return protocol;
        }

        public static  eConf.eCallType GetEconfCallType(CallType _type)
        {
            return eConf.eCallType.eCALL_TYPE_ADDRESS;
        }
    }
}
