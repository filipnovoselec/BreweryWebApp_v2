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
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;
        public RecipeController(
            IRecipeService recipeService,
            IMapper mapper)
        {
            this._recipeService = recipeService;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRecipeNames()
        {
            var recipes = new List<RecipeNameModel>();
            foreach (var rec in _recipeService.GetAllRecipes())
            {
                recipes.Add(_mapper.Map<Recipes, RecipeNameModel>(rec));
            }
            return Ok(recipes);
        }

        [HttpGet]
        public IActionResult GetRecipeForId(int recipeId)
        {
            try
            {
                return Ok(_recipeService.GetRecipeDetails(recipeId));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        //[Authorize]
        [HttpPost]
        public IActionResult UpdateRecipe([FromBody]RecipeModel recipe)
        {
            var newRecipe = _mapper.Map<RecipeModel, Recipes>(recipe);
            try
            {
                _recipeService.UpdateRecipe(newRecipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult AddNewRecipe([FromBody] RecipeModel recipe)
        {
            var newRecipe = new Recipes()
            {
                Name = recipe.Name,
                Profile = recipe.Profile,
                Picture = recipe.Picture,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions
            };
            try
            {
                _recipeService.AddRecipe(newRecipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        //[Authorize]
        [HttpPost]
        public IActionResult DeleteRecipe(int id)
        {
            var recipe =_recipeService.GetRecipeDetails(id);
            try
            {
                _recipeService.DeleteRecipe(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
