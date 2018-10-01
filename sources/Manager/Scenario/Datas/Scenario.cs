using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

using CommonProject.Scenario.Datas;

using Manager.Scenario.ResultDatas;

namespace Manager.Scenario.Datas
{

    /// <summary>
    /// Classe permettant de caractériserun scénario
    /// <summary>
    public class ScenarioDatas
    {
        private String name;
        private String fullPath;
        
        public ScenarioDatas()
        {
            name = "";
            fullPath = "";
        }

        public ScenarioDatas(ScenarioDatas _datas)
        {
            name = _datas.Name;
            fullPath = _datas.FullPath;
        }

        public ScenarioDatas(String _name, String _directory)
        {
            name = _name;
            fullPath = _directory;           
        }


        [CategoryAttribute("Générales"), DescriptionAttribute("Nom du fichier Scenario")]
        [DisplayName("(Nom)")]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        [CategoryAttribute("Générales"), DescriptionAttribute("Chemin d'accès au fichier Scenario")]
        [DisplayName("Chemin d'accés")]
        public String FullPath
        {
            get { return fullPath; }
            set { fullPath = value; }
        }
    }

    /// <summary>
    /// Classe Scénario redéfinissant l'objet GenericScenario
    /// <summary>
    [XmlInclude(typeof(Datas.Steps.CallStep))]
    public class Scenario : GenericScenario
    {
        private ScenarioDatas parameters;
        private Boolean isValidate = false;
        private List<ScenarioResult> listResults = new List<ScenarioResult>(20);

        #region Constructeur
        /// <summary>
        /// Constructeur vide
        /// <summary>
        public Scenario()
        {           
        }
        /// <summary>
        /// Classe Scénario redéfinissant l'objet GenericScénario
        /// <summary>
        public Scenario(ScenarioDatas _datas)
        {
            parameters = new ScenarioDatas(_datas);         
        }

        /// <summary>
        /// Classe Scénario redéfinissant l'objet GenericScénario
        /// <summary>
        public Scenario(String _UrlFile)
        {
            parameters = new ScenarioDatas();
            this.Load(_UrlFile);
        }
        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Transforme le scénario en scénario générique
        /// <summary>
        public GenericScenario ToGeneric()
        {
            GenericScenario current = new GenericScenario();
            current.Name = base.Name;
            current.Id = base.Id;
            current.IsPlaying = base.IsPlaying;
            current.Steps = this.GenericSteps;
            current.Time = base.Time;
            
            return current;
        }
          
        /// <summary>
        /// Ajoute un step au scénario
        /// <summary>
        public void AddStep(GenericStep value)
        {
            value.NumStep =(short)this.listSteps.Count;      
            this.listSteps.Add(value);
            MainEntry._ScenarioEvents.OnNewStep(value, null);
        }

        /// <summary>
        /// Ajoute une fiche résultat du scénario
        /// <summary>
        public void AddResult( ScenarioResult _result)
        {
            ScenarioResult newResult = new ScenarioResult();           
            newResult.BeginTime = _result.BeginTime;
            newResult.HasCrashed=_result.HasCrashed;
            newResult.IdScenario=_result.IdScenario;
            newResult.LogResult = _result.LogResult;
            newResult.Name = _result.Name;
            newResult.StepsResults = _result.StepsResults;
            this.listResults.Add(newResult);
            MainEntry._ScenarioEvents.OnNewScenarioResult(newResult, null);           
        }

        /// <summary>
        /// Renvois la dernière fiche résultat
        /// <summary>
        public ScenarioResult GetLastResult()
        {
            return listResults[listResults.Count - 1];
        }

        /// <summary>
        /// Supprime toutes les fiches résultats du scénario
        /// <summary>
        public void Clear()
        {
            listResults.Clear();         
        }

        /// <summary>
        /// Intervertit l'ordre de deux steps du scénario 
        /// <summary>
        public void InvertTwoSteps(int _index1, int _index2)
        {
            GenericStep tempStep= new GenericStep();
            tempStep = listSteps[_index1];

            listSteps[_index1]= listSteps[_index2];
            listSteps[_index1].NumStep = Convert.ToInt16(_index1);
                       
            listSteps[_index2]= tempStep;
            listSteps[_index2].NumStep = Convert.ToInt16(_index2);
        }

        /// <summary>
        /// Valide le scénario (aucune modification ultérieur possibile)
        /// <summary>
        public void Valid()
        {           
            this.isValidate = true;
        }

        /// <summary>
        /// supprime un step
        /// <summary>
        public void RemoveStep(Int16 index)
        {            
            listSteps.RemoveAt(index);
            foreach (GenericStep step in listSteps)
            {
                if (step.NumStep > index)
                {
                    step.NumStep = Convert.ToInt16(step.NumStep - 1);
                }
            }
        }

        /// <summary>
        /// Supprime un résultat
        /// <summary>
        public void RemoveResult(ScenarioResult _result)
        {            
            listResults.Remove(_result);      
        }

