using System;
using Xunit;
using BurritoMaker.Models;
using BurritoMaker.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace UnitTesting
{
    public class UnitTest1
    {
        private RecipeContext context;

        private Mock<RecipeRepo> repo;
        private HomeController controller;
        [Fact]
        public void TestGetIndex()
        {
            context = new RecipeContext();
            repo = new Mock<RecipeRepo>(context);
            controller = new HomeController(repo.Object);
            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void TestPostTortillaSauce()
        {
            context = new RecipeContext();
            repo = new Mock<RecipeRepo>(context);

            var recipe = new Recipe
            {
                Id = 1,
                Username = "Alan",
                CreatedDate = DateTime.Now,
                Tortilla = "Corn",
                Beans = "Pinto",
                Meat = "Chicken",
                Cheese = "Cheddar",
                Veg1 = "Tomato",
                Veg2 = "Potato"
            };

            controller = new HomeController(repo.Object);
            var result = controller.TortillaSauce(recipe);

            Assert.IsType<ViewResult>(result);
        }
    }
}
