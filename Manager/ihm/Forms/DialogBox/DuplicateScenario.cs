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
    public partial class DuplicateScenario : Form
    {
        Scenario.Datas.Scenario mainScenario = new Scenario.Datas.Scenario();

        public DuplicateScenario(Scenario.Datas.Scenario _scenario)
        {
            mainScenario = _scenario;
            InitializeComponent();
        }

        private void oK_Click(object sender, EventArgs e)
        {
            Scenario.Datas.ScenarioDatas datas = new Scenario.Datas.ScenarioDatas(ScenarioName.Text, MainEntry.scenarioSolution.FullPath);
            Scenario.Datas.Scenario duplicateScenario = new Scenario.Datas.Scenario(datas);
            duplicateScenario.Steps = mainScenario.Steps;

            Boolean distinctName = true;
            foreach (Scenario.Datas.Scenario currentScenario in MainEntry.scenarioSolution.Scenarios)
            {
                if (currentScenario.Name == duplicateScenario.Name)
                {
                    distinctName = false;
                }
            }
            if (distinctName)
            {
                MainEntry.scenarioSolution.AddScenario(duplicateScenario);            
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ce nom existe déjà! Veuillez le changer.",
                  "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}