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
