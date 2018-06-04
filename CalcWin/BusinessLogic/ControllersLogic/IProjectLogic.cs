using Calculator.Model;
using CalcWin.Models.ProjectsViewModel;
using CalcWin.Views.Calculator;

namespace CalcWin.BusinessLogic.ControllersLogic
{
    public interface IProjectLogic
    {
        void DeleteProject(int wineProjectId);
        EditProjectViewModel EditProject(int wineProjectId);
        ProjectsViewModel LoadProjects(string userId);
        CalculatorViewModel OpenProject(int projectId);
        void Update(WineProject project);
    }
}