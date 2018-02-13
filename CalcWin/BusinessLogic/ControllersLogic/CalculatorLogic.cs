using System;
using System.Linq;
using CalcWin.Data;
using Calculator.Models;
using CalcWin.Views.Calculator;
using System.Collections.Generic;
using CalcWin.BusinessLogic.ControllersValidations;
using System.Security.Claims;
using Calculator.BussinesLogic;

namespace CalcWin.BusinessLogic.ControllersLogic
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
                wineProject.Ingredients = GetIngredientsFromModel(model.Ingredients);
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
                List<Ingredient> ingredients = GetIngredientsFromModel(model.Ingredients);
                Flavor flavor = db.Flavors.First(x => x.Id == model.SelectedFlavor);
                double selectedAlcoholQuantity = model.SelectedAlcoholQuantity;
                double juiceCorretion = model.JuiceCorretion;
                Supplements suplements = GetUserSupplementsOrDefault(user);

                model.Flavors = db.Flavors.ToList();
                Result result = Calculations.CalculateWine(ingredients, flavor, selectedAlcoholQuantity, juiceCorretion, suplements);
                model.Result = RoundResultValues(result);

                return model;
            }

            return model;
        }

        private Result RoundResultValues(Result result)
        {
            Result roundedResult = new Result();

            // Mixture 
            roundedResult.Mixture.FruitsQuantity = Math.Round(result.Mixture.FruitsQuantity, 2);
            roundedResult.Mixture.FruitsMixture = Math.Round(result.Mixture.FruitsMixture, 2);
            roundedResult.Mixture.SugarInMixture = Math.Round(result.Mixture.SugarInMixture, 2);
            roundedResult.Mixture.AcidInMixture = Math.Round(result.Mixture.AcidInMixture, 2);
            roundedResult.Mixture.JuiceQuantity = Math.Round(result.Mixture.JuiceQuantity, 2);
            roundedResult.Mixture.SugarInJuice = Math.Round(result.Mixture.SugarInJuice, 2);
            roundedResult.Mixture.AcidInJuice = Math.Round(result.Mixture.AcidInJuice, 2);

            // Recipe
            roundedResult.Recipe.Ingredients = result.Recipe.Ingredients;
            roundedResult.Recipe.Water = Math.Round(result.Recipe.Water, 2);
            roundedResult.Recipe.Acid = Math.Round(result.Recipe.Acid, 2);
            roundedResult.Recipe.Sugar = Math.Round(result.Recipe.Sugar, 2);
            roundedResult.Recipe.YeastFood = Math.Round(result.Recipe.YeastFood, 2);
            roundedResult.Recipe.Yeast = Math.Round(result.Recipe.Yeast, 2);
            roundedResult.Recipe.SuplementsCost = Math.Round(result.Recipe.SuplementsCost, 2);

            // Wine
            roundedResult.Wine.AlcoholQuantity = Math.Round(result.Wine.AlcoholQuantity, 2);
            roundedResult.Wine.Flavor = result.Wine.Flavor;
            roundedResult.Wine.Color = result.Wine.Color;
            roundedResult.Wine.Quantity = Math.Round(result.Wine.Quantity, 2);
            roundedResult.Wine.TotalCost = Math.Round(result.Wine.TotalCost, 2);
            roundedResult.Wine.CostPerLiter = Math.Round(result.Wine.CostPerLiter, 2);

            return roundedResult;
        }

        private Supplements GetUserSupplementsOrDefault(ClaimsPrincipal user)
        {
            Supplements supplements = new Supplements();

            if (user.Identity.IsAuthenticated)
            {
                supplements.Water = db.Supplement.First(x => x.WineProject.User == user.Claims.First().Value && x.Type == (int)SupplementType.Water);
                supplements.Sugar = db.Supplement.First(x => x.WineProject.User == user.Claims.First().Value && x.Type == (int)SupplementType.Sugar);
                supplements.Acid = db.Supplement.First(x => x.WineProject.User == user.Claims.First().Value && x.Type == (int)SupplementType.Acid);
                supplements.Yeast = db.Supplement.First(x => x.WineProject.User == user.Claims.First().Value && x.Type == (int)SupplementType.Yeast);
                supplements.YeastFood = db.Supplement.First(x => x.WineProject.User == user.Claims.First().Value && x.Type == (int)SupplementType.YeastFood);

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

        private List<Ingredient> GetIngredientsFromModel(IEnumerable<Ingredient> items)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            
            foreach (var ingredient in items)
            {
                if (ingredient.Quantity > 0)
                {
                    ingredient.Fruit = db.Fruits.First(x => x.Id == ingredient.Fruit.Id);
                    ingredients.Add(ingredient);
                }
            }

            return ingredients;
        }
    }
}
