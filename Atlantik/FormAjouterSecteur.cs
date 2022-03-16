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
            var objetRegEx = new Regex("^[a-zA-Zéèêëçàâôù ûïî]*$"); //que les majuscules et minuscules classiques et les minuscules avec accent
            var test = objetRegEx.Match(tbxNomSecteur.Text);

            if (!test.Success)
            {
                tbxNomSecteur.BackColor = Color.Red;
            }
            else
            {
                tbxNomSecteur.BackColor = Color.White;
            }
        }

        private void btnAjouterSecteur_Click_1(object sender, EventArgs ea)
        {
            var objetRegEx = new Regex("^[a-zA-Zéèêëçàâôù ûïî]*$"); //test : on vérifie bien que l'on a un string conforme dans la case
            var test = objetRegEx.Match(tbxNomSecteur.Text);

            if (test.Success && tbxNomSecteur.Text != "")
            {
                MySqlConnection maCnx;
                maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");

                try
                {
                    string requete;
                    maCnx.Open();

                    requete = "INSERT INTO secteur(nom) VALUES (@NOMSECTEUR)";

                    var maCde = new MySqlCommand(requete, maCnx);

                    maCde.Parameters.AddWithValue("@NOMSECTEUR", tbxNomSecteur.Text);

                    maCde.ExecuteNonQuery();

                    tbxNomSecteur.Clear();
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
