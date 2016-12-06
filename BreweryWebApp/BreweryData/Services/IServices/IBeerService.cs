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
    }
}
