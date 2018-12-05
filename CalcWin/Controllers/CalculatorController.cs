using Microsoft.AspNetCore.Mvc;
using CalcWin.Views.Calculator;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using CalcWin.BusinessLogic.ControllersLogic;
using System;
using System.Threading.Tasks;
using CalcWin.BusinessLogic.ControllersValidations;

namespace CalcWin.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorLogic _logic;
        private readonly ICalculatorValidator _validator;

        public CalculatorController(ICalculatorLogic logic, ICalculatorValidator validator)
        {
            _logic = logic;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                CalculatorViewModel viewModel = _logic.PrepareStartData();
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
                _validator.ValidateModelToAddWineProject(ModelState, model);

                if (ModelState.IsValid)
                {
                    _logic.AddWineProject(User.Claims.First().Value, model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }

            CalculatorViewModel newModel = _logic.PrepareStartData();
            return View(MVC.Views.Calculator.Index, newModel);
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(CalculatorViewModel model)
        {
            try
            {
                _validator.ValidateModelToCalculateWine(ModelState, model);
                model.Result =  await _logic.CalculateWineResultAsync(model);
                _logic.FillMissingItemsInModel(model);
                return View(MVC.Views.Calculator.Index, model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }

            CalculatorViewModel newModel = _logic.PrepareStartData();
            return View(MVC.Views.Calculator.Index, newModel);
        }
    }
}