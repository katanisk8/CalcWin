using Microsoft.AspNetCore.Mvc;
using CalcWin.Views.Calculator;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using CalcWin.BusinessLogic.ControllersLogic;
using System;
using CalcWin.BusinessLogic.ControllersValidations;

namespace CalcWin.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorLogic _calculatorLogic;
        private readonly CalculatorValidation _validator;

        public CalculatorController(CalculatorLogic calculatorLogic,
            CalculatorValidation validator)
        {
            _calculatorLogic = calculatorLogic;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                CalculatorViewModel viewModel = _calculatorLogic.PrepareStartData();
                return View(MVC.Views.Calculator.Index, viewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }

            return View(MVC.Views.Calculator.Index);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(CalculatorViewModel model)
        {
            try
            {
                _validator.ValidateModelToAddWineProject(model);
                _calculatorLogic.AddWineProject(User.Claims.First().Value, model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }

            CalculatorViewModel newModel = _calculatorLogic.PrepareStartData();
            return View(MVC.Views.Calculator.Index, newModel);
        }

        [HttpPost]
        public IActionResult Calculate(CalculatorViewModel model)
        {
            try
            {
                _validator.ValidateModelToCalculateWine(model);
                CalculatorViewModel viewModel = _calculatorLogic.CalculateWineResult(model);
                return View(MVC.Views.Calculator.Index, viewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }

            CalculatorViewModel newModel = _calculatorLogic.PrepareStartData();
            return View(MVC.Views.Calculator.Index, newModel);
        }
    }
}