using System;
using System.Linq;
using CalcWin.Data;
using Calculator.Models;
using CalcWin.Views.Calculator;
using System.Collections.Generic;
using Calculator.BussinesLogic;
using Microsoft.AspNetCore.Identity;
using CalcWin.Models;

namespace CalcWin.BusinessLogic.ControllersLogic
{
    public class CalculatorLogic
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CalculatorLogic(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            db = context;
            _userManager = userManager;
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

        public CalculatorViewModel CalculateWineResult(CalculatorViewModel model)
        {
            List<Ingredient> ingredients = GetIngredientsFromModel(model.Ingredients);
            Flavor flavor = db.Flavors.First(x => x.Id == model.SelectedFlavor);
            double selectedAlcoholQuantity = model.SelectedAlcoholQuantity;
            double juiceCorretion = model.JuiceCorretion;
            List<Supplement> suplements = GetDefaultSupplements();

            Result result = Calculations.CalculateWine(ingredients, flavor, selectedAlcoholQuantity, juiceCorretion, suplements);

            model.Flavors = db.Flavors.ToList();
            model.Result = RoundResultValues(result);

            return model;
        }

        public CalculatorViewModel CalculateWineResultForSavedProject(WineProject project, CalculatorViewModel model)
        {
            List<Ingredient> ingredients = GetIngredientsFromModel(model.Ingredients);
            Flavor flavor = db.Flavors.First(x => x.Id == model.SelectedFlavor);
            double selectedAlcoholQuantity = model.SelectedAlcoholQuantity;
            double juiceCorretion = model.JuiceCorretion;
            List<Supplement> suplements = GetProjectSupplementsOrDefault(project.Id);

            Result result = Calculations.CalculateWine(ingredients, flavor, selectedAlcoholQuantity, juiceCorretion, suplements);

            model.Flavors = db.Flavors.ToList();
            model.Result = RoundResultValues(result);

            return model;
        }

        private List<Supplement> GetProjectSupplementsOrDefault(int projectId)
        {
            if (CheckIfExistSupplementsForProjectId(projectId))
            {
                return GetSupplementsByProjectId(projectId);
            }
            else
            {
                return GetDefaultSupplements();
            }
        }

        private List<Supplement> GetDefaultSupplements()
        {
            List<Supplement> supplements = new List<Supplement>();

            var queryResult = from supplement in db.Supplement
                              join supplementType in db.SupplementType on supplement.Parameters.Id equals supplementType.Id
                              where supplementType.IsDefault == true
                              select new { Supplement = supplement, SupplementType = supplementType };

            foreach (var item in queryResult)
            {
                item.Supplement.Parameters = item.SupplementType;
                supplements.Add(item.Supplement);
            }

            return supplements;
        }

        private List<Supplement> GetSupplementsByProjectId(int projectId)
        {
            List<Supplement> supplements = new List<Supplement>();

            var queryResult = from supplement in db.Supplement
                              join supplementType in db.SupplementType on supplement.Parameters.Id equals supplementType.Id
                              where supplement.Project.Id == projectId
                              select new { Supplement = supplement, SupplementType = supplementType };

            foreach (var item in queryResult)
            {
                item.Supplement.Parameters = item.SupplementType;
                supplements.Add(item.Supplement);
            }

            return supplements;
        }

        private bool CheckIfExistSupplementsForProjectId(int projectId)
        {
            if (db.Supplement.Any(x => x.Parameters.Type == 0 && x.Project.Id == projectId) &&
                db.Supplement.Any(x => x.Parameters.Type == 1 && x.Project.Id == projectId) &&
                db.Supplement.Any(x => x.Parameters.Type == 2 && x.Project.Id == projectId) &&
                db.Supplement.Any(x => x.Parameters.Type == 3 && x.Project.Id == projectId) &&
                db.Supplement.Any(x => x.Parameters.Type == 4 && x.Project.Id == projectId))
            {
                return true;
            }
            else
            {
                return false;
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
    }
}
