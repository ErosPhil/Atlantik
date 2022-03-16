
namespace Atlantik
{
    partial class FormAjouterLiaison
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDepart = new System.Windows.Forms.Label();
            this.cmbDepart = new System.Windows.Forms.ComboBox();
            this.lblArrivee = new System.Windows.Forms.Label();
            this.cmbArrivee = new System.Windows.Forms.ComboBox();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lbxSecteursAjouterLiaison = new System.Windows.Forms.ListBox();
            this.lblSecteursAjouterLiaison = new System.Windows.Forms.Label();
            this.btnAjouterLiaison = new System.Windows.Forms.Button();
            this.tbxDistance = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Location = new System.Drawing.Point(130, 39);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(45, 13);
            this.lblDepart.TabIndex = 17;
            this.lblDepart.Text = "Départ :";
            // 
            // cmbDepart
            // 
            this.cmbDepart.FormattingEnabled = true;
            this.cmbDepart.Location = new System.Drawing.Point(182, 36);
            this.cmbDepart.Name = "cmbDepart";
            this.cmbDepart.Size = new System.Drawing.Size(70, 21);
            this.cmbDepart.TabIndex = 16;
            // 
            // lblArrivee
            // 
            this.lblArrivee.AutoSize = true;
            this.lblArrivee.Location = new System.Drawing.Point(283, 39);
            this.lblArrivee.Name = "lblArrivee";
            this.lblArrivee.Size = new System.Drawing.Size(46, 13);
            this.lblArrivee.TabIndex = 15;
            this.lblArrivee.Text = "Arrivée :";
            // 
            // cmbArrivee
            // 
            this.cmbArrivee.FormattingEnabled = true;
            this.cmbArrivee.Location = new System.Drawing.Point(335, 36);
            this.cmbArrivee.Name = "cmbArrivee";
            this.cmbArrivee.Size = new System.Drawing.Size(70, 21);
            this.cmbArrivee.TabIndex = 14;
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(274, 195);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(55, 13);
            this.lblDistance.TabIndex = 13;
            this.lblDistance.Text = "Distance :";
            // 
            // lbxSecteursAjouterLiaison
            // 
            this.lbxSecteursAjouterLiaison.FormattingEnabled = true;
            this.lbxSecteursAjouterLiaison.Location = new System.Drawing.Point(16, 36);
            this.lbxSecteursAjouterLiaison.Name = "lbxSecteursAjouterLiaison";
            this.lbxSecteursAjouterLiaison.Size = new System.Drawing.Size(102, 238);
            this.lbxSecteursAjouterLiaison.TabIndex = 12;
            // 
            // lblSecteursAjouterLiaison
            // 
            this.lblSecteursAjouterLiaison.AutoSize = true;
            this.lblSecteursAjouterLiaison.Location = new System.Drawing.Point(13, 10);
            this.lblSecteursAjouterLiaison.Name = "lblSecteursAjouterLiaison";
            this.lblSecteursAjouterLiaison.Size = new System.Drawing.Size(55, 13);
            this.lblSecteursAjouterLiaison.TabIndex = 11;
            this.lblSecteursAjouterLiaison.Text = "Secteurs :";
            // 
            // btnAjouterLiaison
            // 
            this.btnAjouterLiaison.Location = new System.Drawing.Point(335, 250);
            this.btnAjouterLiaison.Name = "btnAjouterLiaison";
            this.btnAjouterLiaison.Size = new System.Drawing.Size(70, 23);
            this.btnAjouterLiaison.TabIndex = 10;
            this.btnAjouterLiaison.Text = "Ajouter";
            this.btnAjouterLiaison.UseVisualStyleBackColor = true;
            this.btnAjouterLiaison.Click += new System.EventHandler(this.btnAjouterLiaison_Click);
            // 
            // tbxDistance
            // 
            this.tbxDistance.Location = new System.Drawing.Point(335, 192);
            this.tbxDistance.Name = "tbxDistance";
            this.tbxDistance.Size = new System.Drawing.Size(70, 20);
            this.tbxDistance.TabIndex = 9;
            this.tbxDistance.TextChanged += new System.EventHandler(this.tbxDistance_TextChanged);
            // 
            // FormAjouterLiaison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 284);
            this.Controls.Add(this.lblDepart);
            this.Controls.Add(this.cmbDepart);
            this.Controls.Add(this.lblArrivee);
            this.Controls.Add(this.cmbArrivee);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.lbxSecteursAjouterLiaison);
            this.Controls.Add(this.lblSecteursAjouterLiaison);
            this.Controls.Add(this.btnAjouterLiaison);
            this.Controls.Add(this.tbxDistance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAjouterLiaison";
            this.Text = "Ajouter une liaison";
            this.Load += new System.EventHandler(this.FormAjouterLiaison_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.ComboBox cmbDepart;
        private System.Windows.Forms.Label lblArrivee;
        private System.Windows.Forms.ComboBox cmbArrivee;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.ListBox lbxSecteursAjouterLiaison;
        private System.Windows.Forms.Label lblSecteursAjouterLiaison;
        private System.Windows.Forms.Button btnAjouterLiaison;
        private System.Windows.Forms.TextBox tbxDistance;
    }
}