using DataAccess.Model;
using CalcWin.Views.Calculator;

namespace CalcWin.BusinessLogic.ControllersLogic
{
    public interface ICalculatorLogic
    {
        void AddWineProject(string userId, CalculatorViewModel model);
        void FillMissingItemsInModel(CalculatorViewModel model);
        void CalculateWineResultAsync(CalculatorViewModel model);
        CalculatorViewModel CalculateWineResultForSavedProject(WineProject project, CalculatorViewModel model);
        CalculatorViewModel PrepareStartData();
    }
}