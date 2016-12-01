using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Models;
using BreweryData.Repositories.IRepositories;

namespace BreweryData.Services
{
    public class BeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(
            IBeerRepository beerRepository)
        {
            this._beerRepository = beerRepository;
        }

        public Beers GetCurrentBeer()
        {
            return _beerRepository.GetCurrentBeer().FirstOrDefault();
        }

        public List<Beers> GetAllBeers()
        {
            return _beerRepository.GetAllBeers().ToList();
        }


    }
}
