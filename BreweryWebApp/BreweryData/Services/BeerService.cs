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


    }
}
