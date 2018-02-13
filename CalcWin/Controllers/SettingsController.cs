using Microsoft.AspNetCore.Mvc;
using CalcWin.Models.SettingsViewModels;
using CalcWin.BusinessLogic.ControllersLogic;

namespace CalcWin.Controllers
{
    public class SettingsController : Controller
    {
        private readonly SettingsLogic _settingsLogic;

        public SettingsController(SettingsLogic settingsLogic)
        {
            _settingsLogic = settingsLogic;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Fruits()
        {
            return View();
        }

        public IActionResult Supplements()
        {
            return View();
        }

        public IActionResult AdminSettings(AdminSettingsViewModel model)
        {
            return View();
        }

        public IActionResult DefaultData(DefaultDataViewModel model)
        {
            _settingsLogic.LoadDefaultData(model.File);

            return View(MVC.Actions.Settings.AdminSettings);
        }
    }
}