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
    public partial class FormAfficherTraversees : Form
    {
        public FormAfficherTraversees()
        {
            InitializeComponent();
        }

        private Categorie[] tabCat = new Categorie[10]; //tableau contenant les catégories chargées à l'ouverture de la fenêtre

        private int getQuantiteEnregistree(int notraversee, string lettrecategorie)
        {// fonction qui pour un notraversee et une lettrecategorie retourne le nb de places enregistrées (dans les enregistrements de cette traversée)

            MySqlDataReader jeuEnr = null;
            MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            
            try
            {
                maCnx.Open();

                string requete = "SELECT sum(quantite)'nbplacesOQP' FROM traversee t, reservation r, enregistrer e WHERE t.notraversee = r.notraversee AND r.noreservation = e.noreservation AND t.notraversee = @NOTRAVERSEE AND e.lettrecategorie = @LETTRECATEGORIE;";
                var maCde = new MySqlCommand(requete, maCnx);

                maCde.Parameters.AddWithValue("@NOTRAVERSEE", notraversee);
                maCde.Parameters.AddWithValue("@LETTRECATEGORIE", lettrecategorie);

                jeuEnr = maCde.ExecuteReader();

                jeuEnr.Read();

                if(jeuEnr["nbplacesOQP"].ToString() != "") //si le nombre de personnes enregistrées dans la catégorie n'est pas égal à 0 (= le SUM(quantite) renvoie 'null')
                {
                    return jeuEnr.GetInt32("nbplacesOQP"); //on renvoie ce nombre
                }
                else { return 0; } //sinon on renvoie 0
                
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erreur : " + e.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -10000;
            }
            finally
            {
                if (maCnx is object & maCnx.State == ConnectionState.Open)
                {
                    maCnx.Close();
                }
            }
        }

        private int getCapaciteMaximale(int notraversee, string lettrecategorie)
        {// fonction qui pour un notraversee et une lettrecategorie retourne le nb de places maximales (dans la catégorie en question par rapport au bateau de la traversée)

            MySqlDataReader jeuEnr = null;
            MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");

            try
            {
                maCnx.Open();

                string requete = "SELECT c.capacitemax FROM contenir c, bateau b, traversee t WHERE c.nobateau = b.nobateau AND b.nobateau = t.nobateau AND t.notraversee = @NOTRAVERSEE AND c.lettrecategorie = @LETTRECATEGORIE";
                var maCde = new MySqlCommand(requete, maCnx);

                maCde.Parameters.AddWithValue("@NOTRAVERSEE", notraversee);
                maCde.Parameters.AddWithValue("@LETTRECATEGORIE", lettrecategorie);

                jeuEnr = maCde.ExecuteReader();

                if(jeuEnr.Read())
                {
                    return jeuEnr.GetInt32("capacitemax");
                }
                else { return 0; }
                
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Erreur : " + e.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                if (maCnx is object & maCnx.State == ConnectionState.Open)
                {
                    maCnx.Close();
                }
            }
        }

        private void FormAfficherTraversees_Load(object sender, EventArgs ea)
        {
            lvTraversees.View = View.Details; //Paramétrage listview des traversées
            lvTraversees.GridLines = true; //
            lvTraversees.FullRowSelect = true;
            lvTraversees.Columns.Add("N°", 42); //Ajout des trois premières entêtes en dur
            lvTraversees.Columns.Add("Heure", 50); //
            lvTraversees.Columns.Add("Bateau", 75); //
            dateDateAfficherTraversees.Value = DateTime.Now; //Actualise la valeur par défaut du calendrier à celle d'aujourd'hui

            MySqlDataReader jeuEnr = null;
            MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                maCnx.Open();

                string requete = "SELECT * FROM categorie"; //On va chercher toutes les catégories de passagers

                var maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();

                int x = 0; //compteur d'incrémentation

                while (jeuEnr.Read()) //tant qu'on trouve une catégorie
                {
                    lvTraversees.Columns.Add(jeuEnr.GetString("lettrecategorie") + " - " + jeuEnr.GetString("libelle"), 85); //on ajoute une entête à son nom
                    tabCat[x] = new Categorie(jeuEnr.GetString("lettrecategorie"), jeuEnr.GetString("libelle")); //et on l'ajoute au tableau
                    x++; //on incrémente le compteur de 1
                }

                maCnx.Close();
                maCnx.Open();

                requete = "SELECT * FROM secteur"; //On va chercher tous les secteurs (avec leur numéro)

                maCde = new MySqlCommand(requete, maCnx);

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    Secteur secteur = new Secteur(jeuEnr.GetInt32("nosecteur"), jeuEnr.GetString("nom"));
                    lbxSecteursAfficherTraversees.Items.Add(secteur); //on ajoute le secteur dans la listbox dédiée
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
                    //maCnx.Close();
                }
            }
        }

        private void lbxSecteursAfficherTraversees_SelectedIndexChanged(object sender, EventArgs ea) //Quand l'index de secteur sélectionné change
        {
            cmbLiaisonAfficherTraversees.Items.Clear();
            MySqlDataReader jeuEnr = null;
            MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
            try
            {
                maCnx.Open();

                string requete = "SELECT l.noliaison, l.nosecteur, pd.nom 'nomport_depart', pa.nom 'nomport_arrivee', l.distance FROM liaison l, port pd, port pa WHERE l.noport_depart = pd.noport AND l.noport_arrivee = pa.noport AND nosecteur = @NOSECTEUR";
                //requete qui va chercher les informations essentielles d'une traversée (dont le nom des ports de départ et arrivée)
                var maCde = new MySqlCommand(requete, maCnx);

                maCde.Parameters.AddWithValue("@NOSECTEUR", ((Secteur)lbxSecteursAfficherTraversees.SelectedItem).GetNoSecteur());

                jeuEnr = maCde.ExecuteReader();

                while (jeuEnr.Read())
                {
                    Liaison liaison = new Liaison(jeuEnr.GetInt32("noliaison"), jeuEnr.GetInt32("nosecteur"), jeuEnr.GetString("nomport_depart"), jeuEnr.GetString("nomport_arrivee"), jeuEnr.GetInt32("distance"));
                    cmbLiaisonAfficherTraversees.Items.Add(liaison); //ajout de la liaison à la combobox
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAfficherTraversees_Click(object sender, EventArgs ea) //Quand on appuie sur le bouton
        {
            if (cmbLiaisonAfficherTraversees.SelectedItem != null)
            {
                MySqlDataReader jeuEnr = null;
                MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                try
                {
                    lvTraversees.Items.Clear(); //On clear le tableau

                    maCnx.Open();

                    string requete = "SELECT t.notraversee, t.dateheuredepart, b.nobateau, b.nom 'nombateau' FROM traversee t, bateau b WHERE t.nobateau = b.nobateau AND t.noliaison = @NOLIAISON AND t.dateheuredepart LIKE @DATE GROUP BY t.notraversee";
                    //on va chercher de quoi remplir les 3 premières colonnes (notraversee, heure de départ, nombateau) ainsi que le nobateau qui servira pour les catégories           en groupant par traversée (chaque traversée est unique)

                    var maCde = new MySqlCommand(requete, maCnx);

                    maCde.Parameters.AddWithValue("@NOLIAISON", ((Liaison)cmbLiaisonAfficherTraversees.SelectedItem).GetNoLiaison()); //no liaison de la liaison sélectionnée
                    maCde.Parameters.AddWithValue("@DATE", dateDateAfficherTraversees.Value.ToString("yyyy-MM-dd") + "%"); //date choisie

                    jeuEnr = maCde.ExecuteReader();

                    if(jeuEnr.Read())
                    {
                        while (jeuEnr.Read()) //tant qu'on trouve une traversée
                        {
                            var tabItem = new string[3 + tabCat.Length]; //tabItem pour l'insertion des données dans la listview

                            tabItem[0] = jeuEnr["notraversee"].ToString(); //première colonne
                            tabItem[1] = ((DateTime)jeuEnr["dateheuredepart"]).ToString("HH:mm"); //deuxième colonne
                            tabItem[2] = jeuEnr["nombateau"].ToString(); //troisième colonne

                            int x = 3; //incrémenteur

                            foreach (Categorie cat in tabCat) //pour chaque catégorie dans la table des catégories
                            {
                                if (cat != null) //si la catégorie n'est pas vide
                                {
                                    int difference = getCapaciteMaximale(jeuEnr.GetInt32("notraversee"), cat.GetLettre()) - getQuantiteEnregistree(jeuEnr.GetInt32("notraversee"), cat.GetLettre());
                                    //Différence entre capacitemax et quantiteenregistree
                                    tabItem[x] = difference.ToString();
                                    x += 1;
                                }
                            }
                            ListViewItem Item = new ListViewItem(tabItem);
                            lvTraversees.Items.Add(Item); //ajout de la ligne dans la listview
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aucune donnée trouvée.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                MessageBox.Show("Veuillez sélectionner une liaison.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
