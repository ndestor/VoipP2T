using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using CommonProject.Scenario.ResultDatas;
using CommonProject.Scenario.Datas;

using Manager.Scenario.ResultDatas;

namespace Manager.IHM.Controls.MainPanel.ResultsPanel
{
    public partial class ResultCtrlPanel : UserControl
    {
        private string[] images = new string[] { "smallsuccess.gif", "smallfail.gif", "Warn.gif" };
        ScenarioResult result;

        private int currentIndexTabPage;
        public ResultCtrlPanel()
        {
            InitializeComponent();
          
        }

        public ResultCtrlPanel(ScenarioResult result, int _tabPageIndex)
        {
            InitializeComponent();

            currentIndexTabPage = _tabPageIndex;

            // Initialize the ImageList objects with bitmaps.
            System.IO.Stream streamBmp = null;
            ImageList imageListSmall = new ImageList();

            foreach (string name in images)
            {
                //On récupère l'assembly en cours d'exécution
                streamBmp = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Manager.Resources." + name);

                //Chargement du fichier bitmap en mémoire depuis les ressources             
                if (streamBmp != null)
                {
                    imageListSmall.Images.Add(Bitmap.FromStream(streamBmp));
                }
            }
            //Assign the ImageList objects to the ListView.
            listView1.SmallImageList = imageListSmall;

            listView1.SelectedIndexChanged+=new EventHandler(listView1_SelectedIndexChanged);

            //Enregistrement aux événements
            MainEntry._ScenarioEvents.CloseScenarioResult += new Manager.Scenario._CloseScenarioResult(_ScenarioEvents_CloseScenarioResult);

           // listView1.VirtualItemsSelectionRangeChanged+=new ListViewVirtualItemsSelectionRangeChangedEventHandler(listView1_VirtualItemsSelectionRangeChanged);
            DisplayResult(result);
        }

        private void DisplayResult(ScenarioResult _result)
        {

            listView1.Items.Clear();

            result=_result;

            Scenario.Datas.Scenario scenario = new Scenario.Datas.Scenario();
            scenario = MainEntry.scenarioSolution.Scenarios[result.IdScenario];

            scenarioNameLabel.Text = scenario.Name;
            dateLabel.Text = result.BeginTime.ToString();
            if (result.HasCrashed)
            {
                generalResultLabel.Text = "Echec de la lecture du scenario";
            }
            else
            {
                generalResultLabel.Text = "Lecture terminée avec succés";
            }

            numberStepPlayedLabel.Text = result.StepsResults.Length.ToString();

            foreach(StepResult stepResult in result.StepsResults)
            {
                 //Récupération du step associé 
                GenericStep step = scenario.Steps[stepResult.NumStep];

                ListViewItem item1 = new ListViewItem("", Convert.ToInt16(stepResult.Status));                
                item1.SubItems.Add(((StepsName)stepResult.NameId).ToString());
                item1.SubItems.Add(step.TesterSource + "   --->   " + step.TesterDestination);
                item1.SubItems.Add(stepResult.Msg);
                item1.Name = step.NumStep.ToString();
                
                //Ajout du step
                listView1.Items.Add(item1);
            }
            if (result.StepsResults.Length != 0)
            {
                steplabelDesc.Text = "n°" + (result.StepsResults[0].NumStep + 1) + ": " + ((StepsName)result.StepsResults[0].NameId).ToString();
                

                foreach (String currentMsg in result.StepsResults[0].TestersResults[0].Msg)
                {
                    logsSource.Text += "Log: " + currentMsg + System.Environment.NewLine;
                }

                foreach (String currentMsg in result.StepsResults[0].TestersResults[1].Msg)
                {
                    logsDestination.Text += "Log: " + currentMsg + System.Environment.NewLine;
                }
            }

            CommentsTextBox.Text = result.Comments;
        }

        private void listView1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            int index=0;
            foreach (ListViewItem tempListViewItem in listView1.SelectedItems)
            {
                index = tempListViewItem.Index;
            }

            StepResult currentStep =result.StepsResults[(Int16)index]; 
           //Mise à jours des du TextBox du testeur source

            steplabelDesc.Text = "n°" + (result.StepsResults[0].NumStep + 1) + ": " + ((StepsName)result.StepsResults[0].NameId).ToString();
            logsSource.Text = "";
            logsDestination.Text = "";
            foreach(String currentMsg in currentStep.TestersResults[0].Msg)
            {
                logsSource.Text += "Log: " + currentMsg + System.Environment.NewLine;
            }

            foreach (String currentMsg in currentStep.TestersResults[1].Msg)
            {
                logsDestination.Text +="Log: "+ currentMsg + System.Environment.NewLine;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            MainEntry._ScenarioEvents.OnCloseScenarioResult(currentIndexTabPage, null);
        }

        private void _ScenarioEvents_CloseScenarioResult(int _IndexTabPage, EventArgs e)
        {
            if (_IndexTabPage < currentIndexTabPage)
            {
                currentIndexTabPage = currentIndexTabPage - 1;
            }
        }


        private void CommentLabel_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CommentsTextBox.ReadOnly)
            {
                CommentsTextBox.ReadOnly = false;
                CommentLabel.Text = "Valider";
            }
            else
            {
                CommentsTextBox.ReadOnly = true;
                CommentLabel.Text = "Modifier";
                result.Comments = CommentsTextBox.Text;
            }
            
        }
    }
}
