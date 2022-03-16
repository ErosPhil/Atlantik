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
    public partial class FormAjouterLiaison : Form
    {
        public FormAjouterLiaison()
        {
            InitializeComponent();
        }

        private void FormAjouterLiaison_Load(object sender, EventArgs ea)
        {
            MySqlDataReader jeuEnr = null;
            MySqlConnection maCnx;
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requete;
                maCnx.Open();

                requete = "SELECT * FROM secteur"; //on va chercher tous les secteurs que l'on veut ensuite afficher dans la listbox

                var maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read()) //tant que l'on trouve des lignes dans la table secteur de la BDD
                {
                    Secteur secteur = new Secteur(jeuEnr.GetInt32("nosecteur"), jeuEnr.GetString("nom"));
                    lbxSecteursAjouterLiaison.Items.Add(secteur); //on les ajoute à la listbox
                }

                maCnx.Close();
                maCnx.Open();

                requete = "SELECT * FROM port"; //on va chercher tous les ports que l'on veut ensuite afficher dans les combobox Depart et Arrivee

                maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read()) //tant que l'on trouve des lignes dans la table port de la BDD
                {
                    Port port = new Port(jeuEnr.GetInt32("noport"), jeuEnr.GetString("nom"));
                    cmbDepart.Items.Add(port); //on les ajoute aux combobox Depart
                    cmbArrivee.Items.Add(port);// et Arrivee
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

        private void btnAjouterLiaison_Click(object sender, EventArgs ea)
        {
            var objetRegEx = new Regex(@"^*[0-9]+$"); //on retrouve le même test que l'on utilise pour vérifier
            var test = objetRegEx.Match(tbxDistance.Text); //que l'on a bien ce que l'on veut dans la text box

            if (test.Success && tbxDistance.Text != "" && cmbDepart.SelectedItem != null && cmbArrivee.SelectedItem != null)
            {
                MySqlConnection maCnx;
                maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");

                try
                {
                    string requete;
                    maCnx.Open();

                    requete = "INSERT INTO liaison(nosecteur, noport_depart, noport_arrivee, distance) VALUES(@NOSECTEUR, @NOPORTDEPART, @NOPORTARRIVEE, @DISTANCE)";

                    var maCde = new MySqlCommand(requete, maCnx);

                    maCde.Parameters.AddWithValue("@NOSECTEUR", ((Secteur)lbxSecteursAjouterLiaison.SelectedItem).GetNoSecteur());
                    maCde.Parameters.AddWithValue("@NOPORTDEPART", ((Port)cmbDepart.SelectedItem).GetNoPort());
                    maCde.Parameters.AddWithValue("@NOPORTARRIVEE", ((Port)cmbArrivee.SelectedItem).GetNoPort());
                    maCde.Parameters.AddWithValue("@DISTANCE", double.Parse(tbxDistance.Text));

                    maCde.ExecuteNonQuery();

                    tbxDistance.Clear();

                    MessageBox.Show("Ajout effectué", "Ajout d'une liaison", MessageBoxButtons.OK);
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

        private void tbxDistance_TextChanged(object sender, EventArgs e)
        {
            var objetRegEx = new Regex(@"^*[0-9]+$"); //que les chiffres de 0 à 9 et la virgule
            var test = objetRegEx.Match(tbxDistance.Text);

            if (test.Success | tbxDistance.Text == "") //si le test est réussi ou que la textbox est vide
            {
                tbxDistance.BackColor = Color.White; //fond blanc
            }
            else
            {
                tbxDistance.BackColor = Color.Red; //fond rouge
            }
        }
    }
}
