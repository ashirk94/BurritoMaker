using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BurritoMaker.Models
{
    public class RecipeRepo : IRepository<Recipe>
    {
        private RecipeContext context;

        public RecipeRepo(RecipeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return context.Recipes;
        }

        public Recipe GetById(int id)
        {
            return context.Recipes.Find(id);
        }

        public void Insert(Recipe recipe)
        {
            context.Recipes.Add(recipe);
        }

        public void Delete(int id)
        {
            Recipe recipe = context.Recipes.Find(id);
            context.Recipes.Remove(recipe);
        }

        public void Update(Recipe recipe)
        {
            context.Entry(recipe).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

