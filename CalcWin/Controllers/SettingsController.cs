using Microsoft.AspNetCore.Mvc;
using CalcWin.BusinessLogic.ControllersLogic;
using CalcWin.BusinessLogic.ControllersValidations;

namespace CalcWin.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ISettingsLogic _logic;
        private readonly ISettingsValidator _validator;

        public SettingsController(ISettingsLogic logic, ISettingsValidator validator)
        {
            _logic = logic;
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
    }
}