namespace Manager.IHM.Controls.BottomPanel
{
    partial class ScenarioPlayer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateCheckBox = new System.Windows.Forms.CheckBox();
            this.datePicker2 = new System.Windows.Forms.DateTimePicker();
            this.timePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timeToWaitLabel = new System.Windows.Forms.Label();
            this.StopPlayer = new System.Windows.Forms.Button();
            this.PlayScenario = new System.Windows.Forms.Button();
            this.table1 = new XPTable.Models.Table();
            this.columnModel1 = new XPTable.Models.ColumnModel();
            this.tableModel1 = new XPTable.Models.TableModel();
            this.deletteButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dateCheckBox);
            this.groupBox1.Controls.Add(this.datePicker2);
            this.groupBox1.Controls.Add(this.timePicker1);
            this.groupBox1.Location = new System.Drawing.Point(603, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurations";
            // 
            // dateCheckBox
            // 
            this.dateCheckBox.AutoSize = true;
            this.dateCheckBox.Location = new System.Drawing.Point(19, 24);
            this.dateCheckBox.Name = "dateCheckBox";
            this.dateCheckBox.Size = new System.Drawing.Size(122, 17);
            this.dateCheckBox.TabIndex = 11;
            this.dateCheckBox.Text = "Date de lancement :";
            this.dateCheckBox.UseVisualStyleBackColor = true;
            // 
            // datePicker2
            // 
            this.datePicker2.Checked = false;
            this.datePicker2.Enabled = false;
            this.datePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker2.Location = new System.Drawing.Point(147, 21);
            this.datePicker2.Name = "datePicker2";
            this.datePicker2.Size = new System.Drawing.Size(102, 20);
            this.datePicker2.TabIndex = 10;
            // 
            // timePicker1
            // 
            this.timePicker1.Checked = false;
            this.timePicker1.Enabled = false;
            this.timePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.timePicker1.Location = new System.Drawing.Point(267, 21);
            this.timePicker1.Name = "timePicker1";
            this.timePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timePicker1.ShowUpDown = true;
            this.timePicker1.Size = new System.Drawing.Size(90, 20);
            this.timePicker1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.timeToWaitLabel);
            this.groupBox2.Controls.Add(this.StopPlayer);
            this.groupBox2.Controls.Add(this.PlayScenario);
            this.groupBox2.Location = new System.Drawing.Point(603, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 52);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contrôles";
            // 
            // timeToWaitLabel
            // 
            this.timeToWaitLabel.AutoSize = true;
            this.timeToWaitLabel.Location = new System.Drawing.Point(211, 24);
            this.timeToWaitLabel.Name = "timeToWaitLabel";
            this.timeToWaitLabel.Size = new System.Drawing.Size(0, 13);
            this.timeToWaitLabel.TabIndex = 5;
            // 
            // StopPlayer
            // 
            this.StopPlayer.Location = new System.Drawing.Point(115, 19);
            this.StopPlayer.Name = "StopPlayer";
            this.StopPlayer.Size = new System.Drawing.Size(90, 23);
            this.StopPlayer.TabIndex = 4;
            this.StopPlayer.Text = "Arréter";
            this.StopPlayer.UseVisualStyleBackColor = true;
            this.StopPlayer.Click += new System.EventHandler(this.StopPlayer_Click);
            // 
            // PlayScenario
            // 
            this.PlayScenario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayScenario.Location = new System.Drawing.Point(19, 19);
            this.PlayScenario.Name = "PlayScenario";
            this.PlayScenario.Size = new System.Drawing.Size(90, 23);
            this.PlayScenario.TabIndex = 3;
            this.PlayScenario.Text = "Démarrer";
            this.PlayScenario.UseVisualStyleBackColor = true;
            this.PlayScenario.Click += new System.EventHandler(this.PlayScenario_Click);
            // 
            // table1
            // 
            this.table1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.table1.ColumnModel = this.columnModel1;
            this.table1.ColumnResizing = false;
            this.table1.FullRowSelect = true;
            this.table1.Location = new System.Drawing.Point(3, 3);
            this.table1.Name = "table1";
            this.table1.Size = new System.Drawing.Size(560, 166);
            this.table1.TabIndex = 0;
            this.table1.TableModel = this.tableModel1;
            this.table1.Text = "table1";
            // 
            // deletteButton
            // 
            this.deletteButton.BackgroundImage = global::Manager.Properties.Resources.Cross;
            this.deletteButton.Location = new System.Drawing.Point(569, 61);
            this.deletteButton.Name = "deletteButton";
            this.deletteButton.Size = new System.Drawing.Size(28, 24);
            this.deletteButton.TabIndex = 8;
            this.deletteButton.UseVisualStyleBackColor = true;
            this.deletteButton.Click += new System.EventHandler(this.deletteButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.BackgroundImage = global::Manager.Properties.Resources.UpArrow;
            this.UpButton.Location = new System.Drawing.Point(569, 3);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(28, 25);
            this.UpButton.TabIndex = 4;
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.BackgroundImage = global::Manager.Properties.Resources.BottomArrow;
            this.DownButton.Location = new System.Drawing.Point(569, 31);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(28, 24);
            this.DownButton.TabIndex = 3;
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // ScenarioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deletteButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.table1);
            this.Name = "ScenarioPlayer";
            this.Size = new System.Drawing.Size(991, 172);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XPTable.Models.Table table1;
        private XPTable.Models.ColumnModel columnModel1;
        private XPTable.Models.TableModel tableModel1;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker timePicker1;
        private System.Windows.Forms.DateTimePicker datePicker2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button StopPlayer;
        private System.Windows.Forms.Button PlayScenario;
        private System.Windows.Forms.Button deletteButton;
        private System.Windows.Forms.Label timeToWaitLabel;
        private System.Windows.Forms.CheckBox dateCheckBox;
    }
}
