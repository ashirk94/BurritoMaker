using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BurritoMaker.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext() { }
        
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        { }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
