using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult AdminSettings()
        {
            return View();
        }
    }
}