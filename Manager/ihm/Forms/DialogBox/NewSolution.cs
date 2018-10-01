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