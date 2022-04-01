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
        MySqlConnection maCnx;
        public FormAjouterPort()
        {
            InitializeComponent();
            maCnx = new MySqlConnection("server=localhost;user=root;database=atlantik;port=3306;password=");
        }

        private void FormAjouterPort_Load(object sender, EventArgs e)
        {

        }

        private void btnAjouterPort_Click(object sender, EventArgs ea)
        {
            var objetRegEx = new Regex("^[a-zA-Zéèêëçàâôù ûïî-]*$");
            var test = objetRegEx.Match(tbxNomPort.Text);

            if (test.Success && tbxNomPort.Text != "")
            {
                DialogResult retour = MessageBox.Show("Êtes-vous sûr de vouloir ajouter le port " + tbxNomPort.Text + " ?", "Confirmation avant ajout", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (retour == DialogResult.Yes)
                {
                    try
                    {
                        maCnx.Open();

                        string requete = "INSERT INTO port(nom) VALUES (@NOMPORT)";

                        var maCde = new MySqlCommand(requete, maCnx);

                        maCde.Parameters.AddWithValue("@NOMPORT", tbxNomPort.Text);

                        maCde.ExecuteNonQuery();

                        tbxNomPort.Clear();

                        MessageBox.Show("Ajout du port effectué", "Confirmation après ajout", MessageBoxButtons.OK);
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

        private void tbxNomPort_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
