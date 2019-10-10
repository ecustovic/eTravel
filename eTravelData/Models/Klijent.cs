using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eTravelData.Models
{
    public class Klijent
    {
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public string Telefon { get; set; }
        public string PostanskiBroj { get; set; }
        public string Grad { get; set; }
        public string SlikaUrl { get; set; }
        public virtual Uplata Uplata { get; set; }
        public virtual Putovanje Putovanje { get; set; }

    }
}
