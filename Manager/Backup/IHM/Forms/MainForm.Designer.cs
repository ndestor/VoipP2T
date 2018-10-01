namespace Manager.IHM.Forms
{
    partial class MainForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scenarioToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.enregisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerToutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.NewFileToolStripButton = new System.Windows.Forms.ToolStripSplitButton();
            this.newSolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newScenarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileToolStrip = new System.Windows.Forms.ToolStripButton();
            this.SaveToolStripbutton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.leftPanelView1 = new Manager.IHM.Controls.LeftPanel.LeftPanelView();
            this.mainCtrlPanel1 = new Manager.IHM.Controls.MainPanel.MainCtrlPanel();
            this.bottomPanelView1 = new Manager.IHM.Controls.BottomPanel.BottomPanelView();
            this.testerView1 = new Manager.IHM.Controls.TesterView();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 611);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1272, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editionToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1272, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.ouvrirToolStripMenuItem1,
            this.enregisterToolStripMenuItem,
            this.enregistrerToutToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "Fichier";
            // 
            // nouveauToolStripMenuItem
            // 
            this.nouveauToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scenarioToolStripMenuItem,
            this.scenarioToolStripMenuItem2});
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.nouveauToolStripMenuItem.Text = "Nouveau";
            // 
            // scenarioToolStripMenuItem
            // 
            this.scenarioToolStripMenuItem.Name = "scenarioToolStripMenuItem";
            this.scenarioToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.scenarioToolStripMenuItem.Text = "Solution";
            this.scenarioToolStripMenuItem.Click += new System.EventHandler(this.scenarioToolStripMenuItem_Click);
            // 
            // scenarioToolStripMenuItem2
            // 
            this.scenarioToolStripMenuItem2.Image = global::Manager.Properties.Resources.NewDocument;
            this.scenarioToolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.scenarioToolStripMenuItem2.Name = "scenarioToolStripMenuItem2";
            this.scenarioToolStripMenuItem2.Size = new System.Drawing.Size(126, 22);
            this.scenarioToolStripMenuItem2.Text = "Scenario";
            // 
            // ouvrirToolStripMenuItem1
            // 
            this.ouvrirToolStripMenuItem1.Image = global::Manager.Properties.Resources.openHS;
            this.ouvrirToolStripMenuItem1.Name = "ouvrirToolStripMenuItem1";
            this.ouvrirToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.ouvrirToolStripMenuItem1.Text = "Ouvrir";
            this.ouvrirToolStripMenuItem1.Click += new System.EventHandler(this.ouvrirToolStripMenuItem1_Click);
            // 
            // enregisterToolStripMenuItem
            // 
            this.enregisterToolStripMenuItem.Image = global::Manager.Properties.Resources.Save;
            this.enregisterToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.enregisterToolStripMenuItem.Name = "enregisterToolStripMenuItem";
            this.enregisterToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.enregisterToolStripMenuItem.Text = "Enregister";
            this.enregisterToolStripMenuItem.Click += new System.EventHandler(this.enregisterToolStripMenuItem_Click);
            // 
            // enregistrerToutToolStripMenuItem
            // 
            this.enregistrerToutToolStripMenuItem.Image = global::Manager.Properties.Resources.SaveAll;
            this.enregistrerToutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.enregistrerToutToolStripMenuItem.Name = "enregistrerToutToolStripMenuItem";
            this.enregistrerToutToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.enregistrerToutToolStripMenuItem.Text = "Enregistrer tout";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            // 
            // editionToolStripMenuItem
            // 
            this.editionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirToolStripMenuItem});
            this.editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            this.editionToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.editionToolStripMenuItem.Text = "Edition";
            // 
            // ouvrirToolStripMenuItem
            // 
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.ouvrirToolStripMenuItem.Text = "Ouvrir";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem2.Text = "?";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.Controls.Add(this.testerView1);
            this.panel1.Location = new System.Drawing.Point(1, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1271, 148);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 196);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.leftPanelView1);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(1272, 415);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.mainCtrlPanel1);
            this.splitContainer2.Panel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.splitContainer2.Panel1MinSize = 0;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.bottomPanelView1);
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(1005, 415);
            this.splitContainer2.SplitterDistance = 189;
            this.splitContainer2.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFileToolStripButton,
            this.OpenFileToolStrip,
            this.SaveToolStripbutton,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1272, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // NewFileToolStripButton
            // 
            this.NewFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewFileToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSolutionToolStripMenuItem,
            this.newScenarioToolStripMenuItem});
            this.NewFileToolStripButton.Image = global::Manager.Properties.Resources.NewDocument;
            this.NewFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewFileToolStripButton.Name = "NewFileToolStripButton";
            this.NewFileToolStripButton.Size = new System.Drawing.Size(32, 22);
            this.NewFileToolStripButton.Text = "Nouveau";
            // 
            // newSolutionToolStripMenuItem
            // 
            this.newSolutionToolStripMenuItem.Name = "newSolutionToolStripMenuItem";
            this.newSolutionToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.newSolutionToolStripMenuItem.Text = "Nouvelle solution";
            this.newSolutionToolStripMenuItem.Click += new System.EventHandler(this.newSolutionToolStripMenuItem_Click);
            // 
            // newScenarioToolStripMenuItem
            // 
            this.newScenarioToolStripMenuItem.Image = global::Manager.Properties.Resources.NewDocument;
            this.newScenarioToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.newScenarioToolStripMenuItem.Name = "newScenarioToolStripMenuItem";
            this.newScenarioToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.newScenarioToolStripMenuItem.Text = "Nouveau scenario";
            this.newScenarioToolStripMenuItem.Click += new System.EventHandler(this.newScenarioToolStripMenuItem_Click);
            // 
            // OpenFileToolStrip
            // 
            this.OpenFileToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenFileToolStrip.Image = global::Manager.Properties.Resources.openHS;
            this.OpenFileToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenFileToolStrip.Name = "OpenFileToolStrip";
            this.OpenFileToolStrip.Size = new System.Drawing.Size(23, 22);
            this.OpenFileToolStrip.Text = "Ouvrir";
            this.OpenFileToolStrip.Click += new System.EventHandler(this.OpenFileToolStrip_Click);
            // 
            // SaveToolStripbutton
            // 
            this.SaveToolStripbutton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolStripbutton.Image = global::Manager.Properties.Resources.Save;
            this.SaveToolStripbutton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripbutton.Name = "SaveToolStripbutton";
            this.SaveToolStripbutton.Size = new System.Drawing.Size(23, 22);
            this.SaveToolStripbutton.Text = "Enregistrer";
            this.SaveToolStripbutton.Click += new System.EventHandler(this.SaveToolStripbutton_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Manager.Properties.Resources.SaveAll;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Enregistrer tout";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // leftPanelView1
            // 
            this.leftPanelView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.leftPanelView1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.leftPanelView1.BackColor = System.Drawing.SystemColors.Control;
            this.leftPanelView1.Location = new System.Drawing.Point(1, 0);
            this.leftPanelView1.Name = "leftPanelView1";
            this.leftPanelView1.Size = new System.Drawing.Size(260, 415);
            this.leftPanelView1.TabIndex = 0;
            // 
            // mainCtrlPanel1
            // 
            this.mainCtrlPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainCtrlPanel1.BackColor = System.Drawing.Color.Transparent;
            this.mainCtrlPanel1.Location = new System.Drawing.Point(-3, -2);
            this.mainCtrlPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.mainCtrlPanel1.Name = "mainCtrlPanel1";
            this.mainCtrlPanel1.Size = new System.Drawing.Size(1009, 194);
            this.mainCtrlPanel1.TabIndex = 0;
            // 
            // bottomPanelView1
            // 
            this.bottomPanelView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomPanelView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bottomPanelView1.Location = new System.Drawing.Point(0, 0);
            this.bottomPanelView1.Margin = new System.Windows.Forms.Padding(0);
            this.bottomPanelView1.Name = "bottomPanelView1";
            this.bottomPanelView1.Size = new System.Drawing.Size(1004, 220);
            this.bottomPanelView1.TabIndex = 0;
            // 
            // testerView1
            // 
            this.testerView1.Location = new System.Drawing.Point(0, 1);
            this.testerView1.Name = "testerView1";
            this.testerView1.Size = new System.Drawing.Size(768, 144);
            this.testerView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 633);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Automate de tests V. béta";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Manager.IHM.Controls.LeftPanel.LeftPanelView leftPanelView1;
        private Manager.IHM.Controls.BottomPanel.BottomPanelView bottomPanelView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scenarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem enregisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enregistrerToutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scenarioToolStripMenuItem2;
        private System.Windows.Forms.ToolStripButton SaveToolStripbutton;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton OpenFileToolStrip;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Manager.IHM.Controls.TesterView testerView1;
        private System.Windows.Forms.ToolStripSplitButton NewFileToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem newSolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newScenarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private Manager.IHM.Controls.MainPanel.MainCtrlPanel mainCtrlPanel1;       
    }
}