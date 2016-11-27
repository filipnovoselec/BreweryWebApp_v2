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
    }
}
