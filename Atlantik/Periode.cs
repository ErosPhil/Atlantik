using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atlantik
{
    class Periode
    {
        private int noperiode;
        private DateTime datedebut;
        private DateTime datefin;

        public Periode(int noperiode, DateTime datedebut, DateTime datefin)
        {
            this.noperiode = noperiode;
            this.datedebut = datedebut;
            this.datefin = datefin;
        }

        public int GetNoPeriode() { return noperiode; }

        public override string ToString()
        {
            return datedebut.ToString("yyyy/MM/dd") + " au " + datefin.ToString("yyyy/MM/dd");
        }
    }
}
