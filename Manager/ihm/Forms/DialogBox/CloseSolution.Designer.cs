namespace Manager.IHM.Forms.DialogBox
{
    partial class CloseSolution
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.oui = new System.Windows.Forms.Button();
            this.non = new System.Windows.Forms.Button();
            this.annuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "La solution actuelle va être fermée.\r\nVoulez-vous enregistrer les modifications a" +
                "pportées à la solution \r\nactuelle ?";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(9, 57);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 1);
            this.panel1.TabIndex = 6;
            // 
            // oui
            // 
            this.oui.Location = new System.Drawing.Point(97, 70);
            this.oui.Name = "oui";
            this.oui.Size = new System.Drawing.Size(75, 23);
            this.oui.TabIndex = 7;
            this.oui.Text = "Oui";
            this.oui.UseVisualStyleBackColor = true;
            this.oui.Click += new System.EventHandler(this.oui_Click);
            // 
            // non
            // 
            this.non.Location = new System.Drawing.Point(178, 70);
            this.non.Name = "non";
            this.non.Size = new System.Drawing.Size(75, 23);
            this.non.TabIndex = 8;
            this.non.Text = "Non";
            this.non.UseVisualStyleBackColor = true;
            this.non.Click += new System.EventHandler(this.non_Click);
            // 
            // annuler
            // 
            this.annuler.Location = new System.Drawing.Point(259, 70);
            this.annuler.Name = "annuler";
            this.annuler.Size = new System.Drawing.Size(75, 23);
            this.annuler.TabIndex = 9;
            this.annuler.Text = "Annuler";
            this.annuler.UseVisualStyleBackColor = true;
            this.annuler.Click += new System.EventHandler(this.annuler_Click);
            // 
            // CloseSolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 102);
            this.Controls.Add(this.annuler);
            this.Controls.Add(this.non);
            this.Controls.Add(this.oui);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "CloseSolution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fermeture de la solution actuelle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button oui;
        private System.Windows.Forms.Button non;
        private System.Windows.Forms.Button annuler;

    }
}