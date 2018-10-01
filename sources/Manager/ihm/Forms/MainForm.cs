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