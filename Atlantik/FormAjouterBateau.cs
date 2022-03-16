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
            MySqlDataReader jeuEnr = null;
            MySqlConnection maCnx;
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");

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
                    label.Name = "lbl" + categorie.GetLettre() + categorie.GetLibelle() + "AjouterBateau";
                    label.Text = categorie.ToString() + " :";
                    label.Location = new Point(15, i * 35 + 35);
                    gbxCapMaxAjouterBateau.Controls.Add(label);

                    TextBox textbox = new TextBox();
                    textbox.Name = "tbx" + categorie.GetLettre() + categorie.GetLibelle() + "AjouterBateau";
                    textbox.Location = new Point(135, i * 35 + 35);
                    textbox.Multiline = true;
                    textbox.Width = 75;
                    textbox.Tag = categorie.GetLettre();
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
        }//Load

        private void btnAjouterBateau_Click(object sender, EventArgs ea)
        {
            MySqlConnection maCnx;
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requete;
                maCnx.Open();

                requete = "INSERT INTO bateau(nom) VALUES(@NOMBATEAU)";

                var maCde = new MySqlCommand(requete, maCnx);

                maCde.Parameters.AddWithValue("@NOMBATEAU", tbxNomAjouterBateau.Text);

                maCde.ExecuteNonQuery();

                long dernierID = maCde.LastInsertedId;
                //MessageBox.Show(lastinsertedID.ToString());

                tbxNomAjouterBateau.Clear();

                requete = "INSERT INTO contenir(lettrecategorie, nobateau, capacitemax) VALUES(@LETTRECATEGORIE, @NOBATEAU, @CAPACITEMAX)";

                maCde = new MySqlCommand(requete, maCnx);

                var Textboxes = gbxCapMaxAjouterBateau.Controls.OfType<TextBox>();

                foreach(TextBox tbx in Textboxes)
                {
                    maCde.Parameters.AddWithValue("@LETTRECATEGORIE", tbx.Tag);
                    maCde.Parameters.AddWithValue("@NOBATEAU", dernierID);
                    maCde.Parameters.AddWithValue("@CAPACITEMAX", tbx.Text);
                    maCde.ExecuteNonQuery();
                    maCde.Parameters.Clear();
                    tbx.Clear();
                }
                MessageBox.Show("Ajout effectué", "Ajout d'un bateau", MessageBoxButtons.OK);
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

        private void gbxCapMaxAjouterBateau_Enter(object sender, EventArgs e)
        {

        }
    }
}
