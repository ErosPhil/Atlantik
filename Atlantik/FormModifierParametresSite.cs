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
    public partial class FormModifierParametresSite : Form
    {
        MySqlConnection maCnx;
        public FormModifierParametresSite()
        {
            InitializeComponent();
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
        }

        private void FormModifierParametresSite_Load(object sender, EventArgs ea)
        {
            Label labelSite = new Label();
            labelSite.Text = "Site :";
            labelSite.Location = new Point(15, 20);
            gbxIdentifiants.Controls.Add(labelSite);

            Label labelRang = new Label();
            labelRang.Text = "Rang :";
            labelRang.Location = new Point(15, 55);
            gbxIdentifiants.Controls.Add(labelRang);

            Label labelIdentifiant = new Label();
            labelIdentifiant.Text = "Identifiant :";
            labelIdentifiant.Location = new Point(15, 90);
            gbxIdentifiants.Controls.Add(labelIdentifiant);

            Label labelCleHMAC = new Label();
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

                if (jeuEnr.Read())
                {
                    TextBox textboxSite = new TextBox();
                    textboxSite.Text = jeuEnr.GetString("site_pb");
                    textboxSite.Location = new Point(130, 20);
                    textboxSite.Width = 70;
                    textboxSite.Tag = "@SITEPB";
                    gbxIdentifiants.Controls.Add(textboxSite);

                    TextBox textboxRang = new TextBox();
                    textboxRang.Text = jeuEnr.GetString("rang_pb");
                    textboxRang.Location = new Point(130, 55);
                    textboxRang.Width = 50;
                    textboxRang.Tag = "@RANGPB";
                    gbxIdentifiants.Controls.Add(textboxRang);

                    TextBox textboxIdentifiant = new TextBox();
                    textboxIdentifiant.Text = jeuEnr.GetString("identifiant_pb");
                    textboxIdentifiant.Location = new Point(130, 90);
                    textboxIdentifiant.Width = 80;
                    textboxIdentifiant.Tag = "@IDENTIFIANTPB";
                    gbxIdentifiants.Controls.Add(textboxIdentifiant);

                    TextBox textboxCleHMAC = new TextBox();
                    textboxCleHMAC.Multiline = true;
                    textboxCleHMAC.Text = jeuEnr.GetString("clehmac_pb");
                    textboxCleHMAC.Location = new Point(130, 125);
                    textboxCleHMAC.Width = 130;
                    textboxCleHMAC.Height = 130;
                    textboxCleHMAC.Tag = "@CLEHMACPB";
                    gbxIdentifiants.Controls.Add(textboxCleHMAC);

                    if (jeuEnr.GetBoolean("enproduction") == true) { cbxEnProduction.Checked = true; }

                    tbxMelSite.Text = jeuEnr.GetString("melsite");
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
            //pas de vérification des textboxes car dans la BDD tous les éléments de parametres sont des chaînes de charactères et peuvent être NULL (excepté le noidentifiant);
            var lesTextboxes = gbxIdentifiants.Controls.OfType<TextBox>();
            DialogResult retour = MessageBox.Show("Êtes-vous sûr de vouloir modifier les paramètres du site ?", "Confirmation avant modification", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (retour == DialogResult.Yes)
            {
                try
                {
                    maCnx.Open();
                    string requete = "UPDATE parametres SET site_pb = @SITEPB, rang_pb = @RANGPB, identifiant_pb = @IDENTIFIANTPB, clehmac_pb = @CLEHMACPB, enproduction = @ENPRODUCTION, melsite = @MELSITE";

                    var maCde = new MySqlCommand(requete, maCnx);

                    foreach (TextBox tbx in lesTextboxes)
                    {
                        maCde.Parameters.AddWithValue(tbx.Tag.ToString(), tbx.Text);
                    }
                    maCde.Parameters.AddWithValue("@ENPRODUCTION", cbxEnProduction.Checked);
                    maCde.Parameters.AddWithValue("@MELSITE", tbxMelSite.Text);
                    maCde.ExecuteNonQuery();

                    MessageBox.Show("Modification des paramètres du site", "Confirmation après modification", MessageBoxButtons.OK);
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
}
