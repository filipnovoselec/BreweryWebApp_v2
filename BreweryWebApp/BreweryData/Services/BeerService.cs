using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Models;
using BreweryData.Repositories.IRepositories;
using BreweryData.Services.IServices;

namespace BreweryData.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(
            IBeerRepository beerRepository)
        {
            this._beerRepository = beerRepository;
        }

        public Beers GetCurrentBeer()
        {
            return _beerRepository.GetCurrentBeer();
        }

        public List<Beers> GetAllBeers()
        {
            return _beerRepository.GetAllBeers().ToList();
        }

        public void AddNewBeer(Beers beer)
        {
            _beerRepository.AddBeer(beer);
            _beerRepository.Save();
        }

        public IEnumerable<Pump> GetAllPumps(int beerId)
        {
            return _beerRepository.GetAllPumpsForBeer(beerId);
        }

        public IEnumerable<Pump> GetNPumps(int beerId, int n)
        {
            return _beerRepository.GetLatestPumpsForBeer(beerId, n);
        }

        public IEnumerable<Temperatures> GetAllTemps(int beerId)
        {
            return _beerRepository.GetAllTemperaturesForBeer(beerId);
        }

        public IEnumerable<Temperatures> GetNTemps(int beerId, int n)
        {
            return _beerRepository.GetLatestTemperaturesForBeer(beerId, n);
        }

        public double GetAvgTemperature(int beerId)
        {
            var temps = _beerRepository.GetAllTemperaturesForBeer(beerId).ToList();
            double tempSum = 0;

            temps.ForEach(t => tempSum += t.Temp);

            return tempSum / temps.Count;
        }

        public double GetTotalPumpOnTime(int beerId)
        {
            var pumps = _beerRepository.GetAllPumpsForBeer(beerId);
            double pumpOnTime = 0;

            foreach (var pump in pumps.Where(p => p.State == 1))
            {
                var tPump = pumps.FirstOrDefault(p => p.Time.Date == pump.Time.Date && p.State == 0);
                if (tPump != null)
                {
                    pumpOnTime += (tPump.Time - pump.Time).TotalSeconds;
                }

            }
            return pumpOnTime;
        }
    }
}
