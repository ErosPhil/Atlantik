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
    public partial class FormAjouterTarifs : Form
    {
        MySqlConnection maCnx;
        public FormAjouterTarifs()
        {
            InitializeComponent();
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
        }

        private void FormAjouterTarifs_Load(object sender, EventArgs ea)
        {
            MySqlDataReader jeuEnr = null;
            try
            {
                maCnx.Open();

                string requete = "SELECT * FROM periode";

                var maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    Periode periode = new Periode(jeuEnr.GetInt32("noperiode"), jeuEnr.GetDateTime("datedebut"), jeuEnr.GetDateTime("datefin"));
                    cmbPeriodeAjouterTarifs.Items.Add(periode);
                }

                maCnx.Close();
                maCnx.Open();

                requete = "SELECT * FROM secteur";

                maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    Secteur secteur = new Secteur(jeuEnr.GetInt32("nosecteur"), jeuEnr.GetString("nom"));
                    lbxSecteursAjouterTarifs.Items.Add(secteur);
                }

                maCnx.Close();

                Label label1 = new Label();
                label1.Text = "Catégorie - Type";
                label1.Location = new Point(10, 20);
                gbxTarifsCategorieType.Controls.Add(label1);

                Label label2 = new Label();
                label2.Text = "Tarif";
                label2.Location = new Point(150, 20);
                label2.Width = 60;
                gbxTarifsCategorieType.Controls.Add(label2);

                maCnx.Open();

                requete = "SELECT * FROM type";

                maCde = new MySqlCommand(requete, maCnx);
                    
                jeuEnr = maCde.ExecuteReader();

                int i = 0;

                while(jeuEnr.Read())
                {
                    int ecartTextboxesEtLablels = 44;
                    if (i > 10)
                    {
                        this.Size = new Size(477, 489 + (i-10) * ecartTextboxesEtLablels);
                        lblPeriodeAjouterTarifs.Location = new Point(12, 402 + (i- 10) * ecartTextboxesEtLablels);
                        cmbPeriodeAjouterTarifs.Location = new Point(99, 399 + (i-10) * ecartTextboxesEtLablels);
                        btnAjouterTarifs.Location = new Point(325, 397 + (i-10) * ecartTextboxesEtLablels);
                        gbxTarifsCategorieType.Size = new Size(246, 349 + (i-10) * ecartTextboxesEtLablels);
                    }

                    CategorieType categorietype = new CategorieType(jeuEnr.GetString("lettrecategorie"), jeuEnr.GetInt32("notype"), jeuEnr.GetString("libelle"));

                    Label label = new Label();
                    label.Text = categorietype.ToString() + " :";
                    label.Location = new Point(10, i * 29 + ecartTextboxesEtLablels+1);
                    label.Width = 145;
                    gbxTarifsCategorieType.Controls.Add(label);

                    TextBox textbox = new TextBox();
                    textbox.Location = new Point(155, i * 29 + ecartTextboxesEtLablels);
                    textbox.Multiline = true;
                    textbox.Width = 75;
                    textbox.Tag = categorietype;
                    gbxTarifsCategorieType.Controls.Add(textbox);
                    i++;
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

        private void lbxSecteursAjouterTarifs_SelectedIndexChanged(object sender, EventArgs ea)
        {
            cmbLiaisonAjouterTarifs.Items.Clear();
            MySqlDataReader jeuEnr = null;
            try
            {
                maCnx.Open();

                string requete = "SELECT l.noliaison, l.nosecteur, pd.nom 'nomport_depart', pa.nom 'nomport_arrivee', l.distance FROM liaison l, port pd, port pa WHERE l.noport_depart = pd.noport AND l.noport_arrivee = pa.noport AND nosecteur = @NOSECTEUR";
                //requete qui va chercher les informations essentielles d'une traversée (dont le nom des ports de départ et arrivée)

                var maCde = new MySqlCommand(requete, maCnx);

                maCde.Parameters.AddWithValue("@NOSECTEUR", ((Secteur)lbxSecteursAjouterTarifs.SelectedItem).GetNoSecteur());

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    Liaison liaison = new Liaison(jeuEnr.GetInt32("noliaison"), jeuEnr.GetInt32("nosecteur"), jeuEnr.GetString("nomport_depart"), jeuEnr.GetString("nomport_arrivee"), jeuEnr.GetInt32("distance"));
                    cmbLiaisonAjouterTarifs.Items.Add(liaison);
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

        private void btnAjouterTarifs_Click(object sender, EventArgs ea)
        {
            var lesTextboxes = gbxTarifsCategorieType.Controls.OfType<TextBox>();
            bool vide = false;
            foreach (TextBox tbx in lesTextboxes)
            {
                var objetRegEx = new Regex(@"^*[0-9]+$");
                var test = objetRegEx.Match(tbx.Text);

                if (tbx.Text == "" || !test.Success) { vide = true; }
            }

            if (cmbLiaisonAjouterTarifs.SelectedItem != null && cmbPeriodeAjouterTarifs.SelectedItem != null && lbxSecteursAjouterTarifs.SelectedItem != null && vide == false)
            {
                DialogResult retour = MessageBox.Show("Êtes-vous sûr de vouloir ajouter les tarifs entrés pour la liaison " + ((Liaison)cmbLiaisonAjouterTarifs.SelectedItem).ToString() + " du secteur " + ((Secteur)lbxSecteursAjouterTarifs.SelectedItem).ToString() + " pour la période du " + ((Periode)cmbPeriodeAjouterTarifs.SelectedItem).ToString() + " ?", "Confirmation avant ajout", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (retour == DialogResult.Yes)
                {
                    try
                    {
                        maCnx.Open();

                        string requete = "INSERT INTO tarifer(noperiode, lettrecategorie, notype, noliaison, tarif) VALUES(@NOPERIODE, @LETTRECATEGORIE, @NOTYPE, @NOLIAISON, @TARIF)";

                        var maCde = new MySqlCommand(requete, maCnx);

                        foreach (TextBox tbx in lesTextboxes)
                        {
                            maCde.Parameters.AddWithValue("@NOPERIODE", ((Periode)cmbPeriodeAjouterTarifs.SelectedItem).GetNoPeriode());
                            maCde.Parameters.AddWithValue("@LETTRECATEGORIE", ((CategorieType)tbx.Tag).GetLettreCategorie());
                            maCde.Parameters.AddWithValue("@NOTYPE", ((CategorieType)tbx.Tag).GetNoType());
                            maCde.Parameters.AddWithValue("@NOLIAISON", ((Liaison)cmbLiaisonAjouterTarifs.SelectedItem).GetNoLiaison());
                            maCde.Parameters.AddWithValue("@TARIF", tbx.Text);

                            maCde.ExecuteNonQuery();
                            maCde.Parameters.Clear();
                            tbx.Clear();
                        }
                        MessageBox.Show("Ajout des tarifs effectué", "Confirmation après ajout", MessageBoxButtons.OK);
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
