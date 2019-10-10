using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eTravelData.Models
{
    public class Agencije
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string Manager { get; set; }
        [Required]
        public string Adresa { get; set; }
        public string SlikaUrl { get; set; }
        public virtual Putovanje Putovanje { get; set; }

    }
}
