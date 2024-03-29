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
    public partial class FormModifierBateau : Form
    {
        MySqlConnection maCnx;
        public FormModifierBateau()
        {
            InitializeComponent();
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
        }

        private void FormModifierBateau_Load(object sender, EventArgs ea)
        {
            MySqlDataReader jeuEnr = null;
            try
            {
                string requete;
                maCnx.Open();

                requete = "SELECT * FROM categorie";

                var maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();

                int i = 0;

                while (jeuEnr.Read())
                {
                    Categorie categorie = new Categorie(jeuEnr["lettrecategorie"].ToString(), jeuEnr["libelle"].ToString());

                    Label label = new Label();
                    label.Text = categorie.ToString() + " :";
                    label.Location = new Point(15, i * 35 + 35);
                    gbxCapMaxModifierBateau.Controls.Add(label);

                    TextBox textbox = new TextBox();
                    textbox.Location = new Point(135, i * 35 + 35);
                    textbox.Multiline = true;
                    textbox.Width = 75;
                    textbox.Tag = categorie.GetLettre();
                    gbxCapMaxModifierBateau.Controls.Add(textbox);
                    i++;
                }

                maCnx.Close();
                maCnx.Open();

                requete = "SELECT * FROM bateau";

                maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    Bateau bateau = new Bateau(jeuEnr.GetInt32("nobateau"), jeuEnr.GetString("nom"));
                    cbxModifierBateau.Items.Add(bateau);
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

        private void cbxModifierBateau_SelectedIndexChanged(object sender, EventArgs ea)
        {
            var lesTextboxes = gbxCapMaxModifierBateau.Controls.OfType<TextBox>();
            foreach (TextBox tbx in lesTextboxes)
            {
                tbx.Clear();
            }
            MySqlDataReader jeuEnr = null;
            try
            {
                string requete;
                maCnx.Open();

                requete = "SELECT * FROM contenir WHERE nobateau LIKE @NOBATEAU";

                var maCde = new MySqlCommand(requete, maCnx);

                maCde.Parameters.AddWithValue("@NOBATEAU", ((Bateau)cbxModifierBateau.SelectedItem).GetNoBateau());

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    foreach(TextBox tbx in lesTextboxes)
                    {
                        if ((string)tbx.Tag == jeuEnr.GetString("lettrecategorie") )
                        {
                            tbx.Text = jeuEnr.GetString("capacitemax");
                        }
                        
                        if (tbx.Text == "")
                        {
                            tbx.Text = "0";
                        }
                    }
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

        private void btnModifierBateau_Click(object sender, EventArgs ea)
        {
            var lesTextboxes = gbxCapMaxModifierBateau.Controls.OfType<TextBox>();
            bool valide = false;
            foreach (TextBox tbx in lesTextboxes)
            {
                var objetRegEx = new Regex(@"^*[0-9]+$");
                var test = objetRegEx.Match(tbx.Text);

                if (!test.Success) { valide = true; }
            }

            if (cbxModifierBateau.SelectedItem != null && valide == false)
            {
                DialogResult retour = MessageBox.Show("Êtes-vous sûr de vouloir modifier le bateau " + ((Bateau)cbxModifierBateau.SelectedItem).ToString() + " ?", "Confirmation avant modification", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (retour == DialogResult.Yes)
                {
                    MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                    try
                    {
                        maCnx.Open();

                        string requete = "UPDATE contenir SET capacitemax = @CAPACITEMAX WHERE nobateau = @NOBATEAU AND lettrecategorie = @LETTRECATEGORIE";

                        var maCde = new MySqlCommand(requete, maCnx);

                        foreach (TextBox tbx in lesTextboxes)
                        {
                            maCde.Parameters.AddWithValue("@CAPACITEMAX", tbx.Text);
                            maCde.Parameters.AddWithValue("@NOBATEAU", ((Bateau)cbxModifierBateau.SelectedItem).GetNoBateau());
                            maCde.Parameters.AddWithValue("@LETTRECATEGORIE", tbx.Tag);
                            maCde.ExecuteNonQuery();
                            maCde.Parameters.Clear();
                        }
                        MessageBox.Show("Modification des tarifs du bateau effectuée", "Confirmation après modification", MessageBoxButtons.OK);
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
            else { MessageBox.Show("L'un des champs est vide ou incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
