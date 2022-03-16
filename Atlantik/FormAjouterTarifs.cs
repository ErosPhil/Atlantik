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
    public partial class FormAjouterTarifs : Form
    {
        public FormAjouterTarifs()
        {
            InitializeComponent();
        }

        private void FormAjouterTarifs_Load(object sender, EventArgs ea)
        {
            MySqlDataReader jeuEnr = null;
            MySqlConnection maCnx;
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");

            try
            {
                string requete;
                maCnx.Open();

                requete = "SELECT * FROM periode";

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
                label1.Name = "lblTitreCategorieType";
                label1.Text = "Catégorie - Type";
                label1.Location = new Point(10, 20);
                gbxTarifsCategorieType.Controls.Add(label1);

                Label label2 = new Label();
                label2.Name = "lblTitreTarif";
                label2.Text = "Tarif";
                label2.Location = new Point(140, 20);
                gbxTarifsCategorieType.Controls.Add(label2);

                maCnx.Open();

                requete = "SELECT * FROM type";

                maCde = new MySqlCommand(requete, maCnx);
                    
                jeuEnr = maCde.ExecuteReader();

                int i = 0;

                while(jeuEnr.Read())
                {
                    CategorieType categorietype = new CategorieType(jeuEnr.GetString("lettrecategorie"), jeuEnr.GetInt32("notype"), jeuEnr.GetString("libelle"));

                    Label label = new Label();
                    label.Name = "lbl" + categorietype.GetLettreCategorie() + categorietype.GetNoType().ToString() + categorietype.GetLibelle() + "AjouterTarifs";
                    label.Text = categorietype.ToString() + " :";
                    label.Location = new Point(10, i * 30 + 45);
                    label.Width = 130;
                    gbxTarifsCategorieType.Controls.Add(label);

                    TextBox textbox = new TextBox();
                    textbox.Name = "tbx" + categorietype.GetLettreCategorie() + categorietype.GetNoType().ToString() + categorietype.GetLibelle() + "AjouterTarifs";
                    textbox.Location = new Point(140, i * 30 + 45);
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
            MySqlConnection maCnx;
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");

            try
            {
                string requete;
                maCnx.Open();

                requete = "SELECT l.noliaison, l.nosecteur, pd.nom 'nomport_depart', pa.nom 'nomport_arrivee', l.distance FROM liaison l, port pd, port pa WHERE l.noport_depart = pd.noport AND l.noport_arrivee = pa.noport AND nosecteur = @NOSECTEUR";
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
            MySqlConnection maCnx;
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                string requete;
                maCnx.Open();

                requete = "INSERT INTO tarifer(noperiode, lettrecategorie, notype, noliaison, tarif) VALUES(@NOPERIODE, @LETTRECATEGORIE, @NOTYPE, @NOLIAISON, @TARIF)";

                var maCde = new MySqlCommand(requete, maCnx);

                var Textboxes = gbxTarifsCategorieType.Controls.OfType<TextBox>();

                foreach (TextBox tbx in Textboxes)
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
                MessageBox.Show("Ajouts effectués", "Ajouts de Tarifs", MessageBoxButtons.OK);
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
