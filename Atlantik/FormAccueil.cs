using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atlantik
{
    public partial class FormAccueil : Form
    {
        public FormAccueil()
        {
            InitializeComponent();
        }

        private void FormAccueil_Load(object sender, EventArgs e)
        {

        }

        //AJOUTER

        //Ajouter un secteur
        private void unSecteurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAjouterSecteur form = new FormAjouterSecteur();
            form.ShowDialog();
        }

        //Ajouter un port
        private void unPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAjouterPort form = new FormAjouterPort();
            form.ShowDialog();
        }

        //Ajouter une liaison
        private void uneLiaisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAjouterLiaison form = new FormAjouterLiaison();
            form.ShowDialog();
        }

        //Ajouter les tarifs pour une liaison et une période 
        private void lesTarifsPourUneLiaisonEtUnePériodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAjouterTarifs form = new FormAjouterTarifs();
            form.ShowDialog();
        }
        
        //Ajouter un bateau
        private void unBateauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAjouterBateau form = new FormAjouterBateau();
            form.ShowDialog();
        }

        //Ajouter une traversée
        private void uneTraverséeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAjouterTraversee form = new FormAjouterTraversee();
            form.ShowDialog();
        }

        //MODIFIER

        //Modifier un bateau
        private void unBateauToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormModifierBateau form = new FormModifierBateau();
            form.ShowDialog();
        }

        //Modifier les paramètres du site
        private void lesParamètresDuSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModifierParametresSite form = new FormModifierParametresSite();
            form.ShowDialog();
        }

        //AFFICHER

        //Afficher les traversées pour une liaison et une date donnée avec places restantes par catégorie
        private void lesTraverséesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAfficherTraversees form = new FormAfficherTraversees();
            form.ShowDialog();
        }

        //Afficher les détails d'une réservation pour un client
        private void lesDétailsDuneRéservationPourUnClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAfficherDetailsReservation form = new FormAfficherDetailsReservation();
            form.ShowDialog();
        }

    }
}
