using System;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;

namespace CommonProject.Scenario.Datas.Steps
{

    /// <summary>
    /// Objet Callstep générique
    /// Définit l'objet CallStep commun entre le testeur et le manager.
    /// <summary>
    public class GenericCallStep : GenericStep
    {
        [XmlAttribute("CallType")] protected CallType callType;
        [XmlAttribute("Protocol")] protected CallProtocol protocol;
        [XmlAttribute("Alias")] protected String alias;
        [XmlAttribute("CallMode")] protected CallMode callMode;

        //Paramètres définissant les condition de réussite de l'appel
        [XmlAttribute("CallerIdentitie")] protected Boolean callerIdentitie=true;

        public GenericCallStep()
            : base((int)StepsName.Appel)
        {
            TimeOut = 20000;
        }
        
        public virtual CallType CallType
        {
            get { return callType; }
            set { callType = value; }
        }        
        public virtual String Alias
        {
            get { return this.alias; }
            set { this.alias = value; }
        }
        public virtual CallProtocol Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }
        public virtual CallMode CallMode
        {
            get { return callMode; }
            set { callMode = value; }
        }      
        public virtual Boolean CallerIdentitie
        {
            get { return callerIdentitie; }
            set { callerIdentitie = value; }
        }
    }

#region Definition de type de données

    public  enum CallType { SipUri };
    public enum CallProtocol { Sip };
    public enum CallMode {Normal,OIR }
    public enum CallerIdentitie { Standart, Secret }    
    
#endregion
}
