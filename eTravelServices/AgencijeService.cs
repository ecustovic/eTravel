using eTravelData;
using eTravelData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace eTravelServices
{
    public class AgencijeService : IAgencijeService
    {
        private eTravelContext _context;

        public AgencijeService(eTravelContext context)
        {
            _context = context;
        }
        public void Add(Agencije newAgencije)
        {
            //var param1 = new SqlParameter("@Ime", newKlijent.Ime);
            //var param2 = new SqlParameter("@Prezime", newKlijent.Prezime);
            //var param3 = new SqlParameter("@PostanskiBroj", newKlijent.PostanskiBroj);
            //var param4 = new SqlParameter("@Grad", newKlijent.Grad);
            //var param5 = new SqlParameter("@Telefon", newKlijent.Telefon);

            //_context.Klijents.FromSql("AddKlijent @Ime, @Prezime, @PostanskiBroj, @Grad, @Telefon", param1, param2, param3, param4, param5).ToList();
        }

        public IEnumerable<Agencije> GetAll()
        {
            return _context.Agencije
                .Include(a => a.Putovanje);
        }

        public Agencije GetById(int id)
        {
            return _context.Agencije
                .Include(a => a.Putovanje)
                .FirstOrDefault(a => a.Id == id);
        }


        public string GetPutovanje(int id)
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
