using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlantik
{
    class Liaison
    {
        private int noliaison;
        private int nosecteur;
        //private int noport_depart;
        private string nomport_depart;
        //private int noport_arrivee;
        private string nomport_arrivee;
        private double distance;

        public Liaison(int noliaison, int nosecteur, string nomport_depart, string nomport_arrivee, double distance)
        {
            this.noliaison = noliaison;
            this.nosecteur = nosecteur;
            //this.noport_depart = noport_depart;
            this.nomport_depart = nomport_depart;
            //this.noport_arrivee = noport_arrivee;
            this.nomport_arrivee = nomport_arrivee;
            this.distance = distance;
        }

        public int GetNoLiaison() { return noliaison; }
        public int GetNoSecteur() { return nosecteur; }

        //public int GetNoPortDepart() { return noport_depart; }

        //public int GetNoPortArrivee() { return noport_arrivee; }

        public double GetDistance() { return distance; }

        public override string ToString()
        {
            return nomport_depart + "--" + nomport_arrivee;
        }
    }
}
