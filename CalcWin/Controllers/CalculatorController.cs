﻿using Microsoft.AspNetCore.Mvc;
using CalcWin.Data;
using CalcWin.Views.Calculator;
using CalcWin.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace CalcWin.Controllers
{
   public class CalculatorController : Controller
   {
      private readonly CalculatorLogic _calculatorLogic;

      public CalculatorController(CalculatorLogic calculatorLogic)
      {
         _calculatorLogic = calculatorLogic;
      }

      [HttpGet]
      public IActionResult Index()
      {
         if (ModelState.IsValid)
         {
            CalculatorViewModel viewModel = _calculatorLogic.PrepareStartData();
            return View(MVC.Views.Calculator.Index, viewModel);
         }
         else
         {
            return View(MVC.Views.Calculator.Index);
         }
      }

      [HttpPost]
      [Authorize]
      public IActionResult Add(CalculatorViewModel model)
      {
         if (ModelState.IsValid)
         {
            _calculatorLogic.AddWineProject(User.Claims.First().Value, model);
            return RedirectToAction(MVC.Actions.Calculator.Index);
         }
         else
         {
            return View(MVC.Views.Calculator.Index);
         }
      }

      [HttpPost]
      [Authorize]
      public IActionResult Calculate(CalculatorViewModel model)
      {
         if (ModelState.IsValid)
         {
            CalculatorViewModel viewModel = _calculatorLogic.CalculateWineResult(model);
            return RedirectToAction(MVC.Actions.Calculator.Index);
         }
         else
         {
            return View(MVC.Views.Calculator.Index);
         }
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