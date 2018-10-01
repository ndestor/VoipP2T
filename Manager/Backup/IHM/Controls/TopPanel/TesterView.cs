using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

using CommonProject.Communication;
using CommonProject.Tools;

namespace Manager.IHM.Controls
{


    public partial class TesterView : UserControl
    {
        //Variable de la classe
        private Hashtable listLabels = new Hashtable();
        private Hashtable listRadiobuttons= new Hashtable();

        private delegate void TesterPanelUpdateHandler(GenericTcpCore sender);
        private TesterPanelUpdateHandler TesterPanelUpdate;

        public TesterView()
        {    
            //Initialisation système 
            InitializeComponent();
            //Initialisation des controls de la classe (RadioButtons et Labels) 
            InitializeControls();            
            //On s'enregistre aux événements TCP
            MainEntry._TcpEvents.TcpNetworkStatusEvent += new _TcpNetworkStatusHandler(_TcpEvents_TcpNetworkStatusEvent);

            TesterPanelUpdate = new TesterPanelUpdateHandler(UpdateTesterPanel);
        }

        private void InitializeControls()
        {
            Int16 number;

            foreach (Control ctrl in this.groupBox1.Controls)
            {
                if (ctrl is Label)
                {
                    number = Convert.ToInt16(ctrl.Name.Substring("label".Length));
                    listLabels.Add(number-1, ctrl);
                }
                if (ctrl is RadioButton)
                {
                    number = Convert.ToInt16(ctrl.Name.Substring("radioButton".Length));
                    listRadiobuttons.Add(number-1, ctrl);
                }
            }
                  
            for (int i = 0; i < listRadiobuttons.Count; i++)
            {
                RadioButton radioButtonEnCours = (RadioButton)listRadiobuttons[i];               
                radioButtonEnCours.Click += new EventHandler(Onclickradiobutton);
            }

            for (int i = 0; i < MainEntry.listTesters.Tester.Length; i++)
            {           
                if (MainEntry.listTesters.Tester[i].IsConnected)
                {
                    ((Label)listLabels[i]).Text = "Connecté";
                }
                if (!MainEntry.listTesters.Tester[i].IsConnected)
                {
                    ((Label)listLabels[i]).Text = "Déconnecté";
                }               
            }
          
            radioButton1.Checked = true;
            testerName.Text = MainEntry.listTesters.GetNameFromId(0);
            
        }


        //Evénement lorsque le status de connection TCP d'un testeur change
        private void _TcpEvents_TcpNetworkStatusEvent(Object sender, EventArgs e)
        {
            GenericTcpCore tester = (GenericTcpCore)sender;         
            this.Invoke(TesterPanelUpdate, (GenericTcpCore)sender);
        }

        private void Onclickradiobutton(Object sender, EventArgs e) 
        {
            RadioButton RealSender = (RadioButton)sender;
            Int16 number = Convert.ToInt16(RealSender.Name.Substring("radioButton".Length));
            number--;
            testerName.Text = MainEntry.listTesters.GetNameFromId(number);
        }


        private void Onconnect_Click(object sender, EventArgs e)
        {       
            Int32 num=MainEntry.listTesters.GetIdFromName(testerName.Text);           
            MainEntry.listTesters.Tester[num].ConnectToTester();      
        }

        private void UpdateTesterPanel(GenericTcpCore _sender)
        {
            MsgTextBox.Text = _sender.Msg;
            Int32 number= Convert.ToInt32(MainEntry.listTesters.GetIdFromName(_sender.Name));
            if (_sender.IsConnected)
            {
                ((Label)this.listLabels[number]).Text = "Connecté";
            }
            else
            {
                ((Label)this.listLabels[number]).Text = "Déconnecté";              
            }            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           

            //MsgTextBox.Text = tester.Msg;*/
            MsgTextBox.Clear();
        }
    }
}