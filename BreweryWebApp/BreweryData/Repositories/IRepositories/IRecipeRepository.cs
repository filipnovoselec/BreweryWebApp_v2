using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Models;

namespace BreweryData.Repositories.IRepositories
{
    public interface IRecipeRepository
    {
        void Add(Recipes recipe);
        void Delete(Recipes recipe);
        void Update(Recipes recipe);
        IQueryable<Recipes> GetAllRecipes();
        IEnumerable<Recipes> GetNRecipes(int n);

        void Save();
    }
}
