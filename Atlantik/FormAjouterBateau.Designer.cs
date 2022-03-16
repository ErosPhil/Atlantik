
namespace Atlantik
{
    partial class FormAjouterBateau
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
            this.gbxCapMaxAjouterBateau = new System.Windows.Forms.GroupBox();
            this.btnAjouterBateau = new System.Windows.Forms.Button();
            this.tbxNomAjouterBateau = new System.Windows.Forms.TextBox();
            this.lblNomAjouterBateau = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gbxCapMaxAjouterBateau
            // 
            this.gbxCapMaxAjouterBateau.Location = new System.Drawing.Point(215, 11);
            this.gbxCapMaxAjouterBateau.Name = "gbxCapMaxAjouterBateau";
            this.gbxCapMaxAjouterBateau.Size = new System.Drawing.Size(227, 277);
            this.gbxCapMaxAjouterBateau.TabIndex = 7;
            this.gbxCapMaxAjouterBateau.TabStop = false;
            this.gbxCapMaxAjouterBateau.Text = "Capacités Maximales";
            this.gbxCapMaxAjouterBateau.Enter += new System.EventHandler(this.gbxCapMaxAjouterBateau_Enter);
            // 
            // btnAjouterBateau
            // 
            this.btnAjouterBateau.Location = new System.Drawing.Point(90, 265);
            this.btnAjouterBateau.Name = "btnAjouterBateau";
            this.btnAjouterBateau.Size = new System.Drawing.Size(119, 23);
            this.btnAjouterBateau.TabIndex = 6;
            this.btnAjouterBateau.Text = "Ajouter";
            this.btnAjouterBateau.UseVisualStyleBackColor = true;
            this.btnAjouterBateau.Click += new System.EventHandler(this.btnAjouterBateau_Click);
            // 
            // tbxNomAjouterBateau
            // 
            this.tbxNomAjouterBateau.Location = new System.Drawing.Point(90, 11);
            this.tbxNomAjouterBateau.Name = "tbxNomAjouterBateau";
            this.tbxNomAjouterBateau.Size = new System.Drawing.Size(119, 20);
            this.tbxNomAjouterBateau.TabIndex = 5;
            // 
            // lblNomAjouterBateau
            // 
            this.lblNomAjouterBateau.AutoSize = true;
            this.lblNomAjouterBateau.Location = new System.Drawing.Point(13, 14);
            this.lblNomAjouterBateau.Name = "lblNomAjouterBateau";
            this.lblNomAjouterBateau.Size = new System.Drawing.Size(71, 13);
            this.lblNomAjouterBateau.TabIndex = 4;
            this.lblNomAjouterBateau.Text = "Nom bateau :";
            // 
            // FormAjouterBateau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 299);
            this.Controls.Add(this.gbxCapMaxAjouterBateau);
            this.Controls.Add(this.btnAjouterBateau);
            this.Controls.Add(this.tbxNomAjouterBateau);
            this.Controls.Add(this.lblNomAjouterBateau);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAjouterBateau";
            this.Text = "Ajouter un bateau";
            this.Load += new System.EventHandler(this.FormAjouterBateau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCapMaxAjouterBateau;
        private System.Windows.Forms.Button btnAjouterBateau;
        private System.Windows.Forms.TextBox tbxNomAjouterBateau;
        private System.Windows.Forms.Label lblNomAjouterBateau;
    }
}