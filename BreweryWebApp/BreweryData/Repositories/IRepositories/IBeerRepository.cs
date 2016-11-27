using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Models;

namespace BreweryData.Repositories.IRepositories
{
    interface IBeerRepository
    {
        IQueryable GetCurrentBeer();
        IQueryable GetAllBeers();
        IQueryable GetLastNBeers(int n);
        void Add(Beers beer);
        void Remove(Beers beer);
        void Update(Beers beer);
    }
}
