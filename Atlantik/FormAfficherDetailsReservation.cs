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
    public partial class FormAfficherDetailsReservation : Form
    {
        public FormAfficherDetailsReservation()
        {
            InitializeComponent();
        }

        private void FormAfficherDetailsReservation_Load(object sender, EventArgs ea)
        {
            lvReservations.View = View.Details;
            lvReservations.GridLines = true;
            lvReservations.FullRowSelect = true;
            lvReservations.BorderStyle = BorderStyle.FixedSingle;
            lvReservations.Columns.Add("n° Réservation", 82);
            lvReservations.Columns.Add("Liaison", 160);
            lvReservations.Columns.Add("n° Traversée", 60);
            lvReservations.Columns.Add("Date départ", 124);

            MySqlDataReader jeuEnr = null;
            MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                maCnx.Open();

                string requete = "SELECT * FROM client";

                var maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    Client client = new Client(jeuEnr.GetInt32("noclient"), jeuEnr.GetString("nom"), jeuEnr.GetString("prenom"));
                    cmbClient.Items.Add(client);
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

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs ea)
        {
            lvReservations.Items.Clear();
            MySqlDataReader jeuEnr = null;
            MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                maCnx.Open();

                string requete = "SELECT r.noreservation, pd.nom 'nomport_depart', pa.nom 'nomport_arrivee', r.notraversee, t.dateheuredepart FROM reservation r, port pd, port pa, liaison l, traversee t WHERE r.notraversee = t.notraversee AND t.noliaison = l.noliaison AND l.noport_depart = pd.noport AND l.noport_arrivee = pa.noport AND r.noclient = @NOCLIENT";
                //requête qui va chercher les éléments à afficher dans la listview des réservations
                var maCde = new MySqlCommand(requete, maCnx);

                maCde.Parameters.AddWithValue("@NOCLIENT", ((Client)cmbClient.SelectedItem).GetNoClient());

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    var tabItem = new string[4];
                    tabItem[0] = jeuEnr["noreservation"].ToString();
                    tabItem[1] = jeuEnr["nomport_depart"].ToString() + " - " + jeuEnr["nomport_arrivee"].ToString();
                    tabItem[2] = jeuEnr["notraversee"].ToString();
                    tabItem[3] = ((DateTime)jeuEnr["dateheuredepart"]).ToString("dd/MM/yyyy") + " à " + ((DateTime)jeuEnr["dateheuredepart"]).ToString("HH") + "h" + ((DateTime)jeuEnr["dateheuredepart"]).ToString("mm");

                    ListViewItem Item = new ListViewItem(tabItem);
                    lvReservations.Items.Add(Item);
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

        private void lvReservations_SelectedIndexChanged(object sender, EventArgs ea)
        {
            if (lvReservations.SelectedItems.Count > 0 )
            {
                gbxDetailsReservation.Controls.Clear();
                MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                try
                {
                    maCnx.Open();

                    string requete = "SELECT t.libelle, e.quantite FROM type t, enregistrer e WHERE e.lettrecategorie = t.lettrecategorie AND e.notype = t.notype AND noreservation = @NORESERVATION";
                    //requête qui va chercher les éléments à afficher dans la listview des réservations

                    var maCde = new MySqlCommand(requete, maCnx);

                    maCde.Parameters.AddWithValue("@NORESERVATION", lvReservations.SelectedItems[0].SubItems[0].Text);

                    MySqlDataReader jeuEnr = null;
                    jeuEnr = maCde.ExecuteReader();

                    int x = 0;
                    while (jeuEnr.Read())
                    {
                        Label labelLibelle = new Label();
                        labelLibelle.Name = "lbl" + jeuEnr["libelle"].ToString();
                        labelLibelle.Text = jeuEnr["libelle"].ToString();
                        labelLibelle.Location = new Point(25, 25 + x*21);
                        gbxDetailsReservation.Controls.Add(labelLibelle);

                        Label labelQuantite = new Label();
                        labelQuantite.Name = "lblQuantite" + jeuEnr["libelle"].ToString();
                        labelQuantite.Text = ": " + jeuEnr["quantite"].ToString();
                        labelQuantite.Location = new Point(160, 25 + x*21);
                        gbxDetailsReservation.Controls.Add(labelQuantite);

                        x++;
                    }

                    maCnx.Close();
                    maCnx.Open();

                    requete = "SELECT montanttotal, paye, modereglement FROM reservation WHERE noreservation = @NORESERVATION";

                    maCde = new MySqlCommand(requete, maCnx);

                    maCde.Parameters.AddWithValue("@NORESERVATION", lvReservations.SelectedItems[0].SubItems[0].Text);

                    jeuEnr = maCde.ExecuteReader();

                    jeuEnr.Read();

                    Label labelMT = new Label();
                    labelMT.Name = "lblMT";
                    labelMT.Text = "Montant total : ";
                    labelMT.Location = new Point(25, 40 + x * 21);
                    gbxDetailsReservation.Controls.Add(labelMT);

                    Label labelMontantTotal = new Label();
                    labelMontantTotal.Name = "lblMontantTotal";
                    labelMontantTotal.Text = jeuEnr["montanttotal"].ToString() + " euros";
                    labelMontantTotal.Location = new Point(166, 40 + x * 21);
                    gbxDetailsReservation.Controls.Add(labelMontantTotal);

                    x++;

                    Label labelReglement = new Label();
                    labelReglement.Name = "lblReglement";
                    labelReglement.Location = new Point(20, 60 + x * 21);
                    labelReglement.Width = 250;

                    if (jeuEnr.GetBoolean("paye") == false)
                    {
                        labelReglement.Text = "Pas réglé";
                    }
                    else
                    {
                        if(jeuEnr["modereglement"].ToString() == "")
                        {
                            labelReglement.Text = "Réglé (moyen de règlement non renseigné)";
                        }
                        else
                        {
                            labelReglement.Text = "Réglé par " + jeuEnr["modereglement"].ToString();
                        }
                    }
                    gbxDetailsReservation.Controls.Add(labelReglement);
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
