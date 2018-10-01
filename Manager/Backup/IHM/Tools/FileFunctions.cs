using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Manager.IHM.Tools
{
    public class FileFunctions
    {
        /// <summary>
        //Fonction chargement de fichier
        /// <summary>  
        public static void LoadFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
           
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter = "Fichier scenario (*.ats)|*.ats|Fichier solution (*.atp)|*.atp";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                String extension = openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4);
                if (extension == ".atp")
                {
                    if (MainEntry.scenarioSolution != null)
                    {
                        if (MessageBox.Show(" La solution actuelle va être fermée. Voulez-vous enregistrer les modifications apportées à la solution actuelle ?",
                            "Enregistrer la solution",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            MainEntry.scenarioSolution.SaveSolution();
                        }
                    }

                    MainEntry.scenarioSolution = new Manager.Scenario.ScenarioSolution(openFileDialog1.FileName);
                    MainEntry._ScenarioEvents.OnNewScenarioSolution(MainEntry.scenarioSolution, null);
                }

                if (extension == ".ats")
                {
                    if (MainEntry.scenarioSolution == null)
                    {
                        MessageBox.Show("Ouverture impossible! Veuillez auparavant ouvrir une solution.",
                            "Ouverture de scenario",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MainEntry.scenarioSolution.AddScenario(new Manager.Scenario.Datas.Scenario(openFileDialog1.FileName));
                    }
                }
            }
        }
    }
}
