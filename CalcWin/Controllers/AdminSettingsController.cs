using System;
using Microsoft.AspNetCore.Mvc;
using CalcWin.Models.AdminSettingsViewModels;
using CalcWin.BusinessLogic.ControllersLogic;
using CalcWin.BusinessLogic.ControllersValidations;

namespace CalcWin.Controllers
{
    public class AdminSettingsController : Controller
    {
        private readonly AdminSettingsLogic _adminSettingsLogic;
        private readonly AdminSettingsValidation _validator;

        public AdminSettingsController(
            AdminSettingsLogic adminSettingsLogic,
            AdminSettingsValidation validator)
        {
            _adminSettingsLogic = adminSettingsLogic;
            _validator = validator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DefaultData()
        {
            return View();
        }

        public IActionResult LoadDefaultData(DefaultDataViewModel model)
        {
            try
            {
                _validator.ValidateModelToLoadDefaultData(model);
                _adminSettingsLogic.LoadDefaultData(model);

                return View(MVC.Views.AdminSettings.Index);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }

            return View(MVC.Views.AdminSettings.DefaultData, model);
        }
    }
}