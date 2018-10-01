using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CommonProject.Scenario.Datas.Steps
{
    /// <summary>
    /// Objet WaitStep générique
    /// Définit l'objet WaitStep commun entre le testeur et le manager.
    /// <summary>
    public class GenericWaitStep : GenericStep 
    {
        [XmlAttribute("waitTime")]protected Int64 waitTime = 5000;

        public GenericWaitStep()
            : base((int)StepsName.Attente)
        {
            TimeOut = 20000;
        }

        [CategoryAttribute("\tParamètres"), DescriptionAttribute("Délais d'attente (en ms).")]
        public virtual Int64 WaitTime
        {
            get { return waitTime; }
            set { waitTime = value; }
        }              
    }
}
