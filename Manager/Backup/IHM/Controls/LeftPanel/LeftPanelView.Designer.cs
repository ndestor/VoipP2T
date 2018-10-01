namespace Manager.IHM.Controls.LeftPanel
{
    partial class LeftPanelView
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.stepsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newStepStepsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenarioMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playScenarioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerScenarioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validerScenarioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dupliquerScenarioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solutionMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addScenarioSolutionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewScenarioSolutionItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadScenarioSolutionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActionMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.monterActionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendreActionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerActionMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ResultMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.afficherResultMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerResultMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.stepsMenuStrip.SuspendLayout();
            this.scenarioMenuStrip.SuspendLayout();
            this.solutionMenuStrip.SuspendLayout();
            this.ActionMenuStrip.SuspendLayout();
            this.ResultMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(220, 486);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(0, 18);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(219, 228);
            this.treeView1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 19);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Explorateur de scenarios - Solution";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 19);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(219, 214);
            this.propertyGrid1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 19);
            this.panel2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Propriétés";
            // 
            // stepsMenuStrip
            // 
            this.stepsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.stepsMenuStrip.Name = "contextMenuStrip1";
            this.stepsMenuStrip.Size = new System.Drawing.Size(111, 26);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newStepStepsItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.testToolStripMenuItem.Text = "Ajouter";
            // 
            // newStepStepsItem
            // 
            this.newStepStepsItem.Name = "newStepStepsItem";
            this.newStepStepsItem.Size = new System.Drawing.Size(142, 22);
            this.newStepStepsItem.Text = "Nouveau Step";
            this.newStepStepsItem.Click += new System.EventHandler(this.newStepStepsItem_Click);
            // 
            // scenarioMenuStrip
            // 
            this.scenarioMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playScenarioItem,
            this.supprimerScenarioItem,
            this.validerScenarioItem,
            this.dupliquerScenarioItem});
            this.scenarioMenuStrip.Name = "scenarioMenuStrip";
            this.scenarioMenuStrip.Size = new System.Drawing.Size(123, 92);
            // 
            // playScenarioItem
            // 
            this.playScenarioItem.Image = global::Manager.Properties.Resources.Play;
            this.playScenarioItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.playScenarioItem.Name = "playScenarioItem";
            this.playScenarioItem.Size = new System.Drawing.Size(122, 22);
            this.playScenarioItem.Text = "Jouer";
            this.playScenarioItem.Click += new System.EventHandler(this.playScenarioItem_Click);
            // 
            // supprimerScenarioItem
            // 
            this.supprimerScenarioItem.Image = global::Manager.Properties.Resources.delete;
            this.supprimerScenarioItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.supprimerScenarioItem.Name = "supprimerScenarioItem";
            this.supprimerScenarioItem.Size = new System.Drawing.Size(122, 22);
            this.supprimerScenarioItem.Text = "Supprimer";
            this.supprimerScenarioItem.Click += new System.EventHandler(this.supprimerScenarioItem_Click);
            // 
            // validerScenarioItem
            // 
            this.validerScenarioItem.ImageTransparentColor = System.Drawing.Color.White;
            this.validerScenarioItem.Name = "validerScenarioItem";
            this.validerScenarioItem.Size = new System.Drawing.Size(122, 22);
            this.validerScenarioItem.Text = "Valider";
            this.validerScenarioItem.Click += new System.EventHandler(this.validerScenarioItem_Click);
            // 
            // dupliquerScenarioItem
            // 
            this.dupliquerScenarioItem.Name = "dupliquerScenarioItem";
            this.dupliquerScenarioItem.Size = new System.Drawing.Size(122, 22);
            this.dupliquerScenarioItem.Text = "Dupliquer";
            this.dupliquerScenarioItem.Click += new System.EventHandler(this.dupliquerScenarioItem_Click);
            // 
            // solutionMenuStrip
            // 
            this.solutionMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addScenarioSolutionItem});
            this.solutionMenuStrip.Name = "solutionMenuStrip";
            this.solutionMenuStrip.Size = new System.Drawing.Size(111, 26);
            // 
            // addScenarioSolutionItem
            // 
            this.addScenarioSolutionItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewScenarioSolutionItem1,
            this.loadScenarioSolutionItem});
            this.addScenarioSolutionItem.Name = "addScenarioSolutionItem";
            this.addScenarioSolutionItem.Size = new System.Drawing.Size(110, 22);
            this.addScenarioSolutionItem.Text = "Ajouter";
            // 
            // NewScenarioSolutionItem1
            // 
            this.NewScenarioSolutionItem1.Name = "NewScenarioSolutionItem1";
            this.NewScenarioSolutionItem1.Size = new System.Drawing.Size(161, 22);
            this.NewScenarioSolutionItem1.Text = "Nouveau Scenario";
            this.NewScenarioSolutionItem1.Click += new System.EventHandler(this.NewScenarioSolutionItem1_Click);
            // 
            // loadScenarioSolutionItem
            // 
            this.loadScenarioSolutionItem.Name = "loadScenarioSolutionItem";
            this.loadScenarioSolutionItem.Size = new System.Drawing.Size(161, 22);
            this.loadScenarioSolutionItem.Text = "Scenario existant";
            this.loadScenarioSolutionItem.Click += new System.EventHandler(this.loadScenarioSolutionItem_Click);
            // 
            // ActionMenuStrip
            // 
            this.ActionMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monterActionMenuItem,
            this.descendreActionMenuItem,
            this.supprimerActionMenuItem1});
            this.ActionMenuStrip.Name = "ActionMenuStrip";
            this.ActionMenuStrip.Size = new System.Drawing.Size(126, 70);
            // 
            // monterActionMenuItem
            // 
            this.monterActionMenuItem.Image = global::Manager.Properties.Resources.FillUp;
            this.monterActionMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.monterActionMenuItem.Name = "monterActionMenuItem";
            this.monterActionMenuItem.Size = new System.Drawing.Size(125, 22);
            this.monterActionMenuItem.Text = "Monter";
            this.monterActionMenuItem.Click += new System.EventHandler(this.monterActionMenuItem_Click);
            // 
            // descendreActionMenuItem
            // 
            this.descendreActionMenuItem.Image = global::Manager.Properties.Resources.FillDown;
            this.descendreActionMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.descendreActionMenuItem.Name = "descendreActionMenuItem";
            this.descendreActionMenuItem.Size = new System.Drawing.Size(125, 22);
            this.descendreActionMenuItem.Text = "Descendre";
            this.descendreActionMenuItem.Click += new System.EventHandler(this.descendreActionMenuItem_Click);
            // 
            // supprimerActionMenuItem1
            // 
            this.supprimerActionMenuItem1.Image = global::Manager.Properties.Resources.delete;
            this.supprimerActionMenuItem1.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.supprimerActionMenuItem1.Name = "supprimerActionMenuItem1";
            this.supprimerActionMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.supprimerActionMenuItem1.Text = "Supprimer";
            this.supprimerActionMenuItem1.Click += new System.EventHandler(this.supprimerActionMenuItem1_Click);
            // 
            // ResultMenuStrip
            // 
            this.ResultMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afficherResultMenuItem,
            this.supprimerResultMenuItem});
            this.ResultMenuStrip.Name = "ResultMenuStrip";
            this.ResultMenuStrip.Size = new System.Drawing.Size(153, 70);
            // 
            // afficherResultMenuItem
            // 
            this.afficherResultMenuItem.Name = "afficherResultMenuItem";
            this.afficherResultMenuItem.Size = new System.Drawing.Size(152, 22);
            this.afficherResultMenuItem.Text = "Afficher";
            this.afficherResultMenuItem.Click += new System.EventHandler(this.afficherResultMenuItem_Click);
            // 
            // supprimerResultMenuItem
            // 
            this.supprimerResultMenuItem.Image = global::Manager.Properties.Resources.delete;
            this.supprimerResultMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.supprimerResultMenuItem.Name = "supprimerResultMenuItem";
            this.supprimerResultMenuItem.Size = new System.Drawing.Size(152, 22);
            this.supprimerResultMenuItem.Text = "Supprimer";
            this.supprimerResultMenuItem.Click += new System.EventHandler(this.supprimerResultMenuItem_Click);
            // 
            // LeftPanelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.splitContainer1);
            this.Name = "LeftPanelView";
            this.Size = new System.Drawing.Size(220, 486);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.stepsMenuStrip.ResumeLayout(false);
            this.scenarioMenuStrip.ResumeLayout(false);
            this.solutionMenuStrip.ResumeLayout(false);
            this.ActionMenuStrip.ResumeLayout(false);
            this.ResultMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip stepsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newStepStepsItem;
        private System.Windows.Forms.ContextMenuStrip scenarioMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem playScenarioItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerScenarioItem;
        private System.Windows.Forms.ContextMenuStrip solutionMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addScenarioSolutionItem;
        private System.Windows.Forms.ToolStripMenuItem NewScenarioSolutionItem1;
        private System.Windows.Forms.ToolStripMenuItem loadScenarioSolutionItem;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip ActionMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem supprimerActionMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem validerScenarioItem;
        private System.Windows.Forms.ToolStripMenuItem monterActionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendreActionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dupliquerScenarioItem;
        private System.Windows.Forms.ContextMenuStrip ResultMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem afficherResultMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerResultMenuItem;
    }
}
