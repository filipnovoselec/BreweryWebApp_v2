using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Models;
using BreweryData.Repositories;
using BreweryData.Repositories.IRepositories;
using BreweryData.Services.IServices;

namespace BreweryData.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(
            IRecipeRepository recipeRepository)
        {
            this._recipeRepository = recipeRepository;
        }

        public IEnumerable<Recipes> GetAllRecipes()
        {
            return _recipeRepository.GetAllRecipes();
        }

        public Recipes GetRecipeDetails(int id)
        {
            return _recipeRepository.GetAllRecipes().First(rec => rec.Id == id);
        }

        public void UpdateRecipe(Recipes recipe)
        {
            _recipeRepository.Update(recipe);
            _recipeRepository.Save();
        }

        public void AddRecipe(Recipes recipe)
        {
            _recipeRepository.Add(recipe);
            _recipeRepository.Save();
        }
    }
}
