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

using System.Collections;

using Manager.Scenario.Datas.Steps;
using Manager.Scenario.Datas;
using CommonProject.Scenario.Datas;


namespace Manager.IHM.Forms.DialogBox
{
    public partial class NewStep : Form
    {
        public NewStep()
        {
            InitializeComponent();

            /******** Instanciation du TreeView *********/
            treeView1.Nodes.Add("Step de base");
            foreach (StepsName item in Enum.GetValues(typeof(StepsName))) 
            {
                TreeNode itemTreeNode = new TreeNode(item.ToString());
                itemTreeNode.Name=item.ToString();
                switch (item)
                {
                    case StepsName.Appel:
                        {
                            CallStep action = new CallStep();                            
                            itemTreeNode.Tag = action;
                            break;
                        }
                    case StepsName.Attente:
                        {
                            WaitStep action = new WaitStep();
                            itemTreeNode.Tag = action;
                            break;
                        }
                    case StepsName.DTMF:
                        {
                            DTMFStep action = new DTMFStep();
                            itemTreeNode.Tag = action;
                            break;
                        }
                    case StepsName.Raccrochage:
                        {
                            HangupStep action = new HangupStep();
                            itemTreeNode.Tag = action;
                            break;
                        }
                    default : break;
                }
                treeView1.Nodes[0].Nodes.Add(itemTreeNode);
               // treeView1.Nodes[0].Tag
            }            
            treeView1.ExpandAll();
            treeView1.MouseClick+=new MouseEventHandler(treeView1_MouseClick);

            
        }

        private void treeView1_MouseClick(Object sender, MouseEventArgs e)
        {
            Object parameters = ((TreeNode)treeView1.GetNodeAt(e.X, e.Y)).Tag;
          
           propertyGrid1.SelectedObject = parameters;
            
            propertyGrid1.Update();
        }

        private void oK_Click(object sender, EventArgs e)
        {    
            if (treeView1.SelectedNode.Level!=0)
            {
                MainEntry.scenarioSolution.CurrentScenario.AddStep((GenericStep)treeView1.SelectedNode.Tag);
                this.Close();
            }           
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}