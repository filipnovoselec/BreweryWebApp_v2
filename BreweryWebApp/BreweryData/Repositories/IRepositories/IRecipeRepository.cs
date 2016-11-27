﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryData.Models;

namespace BreweryData.Repositories.IRepositories
{
    interface IRecipeRepository
    {
        void Add(Recipes recipe);
        void Remove(Recipes recipe);
        void Update(Recipes recipe);
        IQueryable GetAllRecipes();
    }
}
