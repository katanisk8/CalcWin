using Microsoft.AspNetCore.Mvc;
using CalcWin.Models.SettingsViewModels;
using CalcWin.BusinessLogic.ControllersLogic;
using System.IO;
using System;
using CalcWin.BusinessLogic.ControllersValidations;

namespace CalcWin.Controllers
{
    public class SettingsController : Controller
    {
        private readonly SettingsLogic _settingsLogic;
        private readonly SettingsValidation _validator;

        public SettingsController(
            SettingsLogic settingsLogic,
            SettingsValidation validator)
        {
            _settingsLogic = settingsLogic;
            _validator = validator;
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
            try
            {
                _validator.ValidateModelToLoadDefaultData(model);
                _settingsLogic.LoadDefaultData(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }

            return View(MVC.Actions.Settings.AdminSettings);
        }
    }
}