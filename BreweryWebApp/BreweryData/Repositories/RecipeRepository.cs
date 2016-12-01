using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Models;
using BreweryData.Repositories.IRepositories;

namespace BreweryData.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly BreweryContext _breweryContext;

        public RecipeRepository(BreweryContext breweryContext)
        {
            this._breweryContext = breweryContext;
        }

        public void Add(Recipes recipe)
        {
            _breweryContext.Recipes.Add(recipe);
            _breweryContext.SaveChanges();
        }

        public void Remove(Recipes recipe)
        {
            _breweryContext.Recipes.Remove(recipe);
            _breweryContext.SaveChanges();
        }

        public void Update(Recipes recipe)
        {
            //Todo
        }

        public IQueryable<Recipes> GetAllRecipes()
        {
            return _breweryContext.Recipes;
        }
    }
}
