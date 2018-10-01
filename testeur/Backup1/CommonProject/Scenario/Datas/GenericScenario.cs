/*
 * Copyright © 2007, Nicolas Destor
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, 
 * are permitted provided that the following conditions are met:
 *
 *    - Redistributions of source code must retain the above copyright notice, 
 *      this list of conditions and the following disclaimer.
 * 
 *    - Redistributions in binary form must reproduce the above copyright notice, 
 *      this list of conditions and the following disclaimer in the documentation 
 *      and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
 * IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
 * INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
 * OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
 * OF SUCH DAMAGE.
 */
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
    /// Objet scénario générique
    /// Définit l'objet scénario commun entre le testeur et le manager.
    /// </summary>
    public class GenericScenario 
    {
        //Variables de la classe - Commun au Manager et Testeur 
        [XmlAttribute("name")]private String name = ""; //Nom du scenario
        [XmlAttribute("id")]private Int16 id = 0;       //Numéro du scenario
        [XmlAttribute("time")]private Int64 time;       //Date et Heure du test à programmer                   
        [XmlAttribute("isPlaying")]private Boolean isPlaying = false; //Scenario est en train d'être joué        
        
        //Variable utilisées uniquement pour le Manager
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

        //Méthodes génériques
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
