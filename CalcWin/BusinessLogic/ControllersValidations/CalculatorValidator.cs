using CalcWin.Views.Calculator;
using CalcWin.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CalcWin.BusinessLogic.ControllersValidations
{
    public class CalculatorValidator : ICalculatorValidator
    {        
        public void ValidateModelToCalculateWine(ModelStateDictionary modelState, CalculatorViewModel model)
        {
            if (model == null)
            {
                modelState.AddModelError("Model", "Model is null.");
                return;
            }

            CheckIngredients(modelState, model.Ingredients);
            CheckFlavor(modelState, model.SelectedFlavor);
            CheckAlcoholQuantity(modelState, model.SelectedAlcoholQuantity);
        }

        public void ValidateModelToAddWineProject(ModelStateDictionary modelState, CalculatorViewModel model)
        {
            if (model == null)
            {
                modelState.AddModelError("Model", "Model is null.");
                return;
            }

            CheckIngredients(modelState, model.Ingredients);
            CheckFlavor(modelState, model.SelectedFlavor);
            CheckAlcoholQuantity(modelState, model.SelectedAlcoholQuantity);
            CheckProjectName(modelState, model.Name);
        }

        private void CheckProjectName(ModelStateDictionary modelState, string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                modelState.AddModelError("Project name", "Please set name of wine project.");
            }
        }

        private void CheckIngredients(ModelStateDictionary modelState, IEnumerable<Ingredient> ingredients)
        {
            if (ingredients.Any(x => x.Quantity > 0) == false)
            {
                modelState.AddModelError("Fruits", "Please choose fruits.");
            }
        }

        private void CheckFlavor(ModelStateDictionary modelState, int selectedFlavor)
        {
            if (selectedFlavor < 0)
            {
                modelState.AddModelError("Flavor", "Please choose flavor.");
            }
        }

        private void CheckAlcoholQuantity(ModelStateDictionary modelState, double selectedAlcoholQuantity)
        {
            if (selectedAlcoholQuantity <= 0)
            {
                modelState.AddModelError("Alcohol quantity", "Please set alcohol quantity.");
            }
            else if (selectedAlcoholQuantity > 20)
            {
                modelState.AddModelError("Alcohol quantity", "Alcohol quantity can't be bigger then 20%.");
            }
        }
    }
}
