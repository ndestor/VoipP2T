using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.Collections;

namespace Manager.Scenario
{
    /// <summary>
    /// Classe permettant de caractériser une solution
    /// </summary>rioPlayer
    class SolutionDatas
    {
        private String name;
        private String fullPath;

        public SolutionDatas()
        {
        }

        public SolutionDatas (String _name,String _directory)
        {
            name = _name;
            fullPath = _directory;           
        }

        [CategoryAttribute("Générales"), DescriptionAttribute("Nom du fichier solution")]
        [DisplayName("(Nom)")]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        [CategoryAttribute("Générales"), DescriptionAttribute("Chemin d'accès au fichier solution")]        
        [DisplayName("Chemin d'accés")]
        public String FullPath
        {
            get { return fullPath; }
            set { fullPath = value; }
        }
    }

    /// <summary>
    /// Classe définissant une solution
    /// </summary>
    class ScenarioSolution
    {
        private SolutionDatas parameters = new SolutionDatas();

        List<Int16> listScenarioToPlay = new List<Int16>();

        //Declaration d'une liste contenant les Scenarios
        private List<Datas.Scenario> listScenarios = new List<Datas.Scenario>();

        public Int16 currentScenario=-1;
        public Int16 selectedScenario;

        /// <summary>
        /// Constructeur 
        /// </summary>
        public ScenarioSolution()
        {
            currentScenario = 0;
            selectedScenario = 0;
        }

        /// <summary>
        /// Constructeur acceptant en entrée un objet caractérisant une solution
        /// </summary>
        public ScenarioSolution(SolutionDatas _datas)
        {
            parameters = _datas;
            this.SaveSolution();
        }

        /// <summary>
        /// Constructeur acceptant en entrée l'url d'un fichier solution (.ats)
        /// </summary>
        public ScenarioSolution(String _UrlFile)
        {
            this.Load(_UrlFile);
        }

        /// <summary>
        /// Retourne les caractéristiques ou propriétés d'une solution
        /// </summary>
        public SolutionDatas Parameters
        {
            get { return parameters; }
        }

        /// <summary>
        /// Retourne l'ensemble des scénarios constituant la solution
        /// </summary>
        public Datas.Scenario[] Scenarios
        {
            get
            {
                Datas.Scenario[] scenarios = new Datas.Scenario[listScenarios.Count];
                listScenarios.CopyTo(scenarios);
                return scenarios;
            }
            set
            {
                if (value == null) return;
                Datas.Scenario[] scenarios = (Datas.Scenario[])value;
                listScenarios.Clear();
                foreach (Datas.Scenario scenario in scenarios)
                    listScenarios.Add(scenario);
            }
        }

        /// <summary>
        /// Retourne l'ensemble des scénarios à jouer
        /// </summary>
        public List<Datas.Scenario> ScenariosToPlay
        {
            get
            {
                List<Datas.Scenario> tempList = new List<Datas.Scenario>(listScenarios.Count);             
                foreach(Int16 idScenario in listScenarioToPlay)
                {                                          
                   tempList.Add(listScenarios[idScenario]);                    
                }
                return tempList;
            }            
        }

        /// <summary>
        /// Retourne le dernier scénario de la liste
        /// </summary>
        public Datas.Scenario GetLastScenario()
        {
            return this.Scenarios[(listScenarios.Count - 1)];
        }

