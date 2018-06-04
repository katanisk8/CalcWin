using CalcWin.Models.AdminSettingsViewModels;

namespace CalcWin.BusinessLogic.ControllersValidations
{
    public interface IAdminSettingsValidator
    {
        void ValidateModelToLoadDefaultData(DefaultDataViewModel model);
    }
}