using BurritoMaker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BurritoMaker.Controllers
{
    public class HomeController : Controller
    {
        private Recipe currentRecipe;
        private RecipeContext RecipeContext { get; set; }

        private int CurrentId = 0;
        private RecipeRepo Data { get; set; }

        public HomeController(RecipeRepo repo)
        {
            Data = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TortillaSauce(Recipe recipe)
        {
            return View(recipe);
        }
        [HttpPost, ActionName("TortillaSauce")]
        public IActionResult TortillaSaucePost(Recipe recipe)
        {
            //recipe.Tortilla = Select.Items[Select.SelectedIndex].Text;
            if (recipe.Id == 0)
            {
                recipe.CreatedDate = DateTime.Now;
                Data.Insert(recipe);
                currentRecipe = recipe;
                CurrentId = recipe.Id;
            }
            else
            {
                Data.Update(recipe);
            }
            Data.Save();
            return RedirectToAction("RiceBeans", "Home", recipe);

        }
        [HttpGet]
        public IActionResult RiceBeans(Recipe recipe)
        {
            return View(recipe);
        }
        [HttpPost, ActionName("RiceBeans")]
        public IActionResult RiceBeansPost(Recipe recipe)
        {
            recipe.Id = CurrentId;
            Data.Update(recipe);
            Data.Save();
            return RedirectToAction("MeatCheese", "Home", recipe);
        }
        public IActionResult MeatCheese(Recipe recipe)
        {
            return View(recipe);
        }
        [HttpPost, ActionName("MeatCheese")]
        public IActionResult MeatCheesePost(Recipe recipe)
        {
            recipe.Id = CurrentId;
            Data.Update(recipe);
            Data.Save();
            return RedirectToAction("Veggies", "Home", recipe);
        }
        public IActionResult Veggies(Recipe recipe)
        {
            return View(recipe);
        }
        [HttpPost, ActionName("Veggies")]
        public IActionResult VeggiesPost(Recipe recipe)
        {
            recipe.Id = CurrentId;
            Data.Update(recipe);
            Data.Save();
            return RedirectToAction("Results", "Home", recipe);
        }
        [HttpGet]
        public IActionResult Results(Recipe r)
        {
            var recipes = from recipe in Data.GetAll() select recipe;
            ViewBag.recipes = recipes;
            return View(r);
        }
        [HttpPost, ActionName("Results")]
        public IActionResult ResultsPost(Recipe recipe)
        {
            recipe.Id = CurrentId;
            Data.Update(recipe);
            Data.Save();
            return RedirectToAction("Results", "Home", recipe);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
