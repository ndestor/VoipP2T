using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Manager.IHM.Forms.DialogBox
{
    public partial class CloseSolution : Form
    {
        public CloseSolution()
        {
            InitializeComponent();
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void oui_Click(object sender, EventArgs e)
        {
            /****** Souvegarde de la solution actuelle  ******/
            
            /****** Création de la nouvelle solution  ******/
            MainEntry.scenarioSolution = new Manager.Scenario.ScenarioSolution((Scenario.SolutionDatas)Tag);
            MainEntry._ScenarioEvents.OnNewScenarioSolution(MainEntry.scenarioSolution, null);

            this.Close();
        }

        private void non_Click(object sender, EventArgs e)
        {
            /****** Création de la nouvelle solution  ******/
            MainEntry.scenarioSolution = new Manager.Scenario.ScenarioSolution((Scenario.SolutionDatas)Tag);
            MainEntry._ScenarioEvents.OnNewScenarioSolution(MainEntry.scenarioSolution, null);

            this.Close();
        }       
    }
}