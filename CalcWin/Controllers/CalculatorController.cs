using Microsoft.AspNetCore.Mvc;
using CalcWin.Data;
using CalcWin.Models;
using CalcWin.Views.Calculator;
using System.Linq;
using System.Collections.Generic;
using System;

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
            viewModel.Fruits = db.Fruits.ToList();
            viewModel.Flavors = db.Flavors.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Save(WineProject wineProject)
        {
            return View("Index");
        }



        public IActionResult AddProjects()
        {
        //    ApplicationUser user = db.Users.FirstOrDefault(x => x.Email == "michal@makowej.pl");
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


        //    db.Projects.Add(new WineProject { User = user, Ingredients = ingredients, Name = "Difrent - 12", Flavor = flavor, AlcoholQuantity = 16, Date = DateTime.Now });
        //    db.Projects.Add(new WineProject { User = user, Ingredients = ingredients1, Name = "Difrent - 13", Flavor = flavor, AlcoholQuantity = 16, Date = DateTime.Now });
        //    db.Projects.Add(new WineProject { User = user, Ingredients = ingredients2, Name = "Difrent - 14", Flavor = flavor, AlcoholQuantity = 16, Date = DateTime.Now });

        //    db.SaveChanges();

            return Ok();
        }
    }
}