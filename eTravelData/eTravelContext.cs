using eTravelData.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace eTravelData
{
    public class eTravelContext : DbContext
    {
        public eTravelContext(DbContextOptions options) : base(options) { }
        public DbSet<Klijent> Klijents { get; set; }
        public DbSet<Agencije> Agencije { get; set; }
        public DbSet<Putovanje> Putovanja { get; set; }
        public DbSet<Uplata> Uplate { get; set; }

    }
}
