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
    public partial class FormAjouterSecteur : Form
    {
        public FormAjouterSecteur()
        {
            InitializeComponent();
        }

        private void FormAjouterSecteur_Load(object sender, EventArgs e)
        {

        }

        private void tbxNomSecteur_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAjouterSecteur_Click_1(object sender, EventArgs ea)
        {
            var objetRegEx = new Regex("^[a-zA-Zéèêëçàâôù ûïî-]*$");
            var test = objetRegEx.Match(tbxNomSecteur.Text);

            if (test.Success && tbxNomSecteur.Text != "")
            {
                DialogResult retour = MessageBox.Show("Êtes-vous sûr de vouloir ajouter le secteur " + tbxNomSecteur.Text + " ?", "Confirmation avant ajout", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (retour == DialogResult.Yes)
                {
                    MySqlConnection maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
                    try
                    {
                        maCnx.Open();

                        string requete = "INSERT INTO secteur(nom) VALUES (@NOMSECTEUR)";

                        var maCde = new MySqlCommand(requete, maCnx);

                        maCde.Parameters.AddWithValue("@NOMSECTEUR", tbxNomSecteur.Text);

                        maCde.ExecuteNonQuery();

                        tbxNomSecteur.Clear();
                        MessageBox.Show("Ajout du secteur effectué", "Confirmation après ajout", MessageBoxButtons.OK);
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
