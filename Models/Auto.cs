using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDijelovi1.Models
{
    public class Auto
    {

        public int AutoID { get; set; }
        public string NazivAuta { get; set; }
        public DateTime GodinaProizvodnje { get; set; }
        public string Dio { get; set; }
        public int SkladisteID { get; set; }
        public Skladiste Skladiste { get; set; }
    }
}
