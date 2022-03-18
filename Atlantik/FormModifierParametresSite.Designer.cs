
namespace Atlantik
{
    partial class FormModifierParametresSite
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
            this.gbxIdentifiants = new System.Windows.Forms.GroupBox();
            this.lblMelSite = new System.Windows.Forms.Label();
            this.tbxMelSite = new System.Windows.Forms.TextBox();
            this.btnModifierParametresSite = new System.Windows.Forms.Button();
            this.cbxEnProduction = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // gbxIdentifiants
            // 
            this.gbxIdentifiants.Location = new System.Drawing.Point(12, 12);
            this.gbxIdentifiants.Name = "gbxIdentifiants";
            this.gbxIdentifiants.Size = new System.Drawing.Size(275, 272);
            this.gbxIdentifiants.TabIndex = 0;
            this.gbxIdentifiants.TabStop = false;
            this.gbxIdentifiants.Text = "Identifiants PayBox";
            // 
            // lblMelSite
            // 
            this.lblMelSite.AutoSize = true;
            this.lblMelSite.Location = new System.Drawing.Point(132, 346);
            this.lblMelSite.Name = "lblMelSite";
            this.lblMelSite.Size = new System.Drawing.Size(49, 13);
            this.lblMelSite.TabIndex = 1;
            this.lblMelSite.Text = "Mél site :";
            // 
            // tbxMelSite
            // 
            this.tbxMelSite.Location = new System.Drawing.Point(187, 343);
            this.tbxMelSite.Name = "tbxMelSite";
            this.tbxMelSite.Size = new System.Drawing.Size(100, 20);
            this.tbxMelSite.TabIndex = 2;
            // 
            // btnModifierParametresSite
            // 
            this.btnModifierParametresSite.Location = new System.Drawing.Point(187, 396);
            this.btnModifierParametresSite.Name = "btnModifierParametresSite";
            this.btnModifierParametresSite.Size = new System.Drawing.Size(100, 23);
            this.btnModifierParametresSite.TabIndex = 3;
            this.btnModifierParametresSite.Text = "Modifier";
            this.btnModifierParametresSite.UseVisualStyleBackColor = true;
            this.btnModifierParametresSite.Click += new System.EventHandler(this.btnModifierParametresSite_Click);
            // 
            // cbxEnProduction
            // 
            this.cbxEnProduction.AutoSize = true;
            this.cbxEnProduction.Location = new System.Drawing.Point(195, 303);
            this.cbxEnProduction.Name = "cbxEnProduction";
            this.cbxEnProduction.Size = new System.Drawing.Size(92, 17);
            this.cbxEnProduction.TabIndex = 4;
            this.cbxEnProduction.Text = "En production";
            this.cbxEnProduction.UseVisualStyleBackColor = true;
            // 
            // FormModifierParametresSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 433);
            this.Controls.Add(this.cbxEnProduction);
            this.Controls.Add(this.btnModifierParametresSite);
            this.Controls.Add(this.tbxMelSite);
            this.Controls.Add(this.lblMelSite);
            this.Controls.Add(this.gbxIdentifiants);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormModifierParametresSite";
            this.Text = "Modifier les paramètres du site";
            this.Load += new System.EventHandler(this.FormModifierParametresSite_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxIdentifiants;
        private System.Windows.Forms.Label lblMelSite;
        private System.Windows.Forms.TextBox tbxMelSite;
        private System.Windows.Forms.Button btnModifierParametresSite;
        private System.Windows.Forms.CheckBox cbxEnProduction;
    }
}