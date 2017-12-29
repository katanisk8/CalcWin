using Microsoft.AspNetCore.Mvc;
using CalcWin.Data;
using CalcWin.Views.Calculator;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Calculator.Models;
using Microsoft.AspNetCore.Authorization;

namespace CalcWin.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ApplicationDbContext db;

        public CalculatorController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CalculatorViewModel viewModel = new CalculatorViewModel();
            List<Ingredient> fruits = new List<Ingredient>();

            foreach (var fruit in db.Fruits.ToList())
            {
                fruits.Add(
                    new Ingredient
                    {
                        Fruit = fruit
                    }
                );
            }

            viewModel.Ingredients = fruits;
            viewModel.Flavors = db.Flavors.ToList();
            viewModel.Result = new Result
            {
                Mixture = new Mixture(),
                Recipe = new Recipe { Ingredients = new List<Ingredient>() },
                Wine = new Wine()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Open(CalculatorViewModel model)
        {
            return View("Index", model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(CalculatorViewModel model)
        {
            WineProject wineProject = new WineProject();
            List<Ingredient> ingredients = new List<Ingredient>();

            wineProject.User = User.Claims.First().Value;

            foreach (var ingredient in model.Ingredients)
            {
                if (ingredient.Quantity > 0)
                {
                    ingredient.Fruit = db.Fruits.First(x => x.Id == ingredient.Fruit.Id);
                    ingredient.Project = wineProject;
                    ingredients.Add(ingredient);
                }
            }

            wineProject.Ingredients = ingredients;
            wineProject.Name = model.Name;
            wineProject.Flavor = db.Flavors.First(x => x.Id == model.SelectedFlavor);
            wineProject.AlcoholQuantity = model.SelectedAlcoholQuantity;
            wineProject.Date = DateTime.Now;

            db.Projects.Add(wineProject);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //public IActionResult AddFruits()
        //{
        //    for (int i = 0; i < 20; i++)
        //    {
        //        Fruit fruit = new Fruit { Name = "Jabłkowe", Sugar = 100, Acid = 20, Price = 3.5 };
        //        db.Fruits.Add(fruit);
        //        db.SaveChanges();
        //    }

        //    return Ok();
        //}

        //public IActionResult AddFlavors()
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Flavor flavor = new Flavor { Name = "Sweet", Acidity = 4 };
        //        db.Flavors.Add(flavor);
        //        db.SaveChanges();
        //    }

        //    return Ok();
        //}

        //public IActionResult AddProjects()
        //{
        //    string user = db.Users.FirstOrDefault(x => x.Email == "michal@makowej.pl").Id;
        //    Flavor flavor = db.Flavors.FirstOrDefault(x => x.Id == 2);

        //    List<Ingredient> ingredients = new List<Ingredient>
        //    {
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
        //    };
        //    List<Ingredient> ingredients1 = new List<Ingredient>
        //    {
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
        //    };
        //    List<Ingredient> ingredients2 = new List<Ingredient>
        //    {
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
        //    };
        //    List<Ingredient> ingredients3 = new List<Ingredient>
        //    {
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
        //    };
        //    List<Ingredient> ingredients4 = new List<Ingredient>
        //    {
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 2), Quantity = 10 },
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 3), Quantity = 20 },
        //    new Ingredient { Fruit = db.Fruits.FirstOrDefault(x => x.Id == 4), Quantity = 20 }
        //    };


        //    db.Projects.Add(new WineProject { User = user, Ingredients = ingredients, Name = "Jabłkowe", Flavor = flavor, AlcoholQuantity = 16, Date = DateTime.Now });
        //    db.Projects.Add(new WineProject { User = user, Ingredients = ingredients1, Name = "Gruszkowe", Flavor = flavor, AlcoholQuantity = 17, Date = DateTime.Now });
        //    db.Projects.Add(new WineProject { User = user, Ingredients = ingredients2, Name = "Wiśniowe", Flavor = flavor, AlcoholQuantity = 18, Date = DateTime.Now });
        //    db.Projects.Add(new WineProject { User = user, Ingredients = ingredients3, Name = "Czereśniowe", Flavor = flavor, AlcoholQuantity = 19, Date = DateTime.Now });
        //    db.Projects.Add(new WineProject { User = user, Ingredients = ingredients4, Name = "Ryżowe", Flavor = flavor, AlcoholQuantity = 20, Date = DateTime.Now });

        //    db.SaveChanges();

        //    return Ok();
        //}
    }
}