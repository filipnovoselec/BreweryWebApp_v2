using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Models;
using BreweryData.Repositories.IRepositories;

namespace BreweryData.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BreweryContext _breweryContext;
        public BeerRepository(BreweryContext breweryContext)
        {
            this._breweryContext = breweryContext;
        }

        public IQueryable GetCurrentBeer()
        {
            return _breweryContext.Beers.Where(s => s.EndDate > DateTime.Now);
        }

        public IQueryable GetAllBeers()
        {
            return _breweryContext.Beers;
        }

        public IQueryable GetLastNBeers(int n)
        {
            return _breweryContext.Beers.Take(n);
        }

        public void Add(Beers beer)
        {
            _breweryContext.Beers.Add(beer);
            _breweryContext.SaveChanges();
        }

        public void Remove(Beers beer)
        {
            _breweryContext.Beers.Remove(beer);
            _breweryContext.SaveChanges();
        }

        public void Update(Beers beer)
        {
            var tempBeer = _breweryContext.Beers.First(s => s.Id == beer.Id);
            //Todo sa Automapperom
        }
    }
}
