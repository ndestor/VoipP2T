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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Manager.Scenario;

using CommonProject.Scenario.Datas;
using CommonProject.Scenario.ResultDatas;
using CommonProject.Tools;


namespace Manager.IHM.Controls.LeftPanel
{
    public partial class LeftPanelView : UserControl
    {
        private string[] icones = new string[] { "closedDirectory.ico", "openDirectory.ico", "step.ico", "document.ico", "App.ico" };
        private ImageList iconesList = new ImageList();
        //Variable récupérant l'index du Node selectionné lors d'un clic droit
        private TreeNode currentNode;
        private TreeNode currentScenarioTreeNode;
        private TreeNode solutionTreeNode;


        private delegate void TreeViewResultUpdateHandler(TreeNode _treeNode, Int16 _idScenario);
        private TreeViewResultUpdateHandler treeViewResultUpdate;

        public LeftPanelView()
        {
            InitializeComponent();

            /******* Select icons into the image list *******/
            foreach (string current in icones)
            {
                //On récupère l'assembly en cours d'exécution
                System.IO.Stream streamIco = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Manager.Resources." + current);

                //Chargement du fichier bitmap en mémoire depuis les ressources             
                if (streamIco != null)
                {
                    iconesList.Images.Add(new Icon(streamIco));
                }
            }
            //Assign the ImageList objects to the ListView.
            treeView1.ImageList = iconesList;
            treeView1.MouseClick += new MouseEventHandler(treeView1_MouseClick);
            //treeView1.Validated+=new EventHandler(treeView1_Validated);
            treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);

            /******* Enregistrement aux événements  *******/
            MainEntry._ScenarioEvents.NewScenarioSolution += new EventHandler(_ScenarioEvents_NewScenarioSolution);
            MainEntry._ScenarioEvents.NewScenario += new EventHandler(_ScenarioEvents_NewScenario);
            MainEntry._ScenarioEvents.NewScenarioResult += new EventHandler(_ScenarioEvents_NewScenarioResult);
            MainEntry._ScenarioEvents.NewStep += new EventHandler(_ScenarioEvents_NewStep);

            treeViewResultUpdate = new TreeViewResultUpdateHandler(UpdateTreeViewResult);

        }

        #region Private functions

        private void treeView1_AfterSelect(Object sender, TreeViewEventArgs e)
        {
            //Mise à jour du propertyGrid
            propertyGrid1.SelectedObject = e.Node.Tag;
            if (MainEntry.scenarioSolution.CurrentScenario != null && MainEntry.scenarioSolution.CurrentScenario.IsValidate)
            {
                propertyGrid1.Enabled = false;
            }
            else
            {
                propertyGrid1.Enabled = true;
            }
        }

        //Mise  à jour du CurrentScenario
        private void treeView1_MouseClick(Object sender, MouseEventArgs e)
        {
            TreeNode current = (TreeNode)treeView1.GetNodeAt(e.X, e.Y);
            if (current.Level == 3)
            {
                MainEntry.scenarioSolution.currentScenario = Convert.ToInt16(current.Parent.Parent.Name);
                currentScenarioTreeNode = current.Parent.Parent;

            }
            else if (current.Level == 2)
            {

                MainEntry.scenarioSolution.currentScenario = Convert.ToInt16(current.Parent.Name);           
                currentScenarioTreeNode = current.Parent;
            }
            else if (current.Level == 1)
            {
                MainEntry.scenarioSolution.currentScenario = Convert.ToInt16(current.Name);
                currentScenarioTreeNode = current;
            }

            //Déclenchement de NewRecordableDatas si données enregistrable
            if (e.Button == MouseButtons.Left)
            {
                //l'utilisateur à cliqué sur la solution
                if (current.Level == 0)
                {
                    MainEntry._ScenarioEvents.OnNewRecordableDatas(MainEntry.scenarioSolution, null);
                }
                //l'utilisateur à cliqué sur un scenario
                else if (current.Level == 1)
                {
                    if (MainEntry.scenarioSolution.CurrentScenario != null)
                    {
                        MainEntry._ScenarioEvents.OnNewRecordableDatas(MainEntry.scenarioSolution.CurrentScenario, null);
                    }
                }
                else
                {
                    MainEntry._ScenarioEvents.OnNewRecordableDatas(null, null);
                }
            }

            currentNode = (TreeNode)treeView1.GetNodeAt(e.X, e.Y);
        }

