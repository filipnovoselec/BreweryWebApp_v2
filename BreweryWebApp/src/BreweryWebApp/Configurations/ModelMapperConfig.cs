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
        }
    }
}
