namespace Manager.IHM.Forms.DialogBox
{
    partial class NewSolution
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
            this.SolutionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SolutionEmplacement = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.parcourir = new System.Windows.Forms.Button();
            this.oK = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // SolutionName
            // 
            this.SolutionName.Location = new System.Drawing.Point(102, 12);
            this.SolutionName.Name = "SolutionName";
            this.SolutionName.Size = new System.Drawing.Size(208, 20);
            this.SolutionName.TabIndex = 0;
            this.SolutionName.Text = "Solution1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Emplacement :";
            // 
            // SolutionEmplacement
            // 
            this.SolutionEmplacement.Location = new System.Drawing.Point(102, 42);
            this.SolutionEmplacement.Name = "SolutionEmplacement";
            this.SolutionEmplacement.Size = new System.Drawing.Size(208, 20);
            this.SolutionEmplacement.TabIndex = 3;
            // 
            // parcourir
            // 
            this.parcourir.Location = new System.Drawing.Point(325, 41);
            this.parcourir.Name = "parcourir";
            this.parcourir.Size = new System.Drawing.Size(75, 23);
            this.parcourir.TabIndex = 4;
            this.parcourir.Text = "Parcourir...";
            this.parcourir.UseVisualStyleBackColor = true;
            this.parcourir.Click += new System.EventHandler(this.parcourir_Click);
            // 
            // oK
            // 
            this.oK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oK.Location = new System.Drawing.Point(255, 83);
            this.oK.Name = "oK";
            this.oK.Size = new System.Drawing.Size(64, 23);
            this.oK.TabIndex = 6;
            this.oK.Text = "OK";
            this.oK.UseVisualStyleBackColor = true;
            this.oK.Click += new System.EventHandler(this.oK_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(336, 83);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(64, 23);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Annuler";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(9, 76);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 1);
            this.panel1.TabIndex = 5;
            // 
            // NewSolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 115);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.oK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.parcourir);
            this.Controls.Add(this.SolutionEmplacement);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SolutionName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewSolution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nouvelle Solution";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SolutionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SolutionEmplacement;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button parcourir;
        private System.Windows.Forms.Button oK;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
    }
}