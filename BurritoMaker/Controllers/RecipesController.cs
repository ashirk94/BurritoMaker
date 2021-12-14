using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurritoMaker.Models;
using Microsoft.EntityFrameworkCore;

namespace BurritoMaker.Controllers
{
    public class RecipesController : Controller
    {
        private RecipeContext RecipeContext { get; set; }

        private RecipeRepo Data { get; set; }

        public RecipesController(RecipeRepo repo)
        {
            Data = repo;
        }
        // GET: RecipesController
        
        [HttpGet]
        public IActionResult Index()
        {
            var recipes = from recipe in Data.GetAll() select recipe;
            ViewBag.recipes = recipes;
            return View();
        }

        // GET: RecipesController/Details/5
        [HttpGet]
        public ActionResult ViewRecipe(int id)
        {
            var recipe = Data.GetById(id);
            return View(recipe);
        }

        // GET: RecipesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipesController/Edit/5
        [HttpGet]
        public ActionResult EditRecipe(int id)
        {
            var recipe = Data.GetById(id);
            return View(recipe);
        }

        // POST: RecipesController/Edit/5
        [HttpPost]
        public ActionResult EditRecipe(Recipe recipe)
        {
            try
            {
                Data.Update(recipe);
                Data.Save();
                return RedirectToAction("Index", "Recipes");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult DeleteRecipe(int id)
        {
            var recipe = Data.GetById(id);
            return View(recipe);
        }
        [HttpPost]
        public IActionResult DeleteRecipe(Recipe recipe)
        {
            int id = recipe.Id;
            try
            {
                Data.Delete(id);
                Data.Save();
                return RedirectToAction("Index", "Recipes");
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> Search(string searchString)
        {
            var recipes = from r in Data.GetQueryables() select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.BurritoName!.Contains(searchString));
            }
            ViewBag.recipes = recipes;
            return View(await recipes.ToListAsync());
        }
    }
}
