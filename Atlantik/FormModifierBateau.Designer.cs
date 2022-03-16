
namespace Atlantik
{
    partial class FormModifierBateau
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
            this.gbxCapMaxModifierBateau = new System.Windows.Forms.GroupBox();
            this.btnModifierBateau = new System.Windows.Forms.Button();
            this.lblNomModifierBateau = new System.Windows.Forms.Label();
            this.cbxModifierBateau = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // gbxCapMaxModifierBateau
            // 
            this.gbxCapMaxModifierBateau.Location = new System.Drawing.Point(215, 11);
            this.gbxCapMaxModifierBateau.Name = "gbxCapMaxModifierBateau";
            this.gbxCapMaxModifierBateau.Size = new System.Drawing.Size(227, 277);
            this.gbxCapMaxModifierBateau.TabIndex = 11;
            this.gbxCapMaxModifierBateau.TabStop = false;
            this.gbxCapMaxModifierBateau.Text = "Capacités Maximales";
            // 
            // btnModifierBateau
            // 
            this.btnModifierBateau.Location = new System.Drawing.Point(90, 265);
            this.btnModifierBateau.Name = "btnModifierBateau";
            this.btnModifierBateau.Size = new System.Drawing.Size(119, 23);
            this.btnModifierBateau.TabIndex = 10;
            this.btnModifierBateau.Text = "Modifier";
            this.btnModifierBateau.UseVisualStyleBackColor = true;
            this.btnModifierBateau.Click += new System.EventHandler(this.btnModifierBateau_Click);
            // 
            // lblNomModifierBateau
            // 
            this.lblNomModifierBateau.AutoSize = true;
            this.lblNomModifierBateau.Location = new System.Drawing.Point(13, 14);
            this.lblNomModifierBateau.Name = "lblNomModifierBateau";
            this.lblNomModifierBateau.Size = new System.Drawing.Size(71, 13);
            this.lblNomModifierBateau.TabIndex = 8;
            this.lblNomModifierBateau.Text = "Nom bateau :";
            // 
            // cbxModifierBateau
            // 
            this.cbxModifierBateau.FormattingEnabled = true;
            this.cbxModifierBateau.Location = new System.Drawing.Point(107, 11);
            this.cbxModifierBateau.Name = "cbxModifierBateau";
            this.cbxModifierBateau.Size = new System.Drawing.Size(66, 21);
            this.cbxModifierBateau.TabIndex = 12;
            this.cbxModifierBateau.SelectedIndexChanged += new System.EventHandler(this.cbxModifierBateau_SelectedIndexChanged);
            // 
            // FormModifierBateau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 299);
            this.Controls.Add(this.cbxModifierBateau);
            this.Controls.Add(this.gbxCapMaxModifierBateau);
            this.Controls.Add(this.btnModifierBateau);
            this.Controls.Add(this.lblNomModifierBateau);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormModifierBateau";
            this.Text = "Modifier un bateau";
            this.Load += new System.EventHandler(this.FormModifierBateau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCapMaxModifierBateau;
        private System.Windows.Forms.Button btnModifierBateau;
        private System.Windows.Forms.Label lblNomModifierBateau;
        private System.Windows.Forms.ComboBox cbxModifierBateau;
    }
}