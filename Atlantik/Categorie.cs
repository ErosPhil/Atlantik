using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlantik
{
    class Categorie
    {
        private string lettrecategorie;
        private string libelle;

        public Categorie(string lettrecategorie, string libelle)
        {
            this.lettrecategorie = lettrecategorie;
            this.libelle = libelle;
        }
        public string GetLettre() { return lettrecategorie; }
        public string GetLibelle() { return libelle; }

        public override string ToString()
        {
            return lettrecategorie + " (" + libelle + ")";
        }
    }
}
