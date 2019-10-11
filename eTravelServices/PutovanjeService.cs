using eTravelData;
using eTravelData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eTravelServices
{
    public class PutovanjeService : IPutovanjeService
    {
        private eTravelContext _context;

        public PutovanjeService(eTravelContext context)
        {
            _context = context;
        }

        public IEnumerable<Putovanje> GetAll()
        {
            return _context.Putovanja
                .Include(a => a.Uplata)
                .Include(a => a.Agencijas);
        }

        public Putovanje GetById(int id)
        {
            return _context.Putovanja
                .Include(a => a.Uplata)
                .Include(a => a.Agencijas)
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
