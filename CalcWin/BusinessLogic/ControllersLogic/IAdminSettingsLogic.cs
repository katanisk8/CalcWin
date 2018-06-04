using CalcWin.Models.AdminSettingsViewModels;

namespace CalcWin.BusinessLogic.ControllersLogic
{
    public interface IAdminSettingsLogic
    {
        UsersViewModel GetUserList();
        void LoadDefaultData(DefaultDataViewModel model);
    }
}