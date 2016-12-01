using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BreweryData.Models;

namespace BreweryData
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Beers, Beers>();
        }

    }
}
