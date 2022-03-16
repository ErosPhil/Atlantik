using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlantik
{
    class Port
    {
        private int noport;
        private string nom;

        public Port(int noport, string nom)
        {
            this.noport = noport;
            this.nom = nom;
        }

        public int GetNoPort()
        {
            return noport;
        }

        public override string ToString()
        {
            return nom;
        }
    }
}
