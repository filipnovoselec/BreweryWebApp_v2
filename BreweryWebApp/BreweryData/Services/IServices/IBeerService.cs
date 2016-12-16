using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Models;

namespace BreweryData.Services.IServices
{
    public interface IBeerService
    {
        Beers GetCurrentBeer();
        List<Beers> GetAllBeers();
        void AddNewBeer(Beers beer);
        IEnumerable<Pump> GetAllPumps(int beerId);
        IEnumerable<Pump> GetNPumps(int beerId, int n);
        IEnumerable<Temperatures> GetAllTemps(int beerId);
        IEnumerable<Temperatures> GetNTemps(int beerId, int n);
        double GetAvgTemperature(int beerId);
        double GetTotalPumpOnTime(int beerId);
        void DeletePumpsForBeer(int beerId);
        void DeleteTempsForBeer(int beerId);
        void DeleteBeer(int beerId);
    }
}
