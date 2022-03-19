using System;
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
    public partial class FormAjouterBateau : Form
    {
        public FormAjouterBateau()
        {
            InitializeComponent();
        }

        private void FormAjouterBateau_Load(object sender, EventArgs ea)
        {
            MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                maCnx.Open();

                string requete = "SELECT * FROM categorie";

                var maCde = new MySqlCommand(requete, maCnx);

                MySqlDataReader jeuEnr = maCde.ExecuteReader();

                int i = 0; //incrémenteur

                while (jeuEnr.Read())
                {
                    Categorie categorie = new Categorie(jeuEnr["lettrecategorie"].ToString(), jeuEnr["libelle"].ToString());

                    Label label = new Label();
                    label.Name = "lbl" + categorie.GetLettre() + categorie.GetLibelle() + "AjouterBateau"; //lblAPassagerAjouterBateau
                    label.Text = categorie.ToString() + " :"; //A (Passager) :
                    label.Location = new Point(15, i * 35 + 35);
                    gbxCapMaxAjouterBateau.Controls.Add(label);

                    TextBox textbox = new TextBox();
                    textbox.Name = "tbx" + categorie.GetLettre() + categorie.GetLibelle() + "AjouterBateau"; //tbxAPassagerAjouterBateau
                    textbox.Location = new Point(135, i * 35 + 35);
                    textbox.Multiline = true;
                    textbox.Width = 75;
                    textbox.Tag = categorie.GetLettre(); //on stock la lettrecategorie dans le Tag afin de pouvoir l'utiliser par rapport à la textbox lors de l'insertion
                    gbxCapMaxAjouterBateau.Controls.Add(textbox);
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

        private void btnAjouterBateau_Click(object sender, EventArgs ea)
        {
            var Textboxes = gbxCapMaxAjouterBateau.Controls.OfType<TextBox>(); //on va chercher toutes les textbox des catégories dans la groupbox
            bool vide = false;
            foreach (TextBox tbx in Textboxes)
            {
                var objetRegEx = new Regex(@"^*[0-9]+$");
                var test = objetRegEx.Match(tbx.Text);

                if (tbx.Text == "" || !test.Success) { vide = true; }
            }

            if (tbxNomAjouterBateau.Text != "" && vide == false)
            {
                DialogResult retour = MessageBox.Show("Êtes-vous sûr de vouloir insérer le bateau " + tbxNomAjouterBateau.Text + " ?", "Confirmation avant ajout", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (retour == DialogResult.Yes)
                {
                    MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                    try
                    {
                        maCnx.Open();

                        string requete = "INSERT INTO bateau(nom) VALUES(@NOMBATEAU)";

                        var maCde = new MySqlCommand(requete, maCnx);

                        maCde.Parameters.AddWithValue("@NOMBATEAU", tbxNomAjouterBateau.Text);

                        maCde.ExecuteNonQuery();

                        long dernierID = maCde.LastInsertedId; //on récupère l'id du bateau qui vient d'être ajouté dans la table bateau

                        tbxNomAjouterBateau.Clear();

                        requete = "INSERT INTO contenir(lettrecategorie, nobateau, capacitemax) VALUES(@LETTRECATEGORIE, @NOBATEAU, @CAPACITEMAX)";

                        maCde = new MySqlCommand(requete, maCnx);

                        foreach (TextBox tbx in Textboxes)
                        {
                            maCde.Parameters.AddWithValue("@LETTRECATEGORIE", tbx.Tag);
                            maCde.Parameters.AddWithValue("@NOBATEAU", dernierID);
                            maCde.Parameters.AddWithValue("@CAPACITEMAX", tbx.Text);
                            maCde.ExecuteNonQuery();
                            maCde.Parameters.Clear();
                            tbx.Clear();
                        }
                        MessageBox.Show("Ajout effectué", "Confirmation après ajout", MessageBoxButtons.OK);
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
        private void gbxCapMaxAjouterBateau_Enter(object sender, EventArgs e)
        {

        }
    }
}
