using System;
using Microsoft.AspNetCore.Mvc;
using CalcWin.Models.AdminSettingsViewModels;
using CalcWin.BusinessLogic.ControllersLogic;
using CalcWin.BusinessLogic.ControllersValidations;

namespace CalcWin.Controllers
{
   //[Authorize(Roles = "Admin, Dev")]
   public class AdminSettingsController : Controller
   {
      private readonly IAdminSettingsLogic _logic;
      private readonly IAdminSettingsValidator _validator;

      public AdminSettingsController(IAdminSettingsLogic logic, IAdminSettingsValidator validator)
      {
         _logic = logic;
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
            _logic.LoadDefaultData(model);

            return View(MVC.Views.AdminSettings.Index);
         }
         catch (Exception ex)
         {
            ModelState.AddModelError("Error", ex.Message);
         }

         return View(MVC.Views.AdminSettings.DefaultData, model);
      }

      public IActionResult Users()
      {
         try
         {
            UsersViewModel vieModel = _logic.GetUserList();

            return View(vieModel);
         }
         catch (Exception ex)
         {
            ModelState.AddModelError("Error", ex.Message);
         }

         return View();
      }
   }
}