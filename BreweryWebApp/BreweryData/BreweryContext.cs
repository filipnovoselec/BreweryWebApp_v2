using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryData
{
    public class BreweryContext : DbContext
    {
        public BreweryContext(string connectionString) : base(connectionString)
        {
            
        }
    }
}
