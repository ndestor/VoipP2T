using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CommonProject.Scenario.Datas.Steps
{
    /// <summary>
    /// Objet HangupStep générique
    /// Définit l'objet HangupStep commun entre le testeur et le manager.
    /// <summary>
    public class GenericHangupStep : GenericStep
    {
        public GenericHangupStep()
            : base((int)StepsName.Raccrochage)
        {
            TimeOut = 20000;
        }
    }
}
