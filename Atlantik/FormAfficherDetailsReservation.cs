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

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
