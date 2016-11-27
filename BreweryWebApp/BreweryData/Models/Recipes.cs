using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryData.Models
{
    public partial class Recipes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profile { get; set; }
        public string Picture { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}
