using CalcWin.Models.ProjectsViewModel;

namespace CalcWin.BusinessLogic.ControllersValidations
{
    public interface IProjectsValidator
    {
        void ValidateDeleteProjectId(int projectId);
        void ValidateEditProjectId(int projectId);
        void ValidateModelToUpdate(EditProjectViewModel model);
        void ValidateOpenProjectId(int projectId);
    }
}