
namespace Atlantik
{
    partial class FormAfficherDetailsReservation
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
            this.lblNomPrenom = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lvReservations = new System.Windows.Forms.ListView();
            this.gbxDetailsReservation = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // lblNomPrenom
            // 
            this.lblNomPrenom.AutoSize = true;
            this.lblNomPrenom.Location = new System.Drawing.Point(12, 9);
            this.lblNomPrenom.Name = "lblNomPrenom";
            this.lblNomPrenom.Size = new System.Drawing.Size(80, 13);
            this.lblNomPrenom.TabIndex = 0;
            this.lblNomPrenom.Text = "NOM, Prénom :";
            // 
            // cmbClient
            // 
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(95, 6);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(95, 21);
            this.cmbClient.TabIndex = 1;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // lvReservations
            // 
            this.lvReservations.HideSelection = false;
            this.lvReservations.Location = new System.Drawing.Point(235, 6);
            this.lvReservations.Name = "lvReservations";
            this.lvReservations.Size = new System.Drawing.Size(426, 117);
            this.lvReservations.TabIndex = 2;
            this.lvReservations.UseCompatibleStateImageBehavior = false;
            this.lvReservations.SelectedIndexChanged += new System.EventHandler(this.lvReservations_SelectedIndexChanged);
            // 
            // gbxDetailsReservation
            // 
            this.gbxDetailsReservation.Location = new System.Drawing.Point(301, 147);
            this.gbxDetailsReservation.Name = "gbxDetailsReservation";
            this.gbxDetailsReservation.Size = new System.Drawing.Size(278, 246);
            this.gbxDetailsReservation.TabIndex = 3;
            this.gbxDetailsReservation.TabStop = false;
            this.gbxDetailsReservation.Text = "Réservation";
            // 
            // FormAfficherDetailsReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 405);
            this.Controls.Add(this.gbxDetailsReservation);
            this.Controls.Add(this.lvReservations);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.lblNomPrenom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAfficherDetailsReservation";
            this.Text = "Afficher les détails d\'une réservation pour un client";
            this.Load += new System.EventHandler(this.FormAfficherDetailsReservation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomPrenom;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.ListView lvReservations;
        private System.Windows.Forms.GroupBox gbxDetailsReservation;
    }
}