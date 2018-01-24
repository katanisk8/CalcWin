using System;
using System.Linq;
using CalcWin.Data;
using Calculator.Models;
using CalcWin.Views.Calculator;
using System.Collections.Generic;
using CalcWin.BusinessLogic.ControllersValidations;

namespace CalcWin.BusinessLogic
{
   public class CalculatorLogic
   {
      private readonly ApplicationDbContext db;
      private CalculatorValidation validation;

      public CalculatorLogic(ApplicationDbContext context)
      {
         db = context;
         validation = new CalculatorValidation();
      }

      public CalculatorViewModel PrepareStartData()
      {
         CalculatorViewModel viewModel = CreateCalculatorViewModel();
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

      public CalculatorViewModel CalculateWineResult(CalculatorViewModel model)
      {
         if (validation.ValidateCalculateWineResult(model))
         {
            List<Ingredient> ingredients = model.Ingredients.Where(x => x.Quantity > 0).ToList();
            Flavor flavor = db.Flavors.First(x => x.Id == model.SelectedFlavor);
            double selectedAlcoholQuantity = model.SelectedAlcoholQuantity;
            double juiceCorretion = model.JuiceCorretion;
            Supplements suplements = GetUserSupplementsOrDefault();


         }
         return model; //Calculations.CalculateWine(ingredients, flavor, selectedAlcoholQuantity, juiceCorretion,); ;
      }

      private Supplements GetUserSupplementsOrDefault()
      {
         Supplements supplements = new Supplements();

         supplements.Water = 
      }

      private CalculatorViewModel CreateCalculatorViewModel()
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
