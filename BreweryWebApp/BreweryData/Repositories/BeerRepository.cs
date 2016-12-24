using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BreweryData.Models;
using BreweryData.Repositories.IRepositories;

namespace BreweryData.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BreweryContext _breweryContext;
        private readonly IMapper _mapper;

        public BeerRepository(
            BreweryContext breweryContext,
            IMapper mapper)
        {
            this._breweryContext = breweryContext;
            this._mapper = mapper;
        }

        public Beers GetCurrentBeer()
        {
            return _breweryContext.Beers.FirstOrDefault(s => s.EndDate >= DateTime.Now);
        }

        public IQueryable<Beers> GetAllBeers()
        {
            return _breweryContext.Beers;
        }

        public void AddBeer(Beers beer)
        {
            _breweryContext.Beers.Add(beer);
        }

        public void DeleteBeer(Beers beer)
        {
            _breweryContext.Beers.Remove(beer);
        }

        public void UpdateBeer(Beers beer)
        {
            var tempBeer = _breweryContext.Beers.Find(beer.Id);
            _mapper.Map<Beers, Beers>(beer, tempBeer);
        }

        public IEnumerable<Beers> GetBestBeers(int n)
        {
            return _breweryContext.Beers.OrderByDescending(beer => beer.Rating).Take(n);
        }

        public void DeleteTemperature(Temperatures temp)
        {
            _breweryContext.Temperatures.Remove(temp);
        }

        public IQueryable<Temperatures> GetAllTemperaturesForBeer(int beerId)
        {
            return _breweryContext.Temperatures.Where(temp => temp.Beer.Id == beerId);
        }

        public IEnumerable<Temperatures> GetLatestTemperaturesForBeer(int beerId, int n)
        {
            return _breweryContext.Temperatures.Where(temp => temp.Beer.Id == beerId).OrderByDescending(temp => temp.Time).Take(n);
        }


        public void DeletePump(Pump pump)
        {
            _breweryContext.Pumps.Remove(pump);
        }

        public IQueryable<Pump> GetAllPumpsForBeer(int beerId)
        {
            return _breweryContext.Pumps.Where(pump => pump.Beer.Id == beerId);
        }

        public IEnumerable<Pump> GetLatestPumpsForBeer(int beerId, int n)
        {
            return _breweryContext.Pumps.Where(pump => pump.Beer.Id == beerId).OrderByDescending(pump => pump.Time).Take(n);
        }

        public void Save()
        {
            _breweryContext.SaveChanges();
        }

        public Beers GetBeer(int beerId)
        {
            return _breweryContext.Beers.FirstOrDefault(b => b.Id == beerId);
        }
    }
}
