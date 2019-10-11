using System;

namespace eTravel.Models.Putovanje
{
    public class PutovanjeIndexListingModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Destinacija { get; set; }
        public int MaxUcesnika { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumPovratka { get; set; }
        public DateTime DatumBookiranja { get; set; }
        public bool DjecaBool { get; set; }
        public decimal Iznos { get; set; }

    }
}
