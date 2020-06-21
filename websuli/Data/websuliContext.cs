using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using websuli.Model;

namespace websuli.Models
{
    public class websuliContext : DbContext
    {
        public websuliContext()
        {
        }

        public websuliContext (DbContextOptions<websuliContext> options)
            : base(options)
        {
        }

        public DbSet<Feladatsor> Feladatsor { get; set; }
        public DbSet<Feladat> Feladat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feladatsor>().ToTable("Feladatsor");
            modelBuilder.Entity<Feladat>().ToTable("Feladatok");

        }
    }
}
