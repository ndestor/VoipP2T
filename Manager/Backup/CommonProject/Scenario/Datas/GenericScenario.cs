using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace CommonProject.Scenario.Datas
{
    //Scenario class which will be serialized
    [XmlRoot("scenario")]

    /// <summary>
    /// Objet sc�nario g�n�rique
    /// D�finit l'objet sc�nario commun entre le testeur et le manager.
    /// </summary>
    public class GenericScenario 
    {
        //Variables de la classe - Commun au Manager et Testeur 
        [XmlAttribute("name")]private String name = ""; //Nom du scenario
        [XmlAttribute("id")]private Int16 id = 0;       //Num�ro du scenario
        [XmlAttribute("time")]private Int64 time;       //Date et Heure du test � programmer                   
        [XmlAttribute("isPlaying")]private Boolean isPlaying = false; //Scenario est en train d'�tre jou�        
        
        //Variable utilis�es uniquement pour le Manager
        public List<GenericStep> listSteps = new List<GenericStep>(150);

        [XmlElement("Steps")] 
        public virtual List<GenericStep> Steps
        {
            get
            {
                List<GenericStep> steps = new List<GenericStep>(150);
                foreach (GenericStep s in listSteps)
                {
                    steps.Add(s);
                }
                //listSteps.CopyTo(steps.ToArray());
                return steps;
            }
            set
            {
                if (value == null) return;
                List<GenericStep> steps = (List<GenericStep>)value;
                listSteps.Clear();
                foreach (GenericStep step in steps)
                    listSteps.Add(step);
            }
        }

        //M�thodes g�n�riques
        public virtual String Name
        {
            get { return name; }
            set { name = value; }
        }
       
        public Int16 Id
        {
            get { return id; }
            set { id = value; }
        }

        public Int64 Time
        {
            get { return time; }
            set { time = value; }
        }

        public  Boolean IsPlaying
        {
            get { return isPlaying; }
            set { isPlaying = value; }
        }

    }
}
