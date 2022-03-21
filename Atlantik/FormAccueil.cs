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

        private void unSecteurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAjouterSecteur form = new FormAjouterSecteur();
            form.ShowDialog();
        }

        private void unPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAjouterPort form = new FormAjouterPort();
            form.ShowDialog();
        }

        private void uneLiaisonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAjouterLiaison form = new FormAjouterLiaison();
            form.ShowDialog();
        }

        private void lesTarifsPourUneLiaisonEtUnePériodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAjouterTarifs form = new FormAjouterTarifs();
            form.ShowDialog();
        }

        private void unBateauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAjouterBateau form = new FormAjouterBateau();
            form.ShowDialog();
        }

        private void uneTraverséeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAjouterTraversee form = new FormAjouterTraversee();
            form.ShowDialog();
        }

        private void unBateauToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormModifierBateau form = new FormModifierBateau();
            form.ShowDialog();
        }

        private void lesParamètresDuSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModifierParametresSite form = new FormModifierParametresSite();
            form.ShowDialog();
        }

        private void lesTraverséesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAfficherTraversees form = new FormAfficherTraversees();
            form.ShowDialog();
        }

        private void lesDétailsDuneRéservationPourUnClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAfficherDetailsReservation form = new FormAfficherDetailsReservation();
            form.ShowDialog();
        }

    }
}
