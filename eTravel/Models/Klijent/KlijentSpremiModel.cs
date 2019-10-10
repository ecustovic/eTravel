using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTravel.Models.Klijent
{
    public class KlijentSpremiModel
    {
        public int UkupniBrojKlijenata { get; set; }
        public int UspjesnoDodanihKlijenata { get; set; } = 0;
        public List<string> ErrorList { get; set; } = new List<string>();
    }
}
