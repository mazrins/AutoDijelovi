using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDijelovi1.Models
{
    public class Skladiste
    {
        public int SkladisteId { get; set; }
        public string NazivSkladista { get; set; }
        public string Lokacija { get; set; }
        public List<Auto> Auti { get; set; }
    }
}
