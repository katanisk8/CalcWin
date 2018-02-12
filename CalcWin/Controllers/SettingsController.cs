using Microsoft.AspNetCore.Mvc;
using CalcWin.Models;
using CalcWin.Models.SettingsViewModels;

namespace CalcWin.Controllers
{
    public class SettingsController : Controller
    {
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

        public IActionResult AdminSettings()
        {
            return View();
        }
    }
}