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