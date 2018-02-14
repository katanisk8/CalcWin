using Microsoft.AspNetCore.Mvc;
using CalcWin.Views.Calculator;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using CalcWin.BusinessLogic.ControllersLogic;

namespace CalcWin.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorLogic _calculatorLogic;

        public CalculatorController(CalculatorLogic calculatorLogic)
        {
            _calculatorLogic = calculatorLogic;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CalculatorViewModel viewModel = _calculatorLogic.PrepareStartData();
            return View(MVC.Views.Calculator.Index, viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(CalculatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                _calculatorLogic.AddWineProject(User.Claims.First().Value, model);
                return RedirectToAction(MVC.Actions.Calculator.Index);
            }
            else
            {
                return View(MVC.Views.Calculator.Index);
            }
        }

        [HttpPost]
        public IActionResult Calculate(CalculatorViewModel model)
        {
            if (ModelState.IsValid || true)
            {
                CalculatorViewModel viewModel = _calculatorLogic.CalculateWineResult(model);
                return View(MVC.Views.Calculator.Index, viewModel);
            }
            else
            {
                return View(MVC.Views.Calculator.Index);
            }
        }
    }
}