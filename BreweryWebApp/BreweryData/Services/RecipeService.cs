using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Repositories;
using BreweryData.Repositories.IRepositories;

namespace BreweryData.Services
{
    public class RecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(
            IRecipeRepository recipeRepository)
        {
            this._recipeRepository = recipeRepository;
        }

        public List<string> GetAllRecipeNames()
        {
            return _recipeRepository.GetAllRecipes().Select(s => s.Name).ToList();
        }
    }
}
