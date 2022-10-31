using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistencia
{
    public class CafeLoraContext : IdentityDbContext<Usuario>
    {
        public CafeLoraContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<UmbralMaxTemperatura> UmbralMaxTemperatura { get; set; }
        public DbSet<UmbralMinTemperatura> UmbralMinTemperatura { get; set; }
        public DbSet<UmbralMaxHumedad> UmbralMaxHumedad { get; set; }
        public DbSet<UmbralMinHumedad> UmbralMinHumedad { get; set; }
        public DbSet<UmbralMaxPh> UmbralMaxPh { get; set; }
        public DbSet<UmbralMinPh> UmbralMinPh { get; set; }
        public DbSet<UmbralMaxColor> UmbralMaxColor { get; set; }
        public DbSet<UmbralMinColor> UmbralMinColor { get; set; }

    }
}
