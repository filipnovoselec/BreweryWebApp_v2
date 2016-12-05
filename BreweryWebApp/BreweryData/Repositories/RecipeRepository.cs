using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BreweryData.Models;
using BreweryData.Repositories.IRepositories;

namespace BreweryData.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly BreweryContext _breweryContext;
        private readonly IMapper _mapper;

        public RecipeRepository(
            BreweryContext breweryContext,
            IMapper mapper)
        {
            this._breweryContext = breweryContext;
            this._mapper = mapper;
        }

        public void Add(Recipes recipe)
        {
            _breweryContext.Recipes.Add(recipe);
            _breweryContext.SaveChanges();
        }

        public void Delete(Recipes recipe)
        {
            _breweryContext.Recipes.Remove(recipe);
            _breweryContext.SaveChanges();
        }

        public void Update(Recipes recipe)
        {
            var original = _breweryContext.Recipes.Find(recipe.Id);
            _mapper.Map<Recipes, Recipes>(recipe, original);
        }

        public IQueryable<Recipes> GetAllRecipes()
        {
            return _breweryContext.Recipes;
        }

        public IEnumerable<Recipes> GetNRecipes(int n)
        {
            return _breweryContext.Recipes.OrderByDescending(rec => rec.Id).Take(n);
        }

        public void Save()
        {
            _breweryContext.SaveChanges();
        }
    }
}
