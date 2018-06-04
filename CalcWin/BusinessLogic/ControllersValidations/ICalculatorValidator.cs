using CalcWin.Views.Calculator;

namespace CalcWin.BusinessLogic.ControllersValidations
{
    public interface ICalculatorValidator
    {
        void ValidateModelToAddWineProject(CalculatorViewModel model);
        void ValidateModelToCalculateWine(CalculatorViewModel model);
    }
}