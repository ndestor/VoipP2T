using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Manager.IHM.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SaveToolStripbutton.Enabled = false;
            enregisterToolStripMenuItem.Enabled = false;

            MainEntry._ScenarioEvents.NewRecordableDatas += new EventHandler(_ScenarioEvents_NewRecordableDatas);
        }

        private void scenarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogBox.NewSolution form = new DialogBox.NewSolution();
            form.Owner = this;
            form.ShowDialog();		
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MainEntry.scenarioSolution != null)
            {
                MainEntry.scenarioSolution.SaveSolution();
            }
        }

        private void ouvrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tools.FileFunctions.LoadFile();
        }

        private void OpenFileToolStrip_Click(object sender, EventArgs e)
        {
            Tools.FileFunctions.LoadFile();
        }

        //Mise à jour du bouton "SaveToolStripbutton" et dans le menu Fichier de  "enregisterToolStripMenuItem"
        private void _ScenarioEvents_NewRecordableDatas(object sender, EventArgs e)
        {
            if (sender != null)
            {

                if (sender.GetType().Equals(typeof(Scenario.ScenarioSolution)))
                {
                    SaveToolStripbutton.Enabled = true;
                    SaveToolStripbutton.Text = "Enregistrer la solution " + MainEntry.scenarioSolution.Name;
                    SaveToolStripbutton.Tag = sender;

                    enregisterToolStripMenuItem.Enabled = true;
                    enregisterToolStripMenuItem.Text = "Enregistrer la solution " + MainEntry.scenarioSolution.Name;
                    enregisterToolStripMenuItem.Tag = sender;
                }

                else if (sender.GetType().Equals(typeof(Scenario.Datas.Scenario)))
                {
                    SaveToolStripbutton.Enabled = true;
                    SaveToolStripbutton.Text = "Enregistrer le scenario " + MainEntry.scenarioSolution.CurrentScenario.Name;
                    SaveToolStripbutton.Tag = sender;

                    enregisterToolStripMenuItem.Enabled = true;
                    enregisterToolStripMenuItem.Text = "Enregistrer le scenario " + MainEntry.scenarioSolution.CurrentScenario.Name;
                    enregisterToolStripMenuItem.Tag = sender;
                }
            }
            else
            {
                SaveToolStripbutton.Enabled = false;
                enregisterToolStripMenuItem.Enabled = false;
            }
        }

        private void SaveToolStripbutton_Click(object sender, EventArgs e)
        {
            if (((ToolStripButton)sender).Tag.GetType().Equals(typeof(Scenario.ScenarioSolution)))
            {
                ((Scenario.ScenarioSolution)((ToolStripButton)sender).Tag).SaveSolution();
            }
            else if (((ToolStripButton)sender).Tag.GetType().Equals(typeof(Scenario.Datas.Scenario)))
            {
                ((Scenario.Datas.Scenario)((ToolStripButton)sender).Tag).Save();
            }
        }

        private void enregisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Tag.GetType().Equals(typeof(Scenario.ScenarioSolution)))
            {
                ((Scenario.ScenarioSolution)((ToolStripMenuItem)sender).Tag).SaveSolution();
            }
            else if (((ToolStripMenuItem)sender).Tag.GetType().Equals(typeof(Scenario.Datas.Scenario)))
            {
                ((Scenario.Datas.Scenario)((ToolStripMenuItem)sender).Tag).Save();
            }
        }

        private void newSolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogBox.NewSolution form = new DialogBox.NewSolution();
            form.Owner = this;
            form.ShowDialog();	
        }

        private void newScenarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MainEntry.scenarioSolution == null)
            {
                MessageBox.Show("Création d'un nouveau scenario impossible! Veuillez auparavant ouvrir ou créer une solution.",
                          "Création dec scenario",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Forms.DialogBox.NewScenario form = new Forms.DialogBox.NewScenario();
                form.Owner = MainEntry.ihm;
                form.ShowDialog();
            }
        }

       
    }
}