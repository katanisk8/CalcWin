using System;
using System.Linq;
using CalcWin.Data;
using Calculator.Models;
using CalcWin.Views.Calculator;
using System.Collections.Generic;
using CalcWin.BusinessLogic.ControllersValidations;
using CalcWin.Models;
using System.Security.Claims;
using Calculator.BussinesLogic;

namespace CalcWin.BusinessLogic
{
   public class CalculatorLogic
   {
      private readonly ApplicationDbContext db;

      public CalculatorLogic(ApplicationDbContext context)
      {
         db = context;
      }

      public CalculatorViewModel PrepareStartData()
      {
         CalculatorViewModel viewModel = GetInstanceCalculatorViewModel();
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

         return viewModel;
      }

      public void AddWineProject(string userId, CalculatorViewModel model)
      {
         CalculatorValidation validation = new CalculatorValidation();

         if (validation.ValidateAddWineProject(model))
         {
            WineProject wineProject = new WineProject();
            List<Ingredient> ingredients = new List<Ingredient>();

            wineProject.User = userId;

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
         }
      }

      public CalculatorViewModel CalculateWineResult(ClaimsPrincipal user, CalculatorViewModel model)
      {
         CalculatorValidation validation = new CalculatorValidation();

         if (validation.ValidateCalculateWineResult(model))
         {
            List<Ingredient> ingredients = model.Ingredients.Where(x => x.Quantity > 0).ToList();
            Flavor flavor = db.Flavors.First(x => x.Id == model.SelectedFlavor);
            double selectedAlcoholQuantity = model.SelectedAlcoholQuantity;
            double juiceCorretion = model.JuiceCorretion;
            Supplements suplements = GetUserSupplementsOrDefault(user);

            model.Result =  Calculations.CalculateWine(ingredients, flavor, selectedAlcoholQuantity, juiceCorretion, suplements);

            return model;
         }

         return model;
      }

      private Supplements GetUserSupplementsOrDefault(ClaimsPrincipal user)
      {
         Supplements supplements = new Supplements();

         if (user.Identity.IsAuthenticated)
         {
            supplements.Water = db.Supplement.First(x => x.WineProject.User == user.Claims.First().Value && x.WineProject.Id == x.Id);
            supplements.Sugar = db.Supplement.First(x => x.WineProject.User == user.Claims.First().Value && x.WineProject.Id == x.WineProject.Id);
            supplements.Acid = db.Supplement.First(x => x.WineProject.User == user.Claims.First().Value && x.WineProject.Id == x.WineProject.Id);
            supplements.Yeast = db.Supplement.First(x => x.WineProject.User == user.Claims.First().Value && x.WineProject.Id == x.WineProject.Id);
            supplements.YeastFood = db.Supplement.First(x => x.WineProject.User == user.Claims.First().Value && x.WineProject.Id == x.WineProject.Id);

            return supplements;
         }
         else
         {
            supplements.Water = new Supplement { Name = "Water", Price = 0.5, Factor = 1 };
            supplements.Sugar = new Supplement { Name = "Sugar", Price = 0.5, Factor = 1 };
            supplements.Acid = new Supplement { Name = "Acid", Price = 0.5, Factor = 1 };
            supplements.Yeast = new Supplement { Name = "Yeast", Price = 0.5, Factor = 1 };
            supplements.YeastFood = new Supplement { Name = "Yeast Food", Price = 0.5, Factor = 1 };

            return supplements;
         }
      }

      private CalculatorViewModel GetInstanceCalculatorViewModel()
      {
         return new CalculatorViewModel
         {
            Ingredients = new List<Ingredient>(),
            Flavors = new List<Flavor>(),
            Result = new Result()
         };
      }
   }
}
