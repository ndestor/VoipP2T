namespace Manager.IHM.Controls.MainPanel.ResultsPanel
{
    partial class ResultCtrlPanel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CommentLabel = new System.Windows.Forms.LinkLabel();
            this.numberStepPlayedLabel = new System.Windows.Forms.Label();
            this.generalResultLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.scenarioNameLabel = new System.Windows.Forms.Label();
            this.CommentsTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.action = new System.Windows.Forms.ColumnHeader();
            this.actors = new System.Windows.Forms.ColumnHeader();
            this.infos = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.steplabelDesc = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.logsDestination = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.logsSource = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.commands = new System.Windows.Forms.GroupBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.commands.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.commands, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(995, 501);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.CommentLabel);
            this.groupBox1.Controls.Add(this.numberStepPlayedLabel);
            this.groupBox1.Controls.Add(this.generalResultLabel);
            this.groupBox1.Controls.Add(this.dateLabel);
            this.groupBox1.Controls.Add(this.scenarioNameLabel);
            this.groupBox1.Controls.Add(this.CommentsTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(985, 130);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informations sur le résultat";
            // 
            // CommentLabel
            // 
            this.CommentLabel.AutoSize = true;
            this.CommentLabel.Location = new System.Drawing.Point(915, 28);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(45, 13);
            this.CommentLabel.TabIndex = 11;
            this.CommentLabel.TabStop = true;
            this.CommentLabel.Text = "Modifier";
            this.CommentLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CommentLabel_LinkClicked_1);
            // 
            // numberStepPlayedLabel
            // 
            this.numberStepPlayedLabel.AutoSize = true;
            this.numberStepPlayedLabel.Location = new System.Drawing.Point(131, 101);
            this.numberStepPlayedLabel.Name = "numberStepPlayedLabel";
            this.numberStepPlayedLabel.Size = new System.Drawing.Size(35, 13);
            this.numberStepPlayedLabel.TabIndex = 10;
            this.numberStepPlayedLabel.Text = "label9";
            // 
            // generalResultLabel
            // 
            this.generalResultLabel.AutoSize = true;
            this.generalResultLabel.Location = new System.Drawing.Point(131, 77);
            this.generalResultLabel.Name = "generalResultLabel";
            this.generalResultLabel.Size = new System.Drawing.Size(35, 13);
            this.generalResultLabel.TabIndex = 9;
            this.generalResultLabel.Text = "label8";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(131, 52);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(35, 13);
            this.dateLabel.TabIndex = 8;
            this.dateLabel.Text = "label7";
            // 
            // scenarioNameLabel
            // 
            this.scenarioNameLabel.AutoSize = true;
            this.scenarioNameLabel.Location = new System.Drawing.Point(131, 28);
            this.scenarioNameLabel.Name = "scenarioNameLabel";
            this.scenarioNameLabel.Size = new System.Drawing.Size(38, 13);
            this.scenarioNameLabel.TabIndex = 7;
            this.scenarioNameLabel.Text = "inconu";
            // 
            // CommentsTextBox
            // 
            this.CommentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentsTextBox.Location = new System.Drawing.Point(405, 44);
            this.CommentsTextBox.Multiline = true;
            this.CommentsTextBox.Name = "CommentsTextBox";
            this.CommentsTextBox.ReadOnly = true;
            this.CommentsTextBox.Size = new System.Drawing.Size(553, 70);
            this.CommentsTextBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(402, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Commentaires :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Résultat générale :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre de step joués :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date de la lecture :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Associé au scenario :";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 349F));
            this.tableLayoutPanel2.Controls.Add(this.listView1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 195);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(995, 306);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Status,
            this.action,
            this.actors,
            this.infos});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(654, 298);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 50;
            // 
            // action
            // 
            this.action.Text = "Action";
            this.action.Width = 112;
            // 
            // actors
            // 
            this.actors.Text = " Source     --->      Destination";
            this.actors.Width = 200;
            // 
            // infos
            // 
            this.infos.Text = "Informations retournées";
            this.infos.Width = 288;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.steplabelDesc);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.logsDestination);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.logsSource);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(663, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 300);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informations détaillés sur le step";
            // 
            // steplabelDesc
            // 
            this.steplabelDesc.AutoSize = true;
            this.steplabelDesc.Location = new System.Drawing.Point(29, 25);
            this.steplabelDesc.Name = "steplabelDesc";
            this.steplabelDesc.Size = new System.Drawing.Size(35, 13);
            this.steplabelDesc.TabIndex = 5;
            this.steplabelDesc.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Step ";
            // 
            // logsDestination
            // 
            this.logsDestination.Location = new System.Drawing.Point(6, 196);
            this.logsDestination.Multiline = true;
            this.logsDestination.Name = "logsDestination";
            this.logsDestination.Size = new System.Drawing.Size(308, 88);
            this.logsDestination.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(241, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Informations retournées par le testeur destination :";
            // 
            // logsSource
            // 
            this.logsSource.Location = new System.Drawing.Point(6, 69);
            this.logsSource.Multiline = true;
            this.logsSource.Name = "logsSource";
            this.logsSource.Size = new System.Drawing.Size(308, 88);
            this.logsSource.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Informations retournées par le testeur source :";
            // 
            // commands
            // 
            this.commands.Controls.Add(this.exitButton);
            this.commands.Location = new System.Drawing.Point(3, 139);
            this.commands.Name = "commands";
            this.commands.Size = new System.Drawing.Size(986, 53);
            this.commands.TabIndex = 5;
            this.commands.TabStop = false;
            this.commands.Text = "Commandes";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(9, 24);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Quitter";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // ResultCtrlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ResultCtrlPanel";
            this.Size = new System.Drawing.Size(997, 502);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.commands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CommentsTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label numberStepPlayedLabel;
        private System.Windows.Forms.Label generalResultLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label scenarioNameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox logsDestination;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox logsSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader action;
        private System.Windows.Forms.ColumnHeader actors;
        private System.Windows.Forms.ColumnHeader infos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label steplabelDesc;
        private System.Windows.Forms.GroupBox commands;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.LinkLabel CommentLabel;


    }
}
