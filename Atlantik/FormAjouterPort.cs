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
    public partial class FormAjouterPort : Form
    {
        public FormAjouterPort()
        {
            InitializeComponent();
        }

        private void FormAjouterPort_Load(object sender, EventArgs e)
        {

        }

        
        private void btnAjouterPort_Click(object sender, EventArgs ea)
        {
            var objetRegEx = new Regex("^[a-zA-Zéèêëçàâôù ûïî]*$"); //test : on vérifie bien que l'on a un string conforme dans la case
            var test = objetRegEx.Match(tbxNomPort.Text);

            if (test.Success && tbxNomPort.Text != "")
            {
                MySqlConnection maCnx;
                maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");

                try
                {
                    string requete;
                    maCnx.Open(); // on se connecte

                    requete = "INSERT INTO port(nom) VALUES (@NOMPORT)";

                    var maCde = new MySqlCommand(requete, maCnx);

                    maCde.Parameters.AddWithValue("@NOMPORT", tbxNomPort.Text);

                    maCde.ExecuteNonQuery();

                    tbxNomPort.Clear();
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

        private void tbxNomPort_TextChanged(object sender, EventArgs e)
        {
            var objetRegEx = new Regex("^[a-zA-Zéèêëçàâôù ûïî]*$"); //que les majuscules et minuscules classiques et les minuscules avec accent
            var test = objetRegEx.Match(tbxNomPort.Text);

            if (!test.Success)
            {
                tbxNomPort.BackColor = Color.Red;
            }
            else
            {
                tbxNomPort.BackColor = Color.White;
            }
        }
    }
}
