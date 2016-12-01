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

        public IQueryable<Beers> GetCurrentBeer()
        {
            return _breweryContext.Beers.Where(s => s.EndDate > DateTime.Now);
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
            var tempBeer = _breweryContext.Beers.First(s => s.Id == beer.Id);
            //Todo sa Automapperom
            _mapper.Map<Beers, Beers>(beer, tempBeer);
        }

        public void DeleteTemperature(Temperatures temp)
        {
            _breweryContext.Temperatures.Remove(temp);
        }

        public IQueryable<Temperatures> GetAllTemperatures()
        {
            return _breweryContext.Temperatures;
        }

        public void DeletePump(Pump pump)
        {
            _breweryContext.Pumps.Remove(pump);
        }

        public IQueryable<Pump> GetAllPumps()
        {
            return _breweryContext.Pumps;
        }

        public void Save()
        {
            _breweryContext.SaveChanges();
        }
    }
}