        #endregion

        #region Events

        private void _ScenarioEvents_NewScenarioSolution(Object sender, EventArgs e)
        {
            /******* Suppresion des éléments du Treeview *******/
            if (treeView1.Nodes.Count != 0)
            {
                treeView1.Nodes[0].Remove();
            }
            /******* Création de la branche racine - solution *******/
            String name = "Solution '" + MainEntry.scenarioSolution.Name + "'";
            solutionTreeNode = new TreeNode(name, 4, 4);
            solutionTreeNode.ContextMenuStrip = solutionMenuStrip;
            solutionTreeNode.Tag = MainEntry.scenarioSolution.Parameters;

            treeView1.Nodes.Add(solutionTreeNode);

            //Test pour savoir si il y a des éléments fils
            foreach (Scenario.Datas.Scenario scenario in MainEntry.scenarioSolution.Scenarios)
            {
                MainEntry._ScenarioEvents.OnNewScenario(scenario, null);               
            }
        }

        private void _ScenarioEvents_NewScenario(Object sender, EventArgs e)
        {
            /******* Ajout du nouveau scenario au TreeView *******/
            Scenario.Datas.Scenario newScenario = (Scenario.Datas.Scenario)sender;

            /******* Création de la branche Scenario *******/
            TreeNode scenarioTreeNode = solutionTreeNode.Nodes.Add(newScenario.Id.ToString(), newScenario.Name, 0, 1);
            scenarioTreeNode.Name = newScenario.Id.ToString();
            scenarioTreeNode.Tag = newScenario.Parameters;
            scenarioTreeNode.ContextMenuStrip = scenarioMenuStrip;

            /******* Création de la branche Steps *******/
            TreeNode stepsTreeNode = scenarioTreeNode.Nodes.Add("Steps", "Steps", 0, 1);
            stepsTreeNode.ContextMenuStrip = stepsMenuStrip;

            /******* Création de la branche Résultat  *******/
            TreeNode resultsTreeNode = scenarioTreeNode.Nodes.Add("Results", "Resultats", 0, 1);

            /******* Indique le nouveau scenario actuelle *******/
            MainEntry.scenarioSolution.currentScenario = newScenario.Id;

            /******* Test pour savoir si il y a des éléments fils *******/
            foreach (CommonProject.Scenario.Datas.GenericStep step in newScenario.Steps)
            {
                MainEntry._ScenarioEvents.OnNewStep(step, null);
            }
            foreach (Scenario.ResultDatas.ScenarioResult result in newScenario.Results)
            {
                MainEntry._ScenarioEvents.OnNewScenarioResult(result, null);
            }

            /******* Si scenario validé, le mettre en gras *******/
            if (newScenario.IsValidate)
            {
                scenarioTreeNode.NodeFont = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            }
        }

        private void _ScenarioEvents_NewStep(Object sender, EventArgs e)
        {
            GenericStep newStep = (CommonProject.Scenario.Datas.GenericStep)sender;
            TreeNode newTreeNode = new TreeNode(newStep.NumStep + 1 + "- " + ((StepsName)newStep.NameId).ToString(), 2, 2);
            newTreeNode.Name = newStep.NumStep.ToString();
            newTreeNode.ContextMenuStrip = ActionMenuStrip;
            newTreeNode.Tag = newStep;
            solutionTreeNode.Nodes[MainEntry.scenarioSolution.CurrentScenario.Id].Nodes[0].Nodes.Add(newTreeNode);
        }

        private void _ScenarioEvents_NewScenarioResult(Object sender, EventArgs e)
        {
            Scenario.ResultDatas.ScenarioResult newResult = (Scenario.ResultDatas.ScenarioResult)sender;
            TreeNode newTreeNode = new TreeNode(newResult.BeginTime.ToString(), 3, 3);
            newTreeNode.Tag = newResult;
            newTreeNode.ContextMenuStrip = ResultMenuStrip;
            this.Invoke(treeViewResultUpdate, newTreeNode, MainEntry.scenarioSolution.Scenarios[newResult.IdScenario].Id);
        }