        /// <summary>
        /// Retourne un scénario à partir de son identifiant
        /// </summary>
        public Datas.Scenario GetScenarioFromId(int id)
        {
            for (int i = 0; i <= this.GetLastScenario().Id; i++)
            {
                if (this.Scenarios[i].Id == id)
                {
                    return this.Scenarios[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Ajoute un scénario à la solution
        /// </summary>
        public void AddScenario(Datas.Scenario s)
        {
            s.Id = (short)listScenarios.Count;
            listScenarios.Add(s); 
            MainEntry._ScenarioEvents.OnNewScenario(s, null);
        }

        /// <summary>
        /// Supprime un scénario de la solution
        /// </summary>
        public void RemoveScenario(int index)
        {
            System.IO.File.Delete(listScenarios[index].FullPath+"\\"+listScenarios[index].Name+".ats");

            foreach (Datas.Scenario current in listScenarios)
            {
                if (current.Id > listScenarios[index].Id)
                {
                    current.Id = Convert.ToInt16(current.Id -1);
                }
            }
            this.listScenarios.RemoveAt(index);
            this.currentScenario = -1;
        }

        /// <summary>
        /// Retourne un scénario à partir de son nom
        /// </summary>
        public Datas.Scenario GetScenarioFromName(String name)
        {
            foreach (Datas.Scenario current in this.listScenarios)
            {
                if (current.Name == name)
                {
                    return current;
                }
            }
            return null;
        }

        /// <summary>
        /// Retourne l'identifiant du scénario à partir de son nom
        /// </summary>
        public Int16 GetScenarioIdFromName(string name)
        {
            Datas.Scenario current = new Datas.Scenario();
            current = GetScenarioFromName(name);
            return current.Id;
        }

        /// <summary>
        /// Retourne le nom de la soltuion
        /// </summary>
        public String Name
        {
            get { return parameters.Name; }
            set { parameters.Name = value; }
        }

        /// <summary>
        /// Retourne l'emplacement sur le disque de la solution
        /// </summary>
        public String FullPath
        {
            get { return parameters.FullPath; }
            set { parameters.FullPath = value; }
        }

        /// <summary>
        /// Retourne le scénario courant de l'IHM
        /// </summary>
        public Datas.Scenario CurrentScenario
        {
            get {
                if (currentScenario != -1)
                {
                    return listScenarios[currentScenario];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Retourne le scénario en cours de sélection dans l'IHM
        /// </summary>
        public Datas.Scenario SelectedScenario
        {
            get { return listScenarios[selectedScenario]; }
        }

        /// <summary>
        /// Charge la solution à partir d'un fichier
        /// </summary>
        public void Load(string _UrlFile)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(_UrlFile);

                reader.ReadToFollowing("Name");
                this.Name = reader.ReadString();
                String SolutionPath = _UrlFile.Substring(0, _UrlFile.Length - (this.Name.Length + ".atp".Length));
                this.FullPath = SolutionPath;             

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Scenario")
                    {
                        Datas.Scenario s = new Datas.Scenario(this.FullPath + "\\" + reader.ReadString() + ".ats");
                        s.Id = (Int16)listScenarios.Count;
                        listScenarios.Add(s);
                        s = null;
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                CommonProject.Tools.Trace.WriteError(e.Message);
            }
        }

        /// <summary>
        /// Sauvegarde la solution 
        /// </summary>
        public void SaveSolution()
        {
            try
            {

            /***** Creation du fichier XML *****/
             //Creation du fichier XML - Declaration XML

                Console.WriteLine("Save Solution");
                XmlTextWriter file = new XmlTextWriter(this.FullPath + "\\" + this.Name + ".atp", System.Text.Encoding.UTF8);
                //mise en Forme pour l'indentation
                file.Formatting = System.Xml.Formatting.Indented;
                file.Indentation = 2;
             
               
                //Debut du fichier xml
                file.WriteStartDocument();
                //Commentaire
               
                file.WriteComment("Fichier de configuration du Manager - Automate de Tests V1.0");
                //Creation de l'élément racine du fichier
                file.WriteStartElement("Solution");

                //Paramètre générals
                file.WriteElementString("Name", this.Name);
                file.WriteElementString("FullPath", this.FullPath);

                file.WriteStartElement("Scenarios");

                foreach (Datas.Scenario current in listScenarios)
                {
                    file.WriteElementString("Scenario", current.Name);
                    current.Save();
                }
                file.WriteEndElement();
                //fermeture Fichier
                file.WriteEndElement();
                file.Flush();
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Ajoute un scénario à la liste de lecture
        /// </summary>
        public void AddScenarioToPlayer(Datas.Scenario s)
        {
           listScenarioToPlay.Add(s.Id);
           MainEntry._ScenarioEvents.OnNewScenarioToPlay(s, null);
           
        }

        /// <summary>
        /// Supprime un scénario à la liste de lecture
        /// </summary>
        public void RemoveScenarioToPlayer(Int16 index)
        {
            listScenarioToPlay.RemoveAt(index);
        }

        /// <summary>
        /// Intervertit deux scénarios à jouer dans la liste de lecture
        /// </summary>
        public void InvertIndexToPlay(Int16 index1, Int16 index2)
        {
            Int16 tempId = listScenarioToPlay[index1];
            listScenarioToPlay[index1] = listScenarioToPlay[index2];
            listScenarioToPlay[index2] = tempId;
        }
    }
}
