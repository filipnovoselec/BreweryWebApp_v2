using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreweryWebApp.Models
{
    public class BeerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TimeToCompletion => (EndDate - DateTime.Now).TotalSeconds;
        public double PercentageDone => (DateTime.Now - StartDate).TotalSeconds / (EndDate - StartDate).TotalSeconds;
        public List<double> Temperatures { get; set; }
        public List<string> ReadTimes { get; set; }
        public double AvgTemperature { get; set; }
        public List<PumpModel> Pumps { get; set; }
        public double TotalPumpOnTime { get; set; }
        public double PercentagePumpOnTime => TotalPumpOnTime/(DateTime.Now - StartDate).TotalSeconds;

    }
}
