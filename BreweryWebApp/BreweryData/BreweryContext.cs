using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Models;

namespace BreweryData
{
    public class BreweryContext : DbContext
    {
        public BreweryContext(string connectionString) : base(connectionString)
        {
            
        }

        public DbSet<Beers> Beers { get; set; }
        public DbSet<Pump>  Pumps { get; set; }
        public DbSet<Temperatures> Temperatures { get; set; }
        public DbSet<Recipes> Recipes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Temperatures>()
                .HasRequired<Beers>(o => o.Beer)
                .WithMany(o => o.Temperatures)
                .HasForeignKey(o => o.BeerId);

            modelBuilder.Entity<Pump>()
                .HasRequired<Beers>(o => o.Beer)
                .WithMany(o => o.Pumps)
                .HasForeignKey(o => o.BeerId);
        }
    }
}
