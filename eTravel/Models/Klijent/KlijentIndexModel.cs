using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTravel.Models.Klijent
{
    public class KlijentIndexModel
    {
        public IEnumerable<KlijentIndexListingModel> Klijents { get; set; }
    }
}
