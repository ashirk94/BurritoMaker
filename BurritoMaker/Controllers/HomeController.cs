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
        private RecipeContext RecipeContext { get; set; }

        private RecipeRepo Data { get; set; }

        public HomeController(RecipeRepo repo)
        {
            Data = repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateBurrito()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBurrito(Recipe recipe)
        {
            try
            {
                if (recipe.Id == 0)
                {
                    Data.Insert(recipe);
                }
                else
                {
                    Data.Update(recipe);
                }
                Data.Save();
                return RedirectToAction("Index", "Recipes");
            }
            catch
            {
                return View();
            }

        }
        
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
