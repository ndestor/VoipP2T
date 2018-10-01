using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Serialization;

using CommonProject.Scenario.ResultDatas.Steps;

namespace CommonProject.Scenario.ResultDatas
{
    [XmlInclude(typeof(GenericCallResult)), XmlInclude(typeof(GenericDTMFResult)),
    XmlInclude(typeof(GenericHangupResult))]

    /// <summary>
    /// Objet CallResult générique
    /// Définit l'objet TesterResult commun entre le testeur et le manager.
    /// Cet objet contient la réponse d'un testeur après la lecture d'un step
    /// <summary>
    public class GenericTesterResult
    {
        [XmlAttribute("Status")]private TestStatus status;
        [XmlAttribute("Msg")]private List<String> listMsg =  new List<string>(20);        
        [XmlAttribute("Datas")]private Object datas=null;

        public GenericTesterResult()
        {
            status= TestStatus.Unknown;   
            datas=null;
        }

        public GenericTesterResult(TestStatus _status, List<String> _listMsg)
        {
            status = _status;
            listMsg = _listMsg;
        }             

        public GenericTesterResult(TestStatus _status, List<String> _listMsg, Object _datas)
        {
            status = _status;
            listMsg = _listMsg;          
            datas = _datas;
        }

        public TestStatus Status
        {
            get { return status; }
            set { status = value; }
        }                
       
      
        public List<String> Msg
        {
            get { return listMsg; }
            set { listMsg = value; }
        }

        public void AddMsg(String _msg)
        {
            listMsg.Add(_msg);
        }

        /// <summary>
        /// L'objet Data contient le résultat d'un step (CallResult,DTMFResult,HangupResult, etc...)
        /// <summary>
        public Object Datas
        {
            get { return datas; }
            set { datas = value; }
        }
    }
}
