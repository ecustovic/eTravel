using System;

namespace eTravel.Models.Uplata
{
    public class UplataIndexListingModel
    {
        public int Id { get; set; }
        public DateTime DatumUplate { get; set; }
        public decimal Iznos { get; set; }
        public string Klijent { get; set; }
    }
}
