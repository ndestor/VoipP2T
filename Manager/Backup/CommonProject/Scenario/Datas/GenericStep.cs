using System;
using System.Text;
using System.Xml.Serialization;

namespace CommonProject.Scenario.Datas
{
    /// <summary>
    //Enumération des noms des steps
    /// <summary>
    public enum  StepsName
    {
        Appel = 0,
        DTMF = 1,
        Raccrochage = 2,
        Attente = 3
    }

    [XmlInclude(typeof(Steps.GenericCallStep)), XmlInclude(typeof(Steps.GenericHangupStep)),
     XmlInclude(typeof(Steps.GenericWaitStep)), XmlInclude(typeof(Steps.GenericDTMFStep))]

    /// <summary>
    /// Objet step généric
    /// Définit l'objet step commun entre le testeur et le manager.
    /// <summary>
    public class GenericStep
    {
        [XmlAttribute("Name")] protected int nameId;
        [XmlAttribute("numStep")] protected Int16 numStep;
        [XmlAttribute("testerSource")] protected String testerSource;
        [XmlAttribute("testerDestination")] protected String testerDestination;        
        [XmlAttribute("timeOut")] protected Int64 timeOut;
        
        public GenericStep()
        {
        }
        public GenericStep(int _nameId)
        {
            nameId = _nameId;
        }

        public virtual String TesterSource
        {
            get { return this.testerSource; }
            set { this.testerSource = value; }
        }
        public virtual String TesterDestination
        {
            get { return this.testerDestination; }
            set { this.testerDestination = value; }
        }
        public virtual Int64 TimeOut
        {
            get { return this.timeOut; }
            set { this.timeOut = value; }
        }
        public virtual int NameId
        {
            get { return this.nameId; }
            set { this.nameId = value; }
        }
        public virtual Int16 NumStep
        {
            get { return numStep; }
            set { numStep = value; }
        }

        public virtual Object ToGeneric()
        {
            return null;
        }

    }
}
