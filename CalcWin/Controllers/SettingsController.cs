using Microsoft.AspNetCore.Mvc;
using CalcWin.Models.SettingsViewModels;
using CalcWin.BusinessLogic.ControllersLogic;
using System.IO;
using System;

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
         byte[] fileBytes = new byte[] { };

         if (model.File.Length > 0)
         {
            using (var ms = new MemoryStream())
            {
               model.File.CopyTo(ms);
               fileBytes = ms.ToArray();
            }
         }

         _settingsLogic.LoadDefaultData(fileBytes);

         return View(MVC.Actions.Settings.AdminSettings);
      }
   }
}