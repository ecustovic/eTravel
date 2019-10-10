using eTravelData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTravel.Models.Agencije
{
    public class AgencijeDetailModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Telefon { get; set; }
        public string Manager { get; set; }
        public string Adresa { get; set; }
        public string SlikaUrl { get; set; }
        public string Putovanje { get; set; }
    }
}
