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
        IQueryable<Beers> GetCurrentBeer();
        IQueryable<Beers> GetAllBeers();

        void DeletePump(Pump pump);
        IQueryable<Pump> GetAllPumps();

        void DeleteTemperature(Temperatures temp);
        IQueryable<Temperatures> GetAllTemperatures();

        void Save();
    }
}
