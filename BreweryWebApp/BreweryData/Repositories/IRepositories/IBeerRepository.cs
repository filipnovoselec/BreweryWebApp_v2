using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Models;

namespace BreweryData.Repositories.IRepositories
{
    public interface IBeerRepository
    {
        void AddBeer(Beers beer);
        void DeleteBeer(Beers beer);
        void UpdateBeer(Beers beer);
        Beers GetCurrentBeer();
        IQueryable<Beers> GetAllBeers();
        IEnumerable<Beers> GetBestBeers(int n);

        void DeletePump(Pump pump);
        IQueryable<Pump> GetAllPumpsForBeer(int beerId);
        IEnumerable<Pump> GetLatestPumpsForBeer(int beerId, int n);

        void DeleteTemperature(Temperatures temp);
        IQueryable<Temperatures> GetAllTemperaturesForBeer(int beerId);
        IEnumerable<Temperatures> GetLatestTemperaturesForBeer(int beerId, int n);

        void Save();
    }
}
