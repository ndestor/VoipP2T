namespace Manager.IHM.Controls
{
    partial class GeneralsInformations
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
            this.Informations = new System.Windows.Forms.GroupBox();
            this.lastScenario = new System.Windows.Forms.Label();
            this.registeredTester = new System.Windows.Forms.Label();
            this.expiration = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Informations.SuspendLayout();
            this.SuspendLayout();
            // 
            // Informations
            // 
            this.Informations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Informations.Controls.Add(this.lastScenario);
            this.Informations.Controls.Add(this.registeredTester);
            this.Informations.Controls.Add(this.expiration);
            this.Informations.Controls.Add(this.version);
            this.Informations.Controls.Add(this.label2);
            this.Informations.Controls.Add(this.label4);
            this.Informations.Controls.Add(this.label3);
            this.Informations.Controls.Add(this.label1);
            this.Informations.Location = new System.Drawing.Point(3, 3);
            this.Informations.Name = "Informations";
            this.Informations.Size = new System.Drawing.Size(744, 122);
            this.Informations.TabIndex = 0;
            this.Informations.TabStop = false;
            this.Informations.Text = "Informations générales";
            // 
            // lastScenario
            // 
            this.lastScenario.AutoSize = true;
            this.lastScenario.Location = new System.Drawing.Point(177, 98);
            this.lastScenario.Name = "lastScenario";
            this.lastScenario.Size = new System.Drawing.Size(58, 13);
            this.lastScenario.TabIndex = 8;
            this.lastScenario.Text = "Scenario 1";
            // 
            // registeredTester
            // 
            this.registeredTester.AutoSize = true;
            this.registeredTester.Location = new System.Drawing.Point(177, 71);
            this.registeredTester.Name = "registeredTester";
            this.registeredTester.Size = new System.Drawing.Size(13, 13);
            this.registeredTester.TabIndex = 7;
            this.registeredTester.Text = "3";
            // 
            // expiration
            // 
            this.expiration.AutoSize = true;
            this.expiration.Location = new System.Drawing.Point(177, 47);
            this.expiration.Name = "expiration";
            this.expiration.Size = new System.Drawing.Size(103, 13);
            this.expiration.TabIndex = 6;
            this.expiration.Text = "expire le jj/mm/aaaa";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(177, 25);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(22, 13);
            this.version.TabIndex = 5;
            this.version.Text = "1.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dernier scenario joué :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre de testeurs enregistrées :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date d\'expiration :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Version du logiciel :";
            // 
            // GeneralsInformations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Informations);
            this.Name = "GeneralsInformations";
            this.Size = new System.Drawing.Size(750, 128);
            this.Load += new System.EventHandler(this.GeneralsInformations_Load);
            this.Informations.ResumeLayout(false);
            this.Informations.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Informations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lastScenario;
        private System.Windows.Forms.Label registeredTester;
        private System.Windows.Forms.Label expiration;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label label2;
    }
}
