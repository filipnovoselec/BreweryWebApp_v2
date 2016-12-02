using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryData.Models
{
    public partial class Pump
    {
        public int Id { get; set; }
        public int State { get; set; }
        public DateTime Time { get; set; }
        
        public virtual Beers Beer { get; set; }
    }
}
