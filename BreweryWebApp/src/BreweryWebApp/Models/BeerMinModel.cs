using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreweryWebApp.Models
{
    public class BeerMinModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DaysToCompletion => EndDate > DateTime.Now ? (int)(EndDate - DateTime.Now).TotalDays : 0;
        public double PercentageDone => DaysToCompletion > 0 ? 
            (DateTime.Now - StartDate).TotalSeconds / (EndDate - StartDate).TotalSeconds : 1;
    }
}
