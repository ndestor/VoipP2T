using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Manager.IHM.Controls.BottomPanel
{
    public partial class BottomPanelView : UserControl
    {
        public BottomPanelView()
        {
           InitializeComponent();        
           tabControl1.Selecting+=new TabControlCancelEventHandler(tabControl1_Selecting);
           label1.Text=tabControl1.SelectedTab.Text;
        }

        public void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            label1.Text=((TabControl)sender).SelectedTab.Text;
        }
        public void tabControl1_Enter(Object sender,EventArgs e)
        {

        }
    }
}
