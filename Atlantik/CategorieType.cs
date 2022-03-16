using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlantik
{
    class CategorieType
    {
        private string lettrecategorie;
        private int notype;
        private string libelle;

        public CategorieType(string lettrecategorie, int notype, string libelle)
        {
            this.lettrecategorie = lettrecategorie;
            this.notype = notype;
            this.libelle = libelle;
        }

        public string GetLettreCategorie() { return lettrecategorie; }

        public int GetNoType() { return notype; }

        public string GetLibelle() { return libelle; }

        public override string ToString()
        {
            return lettrecategorie + notype.ToString() + " - " + libelle;
        }
    }
}
