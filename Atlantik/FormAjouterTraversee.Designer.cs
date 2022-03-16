
namespace Atlantik
{
    partial class FormAjouterTraversee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAjouterTraversee));
            this.lblSecteursAjouterTraversee = new System.Windows.Forms.Label();
            this.lblNomBateauAjouterTraversee = new System.Windows.Forms.Label();
            this.lbxSecteursAjouterTraversee = new System.Windows.Forms.ListBox();
            this.lblDateEtHeureArrivee = new System.Windows.Forms.Label();
            this.lblDateEtHeureDepart = new System.Windows.Forms.Label();
            this.cmbBateauAjouterTraversee = new System.Windows.Forms.ComboBox();
            this.lblLiaisonAjouterTraversee = new System.Windows.Forms.Label();
            this.cmbLiaisonAjouterTraversee = new System.Windows.Forms.ComboBox();
            this.btnAjouterTraversee = new System.Windows.Forms.Button();
            this.dateDepart = new System.Windows.Forms.DateTimePicker();
            this.dateArrivee = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblSecteursAjouterTraversee
            // 
            resources.ApplyResources(this.lblSecteursAjouterTraversee, "lblSecteursAjouterTraversee");
            this.lblSecteursAjouterTraversee.Name = "lblSecteursAjouterTraversee";
            this.lblSecteursAjouterTraversee.Click += new System.EventHandler(this.lblSecteursAjouterTraversee_Click);
            // 
            // lblNomBateauAjouterTraversee
            // 
            resources.ApplyResources(this.lblNomBateauAjouterTraversee, "lblNomBateauAjouterTraversee");
            this.lblNomBateauAjouterTraversee.Name = "lblNomBateauAjouterTraversee";
            // 
            // lbxSecteursAjouterTraversee
            // 
            this.lbxSecteursAjouterTraversee.FormattingEnabled = true;
            resources.ApplyResources(this.lbxSecteursAjouterTraversee, "lbxSecteursAjouterTraversee");
            this.lbxSecteursAjouterTraversee.Name = "lbxSecteursAjouterTraversee";
            this.lbxSecteursAjouterTraversee.SelectedIndexChanged += new System.EventHandler(this.lbxSecteursAjouterTraversee_SelectedIndexChanged);
            // 
            // lblDateEtHeureArrivee
            // 
            resources.ApplyResources(this.lblDateEtHeureArrivee, "lblDateEtHeureArrivee");
            this.lblDateEtHeureArrivee.Name = "lblDateEtHeureArrivee";
            // 
            // lblDateEtHeureDepart
            // 
            resources.ApplyResources(this.lblDateEtHeureDepart, "lblDateEtHeureDepart");
            this.lblDateEtHeureDepart.Name = "lblDateEtHeureDepart";
            // 
            // cmbBateauAjouterTraversee
            // 
            this.cmbBateauAjouterTraversee.FormattingEnabled = true;
            resources.ApplyResources(this.cmbBateauAjouterTraversee, "cmbBateauAjouterTraversee");
            this.cmbBateauAjouterTraversee.Name = "cmbBateauAjouterTraversee";
            // 
            // lblLiaisonAjouterTraversee
            // 
            resources.ApplyResources(this.lblLiaisonAjouterTraversee, "lblLiaisonAjouterTraversee");
            this.lblLiaisonAjouterTraversee.Name = "lblLiaisonAjouterTraversee";
            // 
            // cmbLiaisonAjouterTraversee
            // 
            this.cmbLiaisonAjouterTraversee.FormattingEnabled = true;
            resources.ApplyResources(this.cmbLiaisonAjouterTraversee, "cmbLiaisonAjouterTraversee");
            this.cmbLiaisonAjouterTraversee.Name = "cmbLiaisonAjouterTraversee";
            this.cmbLiaisonAjouterTraversee.SelectedIndexChanged += new System.EventHandler(this.cmbLiaisonAjouterTraversee_SelectedIndexChanged);
            // 
            // btnAjouterTraversee
            // 
            resources.ApplyResources(this.btnAjouterTraversee, "btnAjouterTraversee");
            this.btnAjouterTraversee.Name = "btnAjouterTraversee";
            this.btnAjouterTraversee.UseVisualStyleBackColor = true;
            this.btnAjouterTraversee.Click += new System.EventHandler(this.btnAjouterTraversee_Click);
            // 
            // dateDepart
            // 
            this.dateDepart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.dateDepart, "dateDepart");
            this.dateDepart.Name = "dateDepart";
            // 
            // dateArrivee
            // 
            this.dateArrivee.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.dateArrivee, "dateArrivee");
            this.dateArrivee.Name = "dateArrivee";
            // 
            // FormAjouterTraversee
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateArrivee);
            this.Controls.Add(this.dateDepart);
            this.Controls.Add(this.btnAjouterTraversee);
            this.Controls.Add(this.cmbLiaisonAjouterTraversee);
            this.Controls.Add(this.lblLiaisonAjouterTraversee);
            this.Controls.Add(this.cmbBateauAjouterTraversee);
            this.Controls.Add(this.lblDateEtHeureDepart);
            this.Controls.Add(this.lblDateEtHeureArrivee);
            this.Controls.Add(this.lbxSecteursAjouterTraversee);
            this.Controls.Add(this.lblNomBateauAjouterTraversee);
            this.Controls.Add(this.lblSecteursAjouterTraversee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAjouterTraversee";
            this.Load += new System.EventHandler(this.FormAjouterTraversee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNomBateauAjouterTraversee;
        private System.Windows.Forms.Label lblSecteursAjouterTraversee;
        private System.Windows.Forms.ListBox lbxSecteursAjouterTraversee;
        private System.Windows.Forms.Label lblDateEtHeureArrivee;
        private System.Windows.Forms.Label lblDateEtHeureDepart;
        private System.Windows.Forms.ComboBox cmbBateauAjouterTraversee;
        private System.Windows.Forms.Label lblLiaisonAjouterTraversee;
        private System.Windows.Forms.ComboBox cmbLiaisonAjouterTraversee;
        private System.Windows.Forms.Button btnAjouterTraversee;
        private System.Windows.Forms.DateTimePicker dateDepart;
        private System.Windows.Forms.DateTimePicker dateArrivee;
    }
}