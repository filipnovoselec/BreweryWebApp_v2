using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryData.Models
{
    public partial class Temperatures
    {
        public int Id { get; set; }
        public float Temp { get; set; }
        public DateTime Time { get; set; }
        
        public virtual Beers Beers { get; set; }
    }
}
