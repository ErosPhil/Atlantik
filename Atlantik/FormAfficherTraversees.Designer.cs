
namespace Atlantik
{
    partial class FormAfficherTraversees
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
            this.lblSecteursAfficherTraversees = new System.Windows.Forms.Label();
            this.lbxSecteursAfficherTraversees = new System.Windows.Forms.ListBox();
            this.lblLiaisonAfficherTraversees = new System.Windows.Forms.Label();
            this.cmbLiaisonAfficherTraversees = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateDateAfficherTraversees = new System.Windows.Forms.DateTimePicker();
            this.btnAfficherTraversees = new System.Windows.Forms.Button();
            this.lvTraversees = new System.Windows.Forms.ListView();
            this.lblTraversee = new System.Windows.Forms.Label();
            this.lblPlacesDispoCat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSecteursAfficherTraversees
            // 
            this.lblSecteursAfficherTraversees.AutoSize = true;
            this.lblSecteursAfficherTraversees.Location = new System.Drawing.Point(12, 9);
            this.lblSecteursAfficherTraversees.Name = "lblSecteursAfficherTraversees";
            this.lblSecteursAfficherTraversees.Size = new System.Drawing.Size(55, 13);
            this.lblSecteursAfficherTraversees.TabIndex = 0;
            this.lblSecteursAfficherTraversees.Text = "Secteurs :";
            // 
            // lbxSecteursAfficherTraversees
            // 
            this.lbxSecteursAfficherTraversees.FormattingEnabled = true;
            this.lbxSecteursAfficherTraversees.Location = new System.Drawing.Point(15, 36);
            this.lbxSecteursAfficherTraversees.Name = "lbxSecteursAfficherTraversees";
            this.lbxSecteursAfficherTraversees.Size = new System.Drawing.Size(117, 238);
            this.lbxSecteursAfficherTraversees.TabIndex = 3;
            this.lbxSecteursAfficherTraversees.SelectedIndexChanged += new System.EventHandler(this.lbxSecteursAfficherTraversees_SelectedIndexChanged);
            // 
            // lblLiaisonAfficherTraversees
            // 
            this.lblLiaisonAfficherTraversees.AutoSize = true;
            this.lblLiaisonAfficherTraversees.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLiaisonAfficherTraversees.Location = new System.Drawing.Point(12, 290);
            this.lblLiaisonAfficherTraversees.Name = "lblLiaisonAfficherTraversees";
            this.lblLiaisonAfficherTraversees.Size = new System.Drawing.Size(46, 13);
            this.lblLiaisonAfficherTraversees.TabIndex = 7;
            this.lblLiaisonAfficherTraversees.Text = "Liaison :";
            // 
            // cmbLiaisonAfficherTraversees
            // 
            this.cmbLiaisonAfficherTraversees.FormattingEnabled = true;
            this.cmbLiaisonAfficherTraversees.Location = new System.Drawing.Point(15, 316);
            this.cmbLiaisonAfficherTraversees.Name = "cmbLiaisonAfficherTraversees";
            this.cmbLiaisonAfficherTraversees.Size = new System.Drawing.Size(128, 21);
            this.cmbLiaisonAfficherTraversees.TabIndex = 8;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDate.Location = new System.Drawing.Point(237, 36);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(152, 13);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "Date (par défaut date du jour) :";
            // 
            // dateDateAfficherTraversees
            // 
            this.dateDateAfficherTraversees.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDateAfficherTraversees.Location = new System.Drawing.Point(433, 30);
            this.dateDateAfficherTraversees.Name = "dateDateAfficherTraversees";
            this.dateDateAfficherTraversees.Size = new System.Drawing.Size(104, 20);
            this.dateDateAfficherTraversees.TabIndex = 10;
            this.dateDateAfficherTraversees.Value = new System.DateTime(2021, 7, 10, 11, 14, 0, 0);
            // 
            // btnAfficherTraversees
            // 
            this.btnAfficherTraversees.Location = new System.Drawing.Point(231, 89);
            this.btnAfficherTraversees.Name = "btnAfficherTraversees";
            this.btnAfficherTraversees.Size = new System.Drawing.Size(202, 23);
            this.btnAfficherTraversees.TabIndex = 11;
            this.btnAfficherTraversees.Text = "Afficher les traversées";
            this.btnAfficherTraversees.UseVisualStyleBackColor = true;
            this.btnAfficherTraversees.Click += new System.EventHandler(this.btnAfficherTraversees_Click);
            // 
            // lvTraversees
            // 
            this.lvTraversees.HideSelection = false;
            this.lvTraversees.Location = new System.Drawing.Point(149, 191);
            this.lvTraversees.Name = "lvTraversees";
            this.lvTraversees.Size = new System.Drawing.Size(426, 181);
            this.lvTraversees.TabIndex = 12;
            this.lvTraversees.UseCompatibleStateImageBehavior = false;
            this.lvTraversees.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // lblTraversee
            // 
            this.lblTraversee.AutoSize = true;
            this.lblTraversee.Location = new System.Drawing.Point(146, 175);
            this.lblTraversee.Name = "lblTraversee";
            this.lblTraversee.Size = new System.Drawing.Size(55, 13);
            this.lblTraversee.TabIndex = 13;
            this.lblTraversee.Text = "Traversée";
            // 
            // lblPlacesDispoCat
            // 
            this.lblPlacesDispoCat.AutoSize = true;
            this.lblPlacesDispoCat.Location = new System.Drawing.Point(322, 175);
            this.lblPlacesDispoCat.Name = "lblPlacesDispoCat";
            this.lblPlacesDispoCat.Size = new System.Drawing.Size(159, 13);
            this.lblPlacesDispoCat.TabIndex = 14;
            this.lblPlacesDispoCat.Text = "Places disponibles par catégorie";
            // 
            // FormAfficherTraversees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 394);
            this.Controls.Add(this.lblPlacesDispoCat);
            this.Controls.Add(this.lblTraversee);
            this.Controls.Add(this.lvTraversees);
            this.Controls.Add(this.btnAfficherTraversees);
            this.Controls.Add(this.dateDateAfficherTraversees);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbLiaisonAfficherTraversees);
            this.Controls.Add(this.lblLiaisonAfficherTraversees);
            this.Controls.Add(this.lbxSecteursAfficherTraversees);
            this.Controls.Add(this.lblSecteursAfficherTraversees);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAfficherTraversees";
            this.Text = "Afficher les traversées pour une liaison et une date donnée avec places restantes" +
    " par catégorie";
            this.Load += new System.EventHandler(this.FormAfficherTraversees_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSecteursAfficherTraversees;
        private System.Windows.Forms.ListBox lbxSecteursAfficherTraversees;
        private System.Windows.Forms.Label lblLiaisonAfficherTraversees;
        private System.Windows.Forms.ComboBox cmbLiaisonAfficherTraversees;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateDateAfficherTraversees;
        private System.Windows.Forms.Button btnAfficherTraversees;
        private System.Windows.Forms.ListView lvTraversees;
        private System.Windows.Forms.Label lblTraversee;
        private System.Windows.Forms.Label lblPlacesDispoCat;
    }
}