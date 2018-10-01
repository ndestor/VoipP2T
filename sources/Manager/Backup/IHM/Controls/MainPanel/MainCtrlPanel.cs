using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using Manager.Scenario.ResultDatas;

namespace Manager.IHM.Controls.MainPanel
{


    public partial class MainCtrlPanel : UserControl
    {
        private ScenarioResult result;
        private TabPage newTabPage;
        ResultsPanel.ResultCtrlPanel newTabResult;


        private delegate void TabControlUpdateHandler();
        private TabControlUpdateHandler TabControlupdate;

        public MainCtrlPanel()
        {   
            InitializeComponent();
            MainEntry._ScenarioEvents.NewScenarioResultToView += new EventHandler(_ScenarioEvents_NewScenarioResultToView);
            MainEntry._ScenarioEvents.CloseScenarioResult+=new Manager.Scenario._CloseScenarioResult(_ScenarioEvents_CloseScenarioResult);
            TabControlupdate = new TabControlUpdateHandler(UpdateTabPage);

           
        }

        private void _ScenarioEvents_NewScenarioResultToView(Object sender, EventArgs e)
        {           

            newTabPage = new TabPage(((ScenarioResult)sender).BeginTime.ToString());
           
            result = new ScenarioResult();
            ScenarioResult current = (ScenarioResult)sender;

            newTabResult = new Manager.IHM.Controls.MainPanel.ResultsPanel.ResultCtrlPanel((ScenarioResult)sender, tabControl1.TabPages.Count);
            newTabResult.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            newTabPage.Controls.Add(newTabResult);
            newTabPage.AutoScroll = true;


            this.Invoke(this.TabControlupdate);
            
        }

        private void _ScenarioEvents_CloseScenarioResult(int _IndexTabPage, EventArgs e)
        {
            tabControl1.TabPages.RemoveAt(_IndexTabPage);
        }

        private void UpdateTabPage()
        {        
            tabControl1.TabPages.Add(newTabPage);
        }

      
    }
}
