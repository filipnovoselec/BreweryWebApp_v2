using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BreweryData.Models;
using BreweryWebApp.Models;
using NUglify.Helpers;

namespace BreweryWebApp.Configurations
{
    public class ModelMapperConfig : Profile
    {
        public ModelMapperConfig()
        {
            CreateMap<Recipes, RecipeNameModel>();

            CreateMap<RecipeModel, Recipes>();

            CreateMap<Beers, BeerMinModel>();

            CreateMap<Beers, BeerModel>()
                .ForMember(dest => dest.Temperatures, opt => opt.MapFrom(src => src.Temperatures
                    .OrderBy(t => t.Time).Select(t => t.Temp)))
                .ForMember(dest => dest.ReadTimes, opt => opt.MapFrom(src => src.Temperatures
                    .OrderBy(t => t.Time).Select(t => t.Time)))
                .ForMember(dest => dest.AvgTemperature, opt => opt.Ignore())
                .ForMember(dest => dest.Pumps, opt => opt.MapFrom(src => CreatePumpModelFromPumps(src.Pumps.ToList())))
                .ForMember(dest => dest.TotalPumpOnTime, opt => opt.Ignore());
        }

        private IEnumerable<PumpModel> CreatePumpModelFromPumps(List<Pump> pumps)
        {
            var pumpList = new List<PumpModel>();
            foreach (var pump in pumps.Where(p => p.State == 1).OrderBy(p => p.Time).ToList())
            {
                var stop = pumps.OrderBy(p => p.Time).FirstOrDefault(p => p.Time > pump.Time && p.State == 0);
                if (stop != null)
                {
                    var pumpModel = new PumpModel()
                    {
                        Start = pump.Time,
                        Duration = stop.Time - pump.Time
                    };
                    pumpList.Add(pumpModel);
                }
            }
            return pumpList;
        }
    }
}