        /// <summary>
        /// Sauvegarde le scénario
        /// <summary>
        public void Save()
        {
            try
            {
                /***** Creation du fichier XML *****/
                //Creation du fichier XML - Declaration XML
             
                XmlTextWriter file = new XmlTextWriter(this.FullPath + "\\" + this.Name + ".ats", System.Text.Encoding.Unicode);
                //mise en Forme pour l'indentation
                file.Formatting = System.Xml.Formatting.Indented;
                file.Indentation = 2;


                //Debut du fichier xml
                file.WriteStartDocument();
                //Commentaire

                file.WriteComment("Fichier Scenario - Automate de Tests V1.0");
                //Creation de l'élément racine du fichier
                file.WriteStartElement("Scenario");

                //Paramètre générals
                file.WriteElementString("Name", this.Name);
                file.WriteElementString("IsValidate", this.IsValidate.ToString());
                //Elément Steps
                file.WriteStartElement("Steps");

                foreach (GenericStep current in Steps)
                {
                    file.WriteStartElement("Step");
                    file.WriteElementString("Type", current.GetType().ToString()); 
                    
                    //On Sérialise le Step en des données XML
                    XmlSerializer s = new XmlSerializer(current.GetType());
                    MemoryStream ms = new MemoryStream();
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(ms, Encoding.Unicode);
                    s.Serialize(xmlTextWriter, current);
                    ms = (MemoryStream)xmlTextWriter.BaseStream;
                    UnicodeEncoding encoding = new UnicodeEncoding();
                    String stepString = encoding.GetString(ms.ToArray());
                    file.WriteStartElement("Datas");
                    file.WriteCData(stepString);                    
                    file.WriteEndElement();

                    file.WriteEndElement();
                }

                file.WriteEndElement();

                file.WriteStartElement("Results");
                foreach (ScenarioResult current in listResults)
                {
                    file.WriteStartElement("Result");
                    try
                    {
                        //On Sérialise le Step en des données XML
                        XmlSerializer s = new XmlSerializer(typeof(ScenarioResult));
                        MemoryStream ms = new MemoryStream();
                        XmlTextWriter xmlTextWriter = new XmlTextWriter(ms, Encoding.Unicode);
                        s.Serialize(xmlTextWriter, current);
                        ms = (MemoryStream)xmlTextWriter.BaseStream;
                        UnicodeEncoding encoding = new UnicodeEncoding();
                        String resultString = encoding.GetString(ms.ToArray());

                        file.WriteStartElement("Datas");
                        file.WriteCData(resultString);
                        file.WriteEndElement();
                    }
                    catch(Exception e)
                    {
                        CommonProject.Tools.Trace.WriteError(e.Message);
                    }
                    file.WriteEndElement();
                }
                file.WriteEndElement();

                //fermeture Fichier
                file.WriteEndElement();
                file.Flush();
                file.Close();
            }
            catch (Exception e)
            {
                CommonProject.Tools.Trace.WriteError(e.Message);
            }
        }

        /// <summary>
        /// Charge un ficher scénario (ficher .ats)
        /// <summary>
        public void Load(String _UrlFile)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(_UrlFile);                
                reader.ReadToFollowing("Name");
                this.Name = reader.ReadString();
                reader.ReadToFollowing("IsValidate");

                if (reader.ReadString() == "True")
                {
                    this.IsValidate = true;
                }
                else
                {
                    this.IsValidate = false;
                }

                String ScenarioPath = _UrlFile.Substring(0, _UrlFile.Length - (this.Name.Length + ".ats".Length));
                this.FullPath = ScenarioPath;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Step")
                    {
                        //On lit le Type du Step enregistrer
                        reader.ReadToFollowing("Type");

                        //On instancie le XMLSerializer avec le type trouvé
                        XmlSerializer s = new XmlSerializer(Type.GetType(reader.ReadString()));
                        reader.ReadToFollowing("Datas");
                        byte[] buf = System.Text.Encoding.Unicode.GetBytes(reader.ReadString());
                        MemoryStream ms = new MemoryStream(buf);
                        this.listSteps.Add((GenericStep)s.Deserialize((Stream)ms));                        
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Result")
                    {
                        //On instancie le XMLSerializer avec le type trouvé
                        XmlSerializer s = new XmlSerializer(typeof(ScenarioResult));
                        reader.ReadToFollowing("Datas");
                        byte[] buf = System.Text.Encoding.Unicode.GetBytes(reader.ReadString());
                        MemoryStream ms = new MemoryStream(buf);
                        this.listResults.Add((ScenarioResult)s.Deserialize((Stream)ms));                        
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                CommonProject.Tools.Trace.WriteError(e.Message);
            }
        }

        #endregion

        #region Méthodes génériques

        public List<ScenarioResult> Results
        {
            get
            {
                List<ScenarioResult> results = new List<ScenarioResult>(100);
                results = listResults;
                return results;
            }
            set
            {
                if (value == null) return;
                List<ScenarioResult> result = (List<ScenarioResult>)value;
                listResults.Clear();
                foreach (ScenarioResult res in result)
                    listResults.Add(res);
            }
        }

        public override String Name
        {
            get { return parameters.Name; }
            set { parameters.Name = value; }
        }

        public String FullPath
        {
            get { return parameters.FullPath; }
            set { parameters.FullPath = value; }
        }

        public List<GenericStep> GenericSteps
        {
            get
            {

                List<GenericStep> list = new List<GenericStep>(listSteps.Capacity);
                foreach (GenericStep step in listSteps)
                {
                    list.Add((GenericStep)step.ToGeneric());

                }
                return list;
            }
        }

        public Boolean IsValidate
        {
            get { return isValidate; }
            set { isValidate = value; }
        }

        public ScenarioDatas Parameters
        {
            get { return parameters; }
        }
        #endregion
    }

}
