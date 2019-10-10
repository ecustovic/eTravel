using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTravel.Models.Klijent
{
    public class KlijentUcitajListingModel
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string PostanskiBroj { get; set; }
        public string Grad { get; set; }
        public bool ImaGresku { get; set; } = false;
    }
}
