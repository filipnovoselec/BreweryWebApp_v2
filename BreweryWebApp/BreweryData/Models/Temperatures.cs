using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryData.Models
{
    public partial class Temperatures
    {
        public int Id { get; set; }
        public double Temp { get; set; }
        public DateTime Time { get; set; }
        public int BeerId { get; set; }

        [ForeignKey("BeerId")]
        public virtual Beers Beer { get; set; }
    }
}
