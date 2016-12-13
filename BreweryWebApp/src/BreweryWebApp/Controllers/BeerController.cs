using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BreweryData.Models;
using BreweryData.Services.IServices;
using BreweryWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BreweryWebApp.Controllers
{
    public class BeerController : Controller
    {
        private readonly IBeerService _beerService;
        private readonly IMapper _mapper;

        public BeerController(
            IBeerService beerService,
            IMapper mapper)
        {
            this._beerService = beerService;
            this._mapper = mapper;
        }

        //[Authorize]
        [HttpPost]
        public IActionResult CreateNewBeer([FromBody]Beers beer)
        {
            try
            {
                _beerService.AddNewBeer(beer);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetCurrentBeer()
        {
            var currentBeer = _beerService.GetCurrentBeer();
            

            if (currentBeer != null)
            {
                var beer = _mapper.Map<Beers, BeerModel>(currentBeer);

                beer.AvgTemperature = _beerService.GetAvgTemperature(beer.Id);

                return Ok();
            }
            else return NotFound();
        }
    }
}
