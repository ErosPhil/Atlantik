
namespace Atlantik
{
    partial class FormAjouterTarifs
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
            this.lbxSecteursAjouterTarifs = new System.Windows.Forms.ListBox();
            this.lblSecteursAjouterTarifs = new System.Windows.Forms.Label();
            this.cmbLiaisonAjouterTarifs = new System.Windows.Forms.ComboBox();
            this.lblLiaisonAjouterTarifs = new System.Windows.Forms.Label();
            this.lblPeriodeAjouterTarifs = new System.Windows.Forms.Label();
            this.cmbPeriodeAjouterTarifs = new System.Windows.Forms.ComboBox();
            this.btnAjouterTarifs = new System.Windows.Forms.Button();
            this.gbxTarifsCategorieType = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // lbxSecteursAjouterTarifs
            // 
            this.lbxSecteursAjouterTarifs.FormattingEnabled = true;
            this.lbxSecteursAjouterTarifs.Location = new System.Drawing.Point(15, 37);
            this.lbxSecteursAjouterTarifs.Name = "lbxSecteursAjouterTarifs";
            this.lbxSecteursAjouterTarifs.Size = new System.Drawing.Size(117, 238);
            this.lbxSecteursAjouterTarifs.TabIndex = 4;
            this.lbxSecteursAjouterTarifs.SelectedIndexChanged += new System.EventHandler(this.lbxSecteursAjouterTarifs_SelectedIndexChanged);
            // 
            // lblSecteursAjouterTarifs
            // 
            this.lblSecteursAjouterTarifs.AutoSize = true;
            this.lblSecteursAjouterTarifs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSecteursAjouterTarifs.Location = new System.Drawing.Point(12, 9);
            this.lblSecteursAjouterTarifs.Name = "lblSecteursAjouterTarifs";
            this.lblSecteursAjouterTarifs.Size = new System.Drawing.Size(55, 13);
            this.lblSecteursAjouterTarifs.TabIndex = 3;
            this.lblSecteursAjouterTarifs.Text = "Secteurs :";
            // 
            // cmbLiaisonAjouterTarifs
            // 
            this.cmbLiaisonAjouterTarifs.FormattingEnabled = true;
            this.cmbLiaisonAjouterTarifs.Location = new System.Drawing.Point(15, 322);
            this.cmbLiaisonAjouterTarifs.Name = "cmbLiaisonAjouterTarifs";
            this.cmbLiaisonAjouterTarifs.Size = new System.Drawing.Size(128, 21);
            this.cmbLiaisonAjouterTarifs.TabIndex = 9;
            // 
            // lblLiaisonAjouterTarifs
            // 
            this.lblLiaisonAjouterTarifs.AutoSize = true;
            this.lblLiaisonAjouterTarifs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLiaisonAjouterTarifs.Location = new System.Drawing.Point(12, 296);
            this.lblLiaisonAjouterTarifs.Name = "lblLiaisonAjouterTarifs";
            this.lblLiaisonAjouterTarifs.Size = new System.Drawing.Size(46, 13);
            this.lblLiaisonAjouterTarifs.TabIndex = 8;
            this.lblLiaisonAjouterTarifs.Text = "Liaison :";
            // 
            // lblPeriodeAjouterTarifs
            // 
            this.lblPeriodeAjouterTarifs.AutoSize = true;
            this.lblPeriodeAjouterTarifs.Location = new System.Drawing.Point(12, 402);
            this.lblPeriodeAjouterTarifs.Name = "lblPeriodeAjouterTarifs";
            this.lblPeriodeAjouterTarifs.Size = new System.Drawing.Size(49, 13);
            this.lblPeriodeAjouterTarifs.TabIndex = 10;
            this.lblPeriodeAjouterTarifs.Text = "Période :";
            // 
            // cmbPeriodeAjouterTarifs
            // 
            this.cmbPeriodeAjouterTarifs.FormattingEnabled = true;
            this.cmbPeriodeAjouterTarifs.Location = new System.Drawing.Point(99, 399);
            this.cmbPeriodeAjouterTarifs.Name = "cmbPeriodeAjouterTarifs";
            this.cmbPeriodeAjouterTarifs.Size = new System.Drawing.Size(163, 21);
            this.cmbPeriodeAjouterTarifs.TabIndex = 11;
            // 
            // btnAjouterTarifs
            // 
            this.btnAjouterTarifs.Location = new System.Drawing.Point(325, 397);
            this.btnAjouterTarifs.Name = "btnAjouterTarifs";
            this.btnAjouterTarifs.Size = new System.Drawing.Size(119, 23);
            this.btnAjouterTarifs.TabIndex = 12;
            this.btnAjouterTarifs.Text = "Ajouter";
            this.btnAjouterTarifs.UseVisualStyleBackColor = true;
            this.btnAjouterTarifs.Click += new System.EventHandler(this.btnAjouterTarifs_Click);
            // 
            // gbxTarifsCategorieType
            // 
            this.gbxTarifsCategorieType.Location = new System.Drawing.Point(198, 9);
            this.gbxTarifsCategorieType.Name = "gbxTarifsCategorieType";
            this.gbxTarifsCategorieType.Size = new System.Drawing.Size(246, 334);
            this.gbxTarifsCategorieType.TabIndex = 13;
            this.gbxTarifsCategorieType.TabStop = false;
            this.gbxTarifsCategorieType.Text = "Tarifs par Catégorie-Type";
            // 
            // FormAjouterTarifs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 450);
            this.Controls.Add(this.gbxTarifsCategorieType);
            this.Controls.Add(this.btnAjouterTarifs);
            this.Controls.Add(this.cmbPeriodeAjouterTarifs);
            this.Controls.Add(this.lblPeriodeAjouterTarifs);
            this.Controls.Add(this.cmbLiaisonAjouterTarifs);
            this.Controls.Add(this.lblLiaisonAjouterTarifs);
            this.Controls.Add(this.lbxSecteursAjouterTarifs);
            this.Controls.Add(this.lblSecteursAjouterTarifs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAjouterTarifs";
            this.Text = "Ajouter les tarifs pour une liaison et une période";
            this.Load += new System.EventHandler(this.FormAjouterTarifs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxSecteursAjouterTarifs;
        private System.Windows.Forms.Label lblSecteursAjouterTarifs;
        private System.Windows.Forms.ComboBox cmbLiaisonAjouterTarifs;
        private System.Windows.Forms.Label lblLiaisonAjouterTarifs;
        private System.Windows.Forms.Label lblPeriodeAjouterTarifs;
        private System.Windows.Forms.ComboBox cmbPeriodeAjouterTarifs;
        private System.Windows.Forms.Button btnAjouterTarifs;
        private System.Windows.Forms.GroupBox gbxTarifsCategorieType;
    }
}