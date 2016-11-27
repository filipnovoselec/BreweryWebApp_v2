using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryData.Models
{
    public partial class Beers
    {
        public Beers()
        {
            this.Pumps = new HashSet<Pump>();
            this.Temperatures = new HashSet<Temperatures>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Rating { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Pump> Pumps { get; set; }
        public virtual ICollection<Temperatures> Temperatures { get; set; }
    }
}
