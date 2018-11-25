using System;
using System.Linq;
using CalcWin.DataAccess.Data;
using CalcWin.DataAccess.Model;
using CalcWin.Views.Calculator;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using CalcWin.DataAccess.Model.User;
using CalcWin.Client.CalcService;

namespace CalcWin.BusinessLogic.ControllersLogic
{
   public class CalculatorLogic : ICalculatorLogic
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICalcService _calcService;

        public CalculatorLogic(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ICalcService calcService)
        {
            db = context;
            _userManager = userManager;
           _calcService = calcService;
        }

        public CalculatorViewModel PrepareStartData()
        {
            CalculatorViewModel viewModel = GetInstanceCalculatorViewModel();
            IList<Ingredient> fruits = new List<Ingredient>();

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

            return viewModel;
        }

        public void AddWineProject(string userId, CalculatorViewModel model)
        {
            WineProject wineProject = new WineProject();

            wineProject.User = userId;
            wineProject.Ingredients = GetIngredientsFromModel(model.Ingredients);
            wineProject.Name = model.Name;
            wineProject.Flavor = db.Flavors.First(x => x.Id == model.SelectedFlavor);
            wineProject.AlcoholQuantity = model.SelectedAlcoholQuantity;
            wineProject.Date = DateTime.Now;

            db.WineProjects.Add(wineProject);
            db.SaveChanges();
        }

        public void FillMissingItemsInModel(CalculatorViewModel model)
        {
            model.Flavors = new SelectList(db.Flavors, "Id", "Name");
        }

        public async Task<Result> CalculateWineResultAsync(CalculatorViewModel model)
        {
            IList<Ingredient> ingredients = GetIngredientsFromModel(model.Ingredients);
            Flavor flavor = db.Flavors.First(x => x.Id == model.SelectedFlavor);
            double selectedAlcoholQuantity = model.SelectedAlcoholQuantity;
            double juiceCorretion = model.JuiceCorretion;
            IList<Supplement> suplements = GetDefaultSupplements();

            Result result = await _calcService.InitialAsync(ingredients, flavor, selectedAlcoholQuantity, juiceCorretion, suplements);

            return RoundResultValues(result);
        }

        public CalculatorViewModel CalculateWineResultForSavedProject(WineProject project, CalculatorViewModel model)
        {
            IList<Ingredient> ingredients = GetIngredientsFromModel(model.Ingredients);
            Flavor flavor = db.Flavors.First(x => x.Id == model.SelectedFlavor);
            double selectedAlcoholQuantity = model.SelectedAlcoholQuantity;
            double juiceCorretion = model.JuiceCorretion;
            IList<Supplement> suplements = GetProjectSupplementsOrDefault(project.Id);

            //Result result = _calcService.Calculate(ingredients, flavor, selectedAlcoholQuantity, juiceCorretion, suplements);

            model.Flavors = new SelectList(db.Flavors, "Id", "Name");
            //model.Result = RoundResultValues(result);

            return model;
        }

        private IList<Supplement> GetProjectSupplementsOrDefault(int wineProjectId)
        {
            if (CheckIfExistSupplementsForWineProjectId(wineProjectId))
            {
                return GetSupplementsByWineProjectId(wineProjectId);
            }
            else
            {
                return GetDefaultSupplements();
            }
        }

        private IList<Supplement> GetDefaultSupplements()
        {
            IList<Supplement> supplements = db.Supplements.Where(x => x.IsDefault).ToList();

            return supplements;
        }

        private IList<Supplement> GetSupplementsByWineProjectId(int wineProjectId)
        {
            IList<Supplement> supplements = db.Supplements.Where(x => x.WineProject.Id == wineProjectId).ToList();

            return supplements;
        }

        private bool CheckIfExistSupplementsForWineProjectId(int wineProjectId)
        {
            if (db.Supplements.Any(x => x.NormalizedName == "Sugar" && x.WineProject.Id == wineProjectId) &&
                db.Supplements.Any(x => x.NormalizedName == "Acid" && x.WineProject.Id == wineProjectId) &&
                db.Supplements.Any(x => x.NormalizedName == "Water" && x.WineProject.Id == wineProjectId) &&
                db.Supplements.Any(x => x.NormalizedName == "Yeast" && x.WineProject.Id == wineProjectId) &&
                db.Supplements.Any(x => x.NormalizedName == "YeastFood" && x.WineProject.Id == wineProjectId))
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
                Flavors = new SelectList(db.Flavors, "Id", "Name"),
                Result = new Result()
            };
        }

        private IList<Ingredient> GetIngredientsFromModel(IList<Ingredient> items)
        {
            IList<Ingredient> ingredients = new List<Ingredient>();

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
