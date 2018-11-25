using System.Threading.Tasks;
using CalcWin.DataAccess.Model;
using CalcWin.Views.Calculator;

namespace CalcWin.BusinessLogic.ControllersLogic
{
    public interface ICalculatorLogic
    {
        void AddWineProject(string userId, CalculatorViewModel model);
        void FillMissingItemsInModel(CalculatorViewModel model);
        Task<Result> CalculateWineResultAsync(CalculatorViewModel model);
        CalculatorViewModel CalculateWineResultForSavedProject(WineProject project, CalculatorViewModel model);
        CalculatorViewModel PrepareStartData();
    }
}