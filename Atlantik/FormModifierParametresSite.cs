﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.Text.RegularExpressions;

namespace Atlantik
{
    public partial class FormModifierParametresSite : Form
    {
        MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");

        public FormModifierParametresSite()
        {
            InitializeComponent();
        }

        private void FormModifierParametresSite_Load(object sender, EventArgs ea)
        {
            Label labelSite = new Label();
            labelSite.Name = "lblSite";
            labelSite.Text = "Site :";
            labelSite.Location = new Point(15, 20);
            gbxIdentifiants.Controls.Add(labelSite);

            Label labelRang = new Label();
            labelRang.Name = "lblRang";
            labelRang.Text = "Rang :";
            labelRang.Location = new Point(15, 55);
            gbxIdentifiants.Controls.Add(labelRang);

            Label labelIdentifiant = new Label();
            labelIdentifiant.Name = "lblIdentifiant";
            labelIdentifiant.Text = "Identifiant :";
            labelIdentifiant.Location = new Point(15, 90);
            gbxIdentifiants.Controls.Add(labelIdentifiant);

            Label labelCleHMAC = new Label();
            labelCleHMAC.Name = "lblCleHMAC";
            labelCleHMAC.Text = "Clé HMAC :";
            labelCleHMAC.Location = new Point(15, 125);
            gbxIdentifiants.Controls.Add(labelCleHMAC);

            MySqlDataReader jeuEnr = null;
            try
            {
                maCnx.Open();

                string requete = "SELECT * FROM parametres";

                var maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();

                if(jeuEnr.Read())
                {
                    TextBox textboxSite = new TextBox();
                    textboxSite.Name = "tbxSite";
                    textboxSite.Text = jeuEnr.GetString("site_pb");
                    textboxSite.Location = new Point(130, 20);
                    textboxSite.Width = 70;
                    textboxSite.Tag = "@SITEPB";
                    gbxIdentifiants.Controls.Add(textboxSite);

                    TextBox textboxRang = new TextBox();
                    textboxRang.Name = "tbxRang";
                    textboxRang.Text = jeuEnr.GetString("rang_pb");
                    textboxRang.Location = new Point(130, 55);
                    textboxRang.Width = 50;
                    textboxRang.Tag = "@RANGPB";
                    gbxIdentifiants.Controls.Add(textboxRang);

                    TextBox textboxIdentifiant = new TextBox();
                    textboxIdentifiant.Name = "tbxIdentifiant";
                    textboxIdentifiant.Text = jeuEnr.GetString("identifiant_pb");
                    textboxIdentifiant.Location = new Point(130, 90);
                    textboxIdentifiant.Width = 80;
                    textboxIdentifiant.Tag = "@IDENTIFIANTPB";
                    gbxIdentifiants.Controls.Add(textboxIdentifiant);

                    TextBox textboxCleHMAC = new TextBox();
                    textboxCleHMAC.Multiline = true;
                    textboxCleHMAC.Name = "tbxCleHMAC";
                    textboxCleHMAC.Text = jeuEnr.GetString("clehmac_pb");
                    textboxCleHMAC.Location = new Point(130, 125);
                    textboxCleHMAC.Width = 130;
                    textboxCleHMAC.Height = 130;
                    textboxCleHMAC.Tag = "@CLEHMACPB";
                    gbxIdentifiants.Controls.Add(textboxCleHMAC);

                    if (jeuEnr.GetBoolean("enproduction") == true) { cbxEnProduction.Checked = true; }
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erreur : " + e.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (maCnx is object & maCnx.State == ConnectionState.Open)
                {
                    maCnx.Close();
                }
            }

        }

        private void btnModifierParametresSite_Click(object sender, EventArgs ea)
        {
            try
            {
                maCnx.Open();

                string requete = "UPDATE parametres SET site_pb = @SITEPB AND rang_pb = @RANGPB AND identifiant_pb = @IDENTIFIANTPB AND clehmac_pb = @CLEHMACPB AND enproduction = @ENPRODUCTION AND melsite = @MELSITE WHERE noidentifiant = @NOIDENTIFIANT";

                var maCde = new MySqlCommand(requete, maCnx);

                maCde.Parameters.AddWithValue("@NOIDENTIFIANT", 160);

                var Textboxes = gbxIdentifiants.Controls.OfType<TextBox>();

                foreach(TextBox tbx in Textboxes)
                {
                    maCde.Parameters.AddWithValue(tbx.Tag.ToString(), tbx.Text);
                }
                maCde.Parameters.AddWithValue("@ENPRODUCTION", cbxEnProduction.Checked);
                maCde.Parameters.AddWithValue("@MELSITE", tbxMelSite.Text);
                maCde.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erreur : " + e.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (maCnx is object & maCnx.State == ConnectionState.Open)
                {
                    maCnx.Close();
                }
            }
        }
    }
}