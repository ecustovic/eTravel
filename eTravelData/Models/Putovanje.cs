using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eTravelData.Models
{
    public class Putovanje
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Limit name to 20 characters.")]
        public string Naziv { get; set; }
        [Required]
        public string Destinacija { get; set; }
        public int MaxUcesnika { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumPovratka { get; set; }
        public DateTime DatumBookiranja { get; set; }
        public bool DjecaBool { get; set; }
        [Required]
        public decimal Iznos { get; set; }
        public virtual Uplata Uplata { get; set; }
        public virtual IEnumerable<Agencije> Agencijas { get; set; }

    }
}
