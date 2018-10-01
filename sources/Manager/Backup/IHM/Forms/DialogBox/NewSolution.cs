using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Manager.IHM.Forms.DialogBox
{
    public partial class NewSolution : Form
    {
        public NewSolution()
        {
            InitializeComponent();
            SolutionEmplacement.Text = Environment.CurrentDirectory;
        }

        private void parcourir_Click(object sender, EventArgs e)
        {
            /*
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.FileName = SolutionName.Text;
            saveFileDialog1.Filter = "Fichier Solution/scenario (*.xml)|*.xml";
            saveFileDialog1.DefaultExt = ".xml";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.ShowDialog();
             */
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Environment.CurrentDirectory;
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.ShowDialog();
            SolutionEmplacement.Text = folderBrowserDialog1.SelectedPath;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void oK_Click(object sender, EventArgs e)
        {
            Scenario.SolutionDatas datas = new Manager.Scenario.SolutionDatas(SolutionName.Text, SolutionEmplacement.Text);

            if (MainEntry.scenarioSolution != null)
            {
                DialogBox.CloseSolution form = new Manager.IHM.Forms.DialogBox.CloseSolution();
                form.Owner = this;
                form.Tag = datas;               
                form.ShowDialog();
            }
            else
            {
                MainEntry.scenarioSolution = new Manager.Scenario.ScenarioSolution(datas);
                MainEntry._ScenarioEvents.OnNewScenarioSolution(MainEntry.scenarioSolution, null);                
            }

            this.Close();
        }        
    }
}