        private void UpdateTreeViewResult(TreeNode _treeNode, Int16 _idScenario)
        {
            solutionTreeNode.Nodes[_idScenario].Nodes[1].Nodes.Add(_treeNode);
        }

        #endregion

        #region ContextMenus Solution
        //Fonctions propres du ContextMenu de la branche solution
        private void NewScenarioSolutionItem1_Click(object sender, EventArgs e)
        {
            Forms.DialogBox.NewScenario form = new Forms.DialogBox.NewScenario();
            form.Owner = MainEntry.ihm;
            form.ShowDialog();
        }

        private void loadScenarioSolutionItem_Click(object sender, EventArgs e)
        {
            Tools.FileFunctions.LoadFile();
        }

        #endregion

        #region ContextMenus Scenario

        private void supprimerScenarioItem_Click(object sender, EventArgs e)
        {
            if (MainEntry.scenarioSolution.ScenariosToPlay.Contains(MainEntry.scenarioSolution.CurrentScenario))
            {
                MessageBox.Show("Suprresion du scenario impossible! Veuillez l'enlever de la liste de lecture si vous désirez le supprimer.",
                  "Suppression d'un scenario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (MessageBox.Show("Êtes-vous certain de vouloir supprimer le scenario \"" + MainEntry.scenarioSolution.CurrentScenario.Name + "\" ?", "Supression d'un scenario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MainEntry.scenarioSolution.RemoveScenario(MainEntry.scenarioSolution.CurrentScenario.Id);
                foreach (TreeNode node in solutionTreeNode.Nodes)
                {
                    if (Convert.ToInt16(node.Name) > Convert.ToInt16(currentNode.Name))
                    {
                        node.Name = Convert.ToString(Convert.ToInt16(node.Name) - 1);
                    }
                }
                currentNode.Remove();
                MainEntry.scenarioSolution.SaveSolution();
            }
        }

        private void playScenarioItem_Click(object sender, EventArgs e)
        {
            MainEntry.scenarioSolution.AddScenarioToPlayer(MainEntry.scenarioSolution.CurrentScenario);
        }

        private void validerScenarioItem_Click(object sender, EventArgs e)
        {
            if (!MainEntry.scenarioSolution.CurrentScenario.IsValidate)
            {
                if (MessageBox.Show("Êtes-vous certain de vouloir valider le scenario \"" +
                    MainEntry.scenarioSolution.CurrentScenario.Name + "\" ?" +
                    System.Environment.NewLine +
                    "Attenion! Aucune modification du scenario ne pourra être fait ultérieurement."
                , "Validation d'un scenario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MainEntry.scenarioSolution.CurrentScenario.Valid();
                    solutionTreeNode.Nodes[MainEntry.scenarioSolution.CurrentScenario.Id].NodeFont =
                        new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
                }
            }
            else
            {
                MessageBox.Show("Le scenario \"" + MainEntry.scenarioSolution.CurrentScenario.Name + "\" est déjà validé!",
                    "Validation d'un scenario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dupliquerScenarioItem_Click(object sender, EventArgs e)
        {
            Forms.DialogBox.DuplicateScenario form = new Forms.DialogBox.DuplicateScenario(MainEntry.scenarioSolution.CurrentScenario);
            form.Owner = MainEntry.ihm;
            form.ShowDialog();
        }


        #endregion

        #region ContextMenus Steps
        //Fonctions propres du ContextMenu des Steps
        private void newStepStepsItem_Click(object sender, EventArgs e)
        {
            if (MainEntry.scenarioSolution.CurrentScenario.IsValidate)
            {
                MessageBox.Show("Ajout d'un step impossible! Votre scenario a été validé.",
                  "Ajout d'un step", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Forms.DialogBox.NewStep form = new Forms.DialogBox.NewStep();
                form.Owner = MainEntry.ihm;
                form.ShowDialog();
            }
        }

        #endregion

        #region Action ContextMenus

        private void supprimerActionMenuItem1_Click(object sender, EventArgs e)
        {

            if (MainEntry.scenarioSolution.CurrentScenario.IsValidate)
            {
                MessageBox.Show("Supression du step impossible! Votre scenario a été validé.",
                    "Supression d'un step", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Êtes-vous certain de vouloir supprimer le Step \"" + currentNode.Text + "\" ?", "Supression d'un step", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MainEntry.scenarioSolution.CurrentScenario.RemoveStep(Convert.ToInt16(currentNode.Name));
                    currentNode.Remove();

                    foreach (GenericStep step in MainEntry.scenarioSolution.CurrentScenario.Steps)
                    {
                        if (step.NumStep >= Convert.ToInt16(currentNode.Name))
                        {
                            solutionTreeNode.Nodes[MainEntry.scenarioSolution.currentScenario].Nodes[0].Nodes[step.NumStep].Text = step.NumStep + 1 + "- " + ((StepsName)step.NameId).ToString();
                            solutionTreeNode.Nodes[MainEntry.scenarioSolution.currentScenario].Nodes[0].Nodes[step.NumStep].Name = step.NumStep.ToString();
                        }
                    }
                }
            }

            // treeView1.EndUpdate();
        }

        private void monterActionMenuItem_Click(object sender, EventArgs e)
        {
            if (currentNode.Index > 0 && currentNode.Level == 3)
            {
                MainEntry.scenarioSolution.CurrentScenario.InvertTwoSteps(currentNode.Index, currentNode.Index - 1);

                TreeNode[] list = new TreeNode[currentScenarioTreeNode.Nodes[0].Nodes.Count];
                currentScenarioTreeNode.Nodes[0].Nodes.CopyTo(list, 0);
                currentScenarioTreeNode.Nodes[0].Nodes.Clear();

                TreeNode tempNode = new TreeNode();
                tempNode = list[currentNode.Index];
                list[currentNode.Index] = list[currentNode.Index - 1];
                list[currentNode.Index].Text = currentNode.Index + 1 + list[currentNode.Index].Text.Substring(1, list[currentNode.Index].Text.Length - 1);
                list[currentNode.Index - 1] = tempNode;
                list[currentNode.Index - 1].Text = currentNode.Index + list[currentNode.Index - 1].Text.Substring(1, list[currentNode.Index - 1].Text.Length - 1);

                currentScenarioTreeNode.Nodes[0].Nodes.AddRange(list);
            }
        }

        private void descendreActionMenuItem_Click(object sender, EventArgs e)
        {
            if (currentNode.Index < currentNode.Parent.Nodes.Count - 1 && currentNode.Level == 3)
            {

                MainEntry.scenarioSolution.CurrentScenario.InvertTwoSteps(currentNode.Index, currentNode.Index + 1);

                TreeNode[] list = new TreeNode[currentScenarioTreeNode.Nodes[0].Nodes.Count];
                currentScenarioTreeNode.Nodes[0].Nodes.CopyTo(list, 0);
                currentScenarioTreeNode.Nodes[0].Nodes.Clear();

                TreeNode tempNode = new TreeNode();
                tempNode = list[currentNode.Index];
                list[currentNode.Index] = list[currentNode.Index + 1];
                list[currentNode.Index].Text = currentNode.Index + 1 + list[currentNode.Index].Text.Substring(1, list[currentNode.Index].Text.Length - 1);
                list[currentNode.Index + 1] = tempNode;
                list[currentNode.Index + 1].Text = currentNode.Index + 2 + list[currentNode.Index + 1].Text.Substring(1, list[currentNode.Index + 1].Text.Length - 1);
                currentScenarioTreeNode.Nodes[0].Nodes.AddRange(list);
            }
        }

        #endregion

        #region Results MenuStrip

        private void afficherResultMenuItem_Click(object sender, EventArgs e)
        {
            MainEntry._ScenarioEvents.OnNewScenarioResultToView(currentNode.Tag, null);
        }

        private void supprimerResultMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes-vous certain de vouloir supprimer le resultat \"" + currentNode.Text + "\" ?", "Supression d'un resultat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MainEntry.scenarioSolution.CurrentScenario.RemoveResult((Scenario.ResultDatas.ScenarioResult)currentNode.Tag);
                currentNode.Remove();
            }
        }

        #endregion
    }
}
