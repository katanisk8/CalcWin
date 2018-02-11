using Microsoft.AspNetCore.Mvc;

namespace CalcWin.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult General()
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