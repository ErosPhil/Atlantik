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
    public partial class FormAjouterTraversee : Form
    {
        public FormAjouterTraversee()
        {
            InitializeComponent();
        }
        private void FormAjouterTraversee_Load(object sender, EventArgs ae)
        {
            dateDepart.Format = DateTimePickerFormat.Custom;
            dateDepart.CustomFormat = "ddd dd/MM/yyyy - HH:mm:ss";
            dateArrivee.Format = DateTimePickerFormat.Custom;
            dateArrivee.CustomFormat = "ddd dd/MM/yyyy - HH:mm:ss";

            MySqlDataReader jeuEnr = null;
            MySqlConnection maCnx;
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");

            try
            {
                string requete;
                maCnx.Open();

                requete = "SELECT * FROM bateau";

                var maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    Bateau bateau = new Bateau(jeuEnr.GetInt32("nobateau"), jeuEnr.GetString("nom"));
                    cmbBateauAjouterTraversee.Items.Add(bateau);
                }

                maCnx.Close();
                maCnx.Open();

                requete = "SELECT * FROM secteur";

                maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    Secteur secteur = new Secteur(jeuEnr.GetInt32("nosecteur"), jeuEnr.GetString("nom"));
                    lbxSecteursAjouterTraversee.Items.Add(secteur);
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

        private void lbxSecteursAjouterTraversee_SelectedIndexChanged(object sender, EventArgs ea)
        {
            cmbLiaisonAjouterTraversee.Items.Clear();
            MySqlDataReader jeuEnr = null;
            MySqlConnection maCnx;
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");

            try
            {
                string requete;
                maCnx.Open();

                requete = "SELECT l.noliaison, l.nosecteur, pd.nom 'nomport_depart', pa.nom 'nomport_arrivee', l.distance FROM liaison l, port pd, port pa WHERE l.noport_depart = pd.noport AND l.noport_arrivee = pa.noport AND nosecteur = @NOSECTEUR" ;
                //requete qui va chercher les informations essentielles d'une traversée (dont le nom des ports de départ et arrivée)
                var maCde = new MySqlCommand(requete, maCnx);

                maCde.Parameters.AddWithValue("@NOSECTEUR", ((Secteur)lbxSecteursAjouterTraversee.SelectedItem).GetNoSecteur());

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    Liaison liaison = new Liaison(jeuEnr.GetInt32("noliaison"),jeuEnr.GetInt32("nosecteur"),jeuEnr.GetString("nomport_depart"),jeuEnr.GetString("nomport_arrivee"),jeuEnr.GetInt32("distance"));
                    cmbLiaisonAjouterTraversee.Items.Add(liaison);
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

        private void lblSecteursAjouterTraversee_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAjouterTraversee_Click(object sender, EventArgs ea)
        {
            if ( cmbBateauAjouterTraversee.SelectedItem != null && cmbLiaisonAjouterTraversee.SelectedItem != null && lbxSecteursAjouterTraversee.SelectedItem != null && dateArrivee.Value > dateDepart.Value )
            {
                DialogResult retour = MessageBox.Show("Êtes-vous sûr de vouloir ajouter la traversée du bateau " + ((Bateau)cmbBateauAjouterTraversee.SelectedItem).ToString() + " effectuant la liaison " + ((Liaison)cmbLiaisonAjouterTraversee.SelectedItem).ToString() + " du secteur " + ((Secteur)lbxSecteursAjouterTraversee.SelectedItem).ToString() + " partant le " + dateDepart.Value + " et revenant le " + dateArrivee.Value + " ?", "Confirmation avant ajout", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (retour == DialogResult.Yes)
                {
                    MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                    try
                    {
                        maCnx.Open();

                        string requete = "INSERT INTO traversee(noliaison, nobateau, dateheuredepart, dateheurearrivee) VALUES(@NOLIAISON, @NOBATEAU, @DATEHEUREDEPART, @DATEHEUREARRIVEE)";

                        var maCde = new MySqlCommand(requete, maCnx);

                        maCde.Parameters.AddWithValue("@NOLIAISON", ((Liaison)cmbLiaisonAjouterTraversee.SelectedItem).GetNoLiaison());
                        maCde.Parameters.AddWithValue("@NOBATEAU", ((Bateau)cmbBateauAjouterTraversee.SelectedItem).GetNoBateau());
                        maCde.Parameters.AddWithValue("@DATEHEUREDEPART", DateTime.Parse(dateDepart.Value.ToString("yyyy-MM-dd HH:mm:ss")));
                        maCde.Parameters.AddWithValue("@DATEHEUREARRIVEE", DateTime.Parse(dateArrivee.Value.ToString("yyyy-MM-dd HH:mm:ss")));
                        
                        maCde.ExecuteNonQuery();
                        MessageBox.Show("Ajout de la traversée effectué", "Confirmation après ajout", MessageBoxButtons.OK);
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

        private void cmbLiaisonAjouterTraversee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
