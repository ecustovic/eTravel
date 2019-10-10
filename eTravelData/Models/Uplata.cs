using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eTravelData.Models
{
    public class Uplata
    {
        public int Id { get; set; }
        [Required]
        public DateTime DatumUplate { get; set; }
        [Required]
        public decimal Iznos { get; set; }
        public virtual IEnumerable<Klijent> Klijents { get; set; }
        public virtual IEnumerable<Putovanje> Putovanja { get; set; }

    }
}
