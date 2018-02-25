using CalcWin.Views.Calculator;
using System;
using Calculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace CalcWin.BusinessLogic.ControllersValidations
{
    public class CalculatorValidation
    {        
        internal void ValidateModelToCalculateWine(CalculatorViewModel model)
        {
            if (model == null)
            {
                throw new Exception("Something went wrong!");
            }

            CheckIngredients(model.Ingredients);
            CheckFlavor(model.SelectedFlavor);
            CheckAlcoholQuantity(model.SelectedAlcoholQuantity);
        }

        internal void ValidateModelToAddWineProject(CalculatorViewModel model)
        {
            if (model == null)
            {
                throw new Exception("Something went wrong!");
            }

            CheckIngredients(model.Ingredients);
            CheckFlavor(model.SelectedFlavor);
            CheckAlcoholQuantity(model.SelectedAlcoholQuantity);
            CheckProjectName(model.Name);
        }

        private void CheckProjectName(string name)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Please set name of wine project");
            }
        }

        private void CheckIngredients(IEnumerable<Ingredient> ingredients)
        {
            if (ingredients.Any(x => x.Quantity > 0) == false)
            {
                throw new Exception("Please choose fruits");
            }
        }

        private void CheckFlavor(int selectedFlavor)
        {
            if (selectedFlavor < 0)
            {
                throw new Exception("Please choose flavor");
            }
        }

        private void CheckAlcoholQuantity(double selectedAlcoholQuantity)
        {
            if (selectedAlcoholQuantity < 0)
            {
                throw new Exception("Please set alcohol quantity");
            }
            else if (selectedAlcoholQuantity > 20)
            {
                throw new Exception("Alcohol quantity can't be bigger then 20%");
            }
        }
    }
}
