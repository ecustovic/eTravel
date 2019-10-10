using eTravelData;
using eTravelData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace eTravelServices
{
    public class KlijentService : IKlijentService
    {
        private eTravelContext _context;

        public KlijentService(eTravelContext context)
        {
            _context = context;
        }
        public void Add(Klijent newKlijent)
        {
            var param1 = new SqlParameter("@Ime", newKlijent.Ime);
            var param2 = new SqlParameter("@Prezime", newKlijent.Prezime);
            var param3 = new SqlParameter("@PostanskiBroj", newKlijent.PostanskiBroj);
            var param4 = new SqlParameter("@Grad", newKlijent.Grad);
            var param5 = new SqlParameter("@Telefon", newKlijent.Telefon);

            _context.Klijents.FromSql("AddKlijent @Ime, @Prezime, @PostanskiBroj, @Grad, @Telefon", param1, param2, param3, param4, param5).ToList();
        }

        public IEnumerable<Klijent> GetAll()
        {
            return _context.Klijents
                .Include(a => a.Uplata)
                .Include(a => a.Putovanje);
        }

        public Klijent GetById(int id)
        {
            return _context.Klijents
                .Include(a => a.Uplata)
                .Include(a => a.Putovanje)
                .FirstOrDefault(a => a.Id == id);
        }

        public decimal GetUplata(int id)
        {
            //return GetById(id).Uplata.Iznos;
            if (_context.Uplate.Any(a => a.Id == id))
            {
                return _context.Uplate.FirstOrDefault(b => b.Id == id).Iznos;
            }
            else
                return 0;
        }


        public string GetDestinacija(int id)
        {
            if (_context.Putovanja.Any(a => a.Id == id))
            {
                return _context.Putovanja.FirstOrDefault(b => b.Id == id).Destinacija;
            }
            else
                return "";
        }
    }
}
