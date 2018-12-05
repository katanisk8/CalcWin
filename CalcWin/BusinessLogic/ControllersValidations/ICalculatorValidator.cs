using CalcWin.Views.Calculator;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CalcWin.BusinessLogic.ControllersValidations
{
    public interface ICalculatorValidator
    {
        void ValidateModelToAddWineProject(ModelStateDictionary modelState, CalculatorViewModel model);
        void ValidateModelToCalculateWine(ModelStateDictionary modelState, CalculatorViewModel model);
    }
}