using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BreweryData.Models;
using BreweryWebApp.Models;

namespace BreweryWebApp.Configurations
{
    public class ModelMapperConfig : Profile
    {
        public ModelMapperConfig()
        {
            CreateMap<Recipes, RecipeNameModel>();
            CreateMap<RecipeModel, Recipes>();
            CreateMap<Beers, BeerModel>()
                .ForMember(dest => dest.Temperatures, opt => opt.Ignore())
                .ForMember(dest => dest.ReadTimes, opt => opt.Ignore())
                .ForMember(dest => dest.AvgTemperature, opt => opt.Ignore())
                .ForMember(dest => dest.Pumps, opt => opt.Ignore());
        }
    }
}
