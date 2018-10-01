using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Xml.Serialization;

namespace CommonProject.Scenario.ResultDatas.Steps
{
    /// <summary>
    /// Objet DTMFResult générique
    /// Définit l'objet DTMFResult commun entre le testeur et le manager.
    /// <summary>
    public class GenericDTMFResult
    {      
        [XmlAttribute("DTMF")]String dtmf;

        public GenericDTMFResult() :base()
        {           
        }

        public GenericDTMFResult(String _dtmf)
        {
            _dtmf = dtmf;
        }

        public String DTMF
        {
            get { return dtmf; }
            set { dtmf = value; }
        }

       
    }
}
