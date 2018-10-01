using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Manager.IHM.Forms.DialogBox
{
    public partial class NewScenario : Form
    {
        public NewScenario()
        {
            InitializeComponent();
        }
       
        private void oK_Click(object sender, EventArgs e)
        {
            Scenario.Datas.ScenarioDatas datas = new Scenario.Datas.ScenarioDatas(ScenarioName.Text, MainEntry.scenarioSolution.FullPath);
            Scenario.Datas.Scenario newScenario = new Scenario.Datas.Scenario(datas);

            Boolean distinctName = true;
            foreach (Scenario.Datas.Scenario currentScenario in MainEntry.scenarioSolution.Scenarios)
            {
                if (currentScenario.Name == newScenario.Name)
                {
                    distinctName = false;
                }
            }
            if (distinctName)
            {
                MainEntry.scenarioSolution.AddScenario(newScenario);
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