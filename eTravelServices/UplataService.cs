using eTravelData;
using eTravelData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eTravelServices
{
    public class UplataService : IUplataService
    {
        private eTravelContext _context;

        public UplataService(eTravelContext context)
        {
            _context = context;
        }

        public IEnumerable<Uplata> GetAll()
        {
            return _context.Uplate
                .Include(a => a.Klijents)
                .Include(a => a.Putovanja);
        }

        public Uplata GetById(int id)
        {
            return _context.Uplate
                .Include(a => a.Putovanja)
                .Include(a => a.Klijents)
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
