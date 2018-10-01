using System;
using System.Collections.Generic;
using System.Text;

using System.Xml.Serialization;

namespace CommonProject.Scenario.ResultDatas.Steps
{
    /// <summary>
    /// Objet CallResult générique
    /// Définit l'objet CallResult commun entre le testeur et le manager.
    /// <summary>
    public class GenericCallResult 
    {
        [XmlAttribute("CallEvent")]private EventFailedReason callEvent=null;
        [XmlAttribute("CallerName")]private String callerName=null;
        
        public GenericCallResult():base()
        {
        }

        public GenericCallResult(String _callerName)
        {
            callerName = _callerName;
        }
               
        public String CallerName
        {
            get { return callerName; }
            set { callerName = value; }
        }

        public EventFailedReason CallEvent
        {
            get { return callEvent; }
            set { callEvent = value; }
        }
    }
}
