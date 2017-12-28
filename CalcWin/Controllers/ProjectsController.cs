using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CalcWin.Data;
using Microsoft.EntityFrameworkCore;
using Calculator.Models;
using CalcWin.Views.Projects;
using CalcWin.Views.Calculator;

namespace CalcWin.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProjectsController(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ProjectsViewModel viewModel = new ProjectsViewModel();
            viewModel.Projects = db.Projects
                .Include(x => x.Flavor)
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Fruit)
                .ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Open(ProjectsViewModel model)
        {
            if (model.SelectedWineProjectId > 0)
            {
                WineProject wineProject = db.Projects
                    .Include(x => x.Flavor)
                    .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Fruit)
                    .First(x => x.Id == model.SelectedWineProjectId);

                CalculatorViewModel viewModel = new CalculatorViewModel();
                viewModel.Ingredients = wineProject.Ingredients;
                viewModel.SelectedFlavor = wineProject.Flavor.Id;
                viewModel.SelectedAlcoholQuantity = wineProject.AlcoholQuantity;

                return RedirectToAction("Index", "Calculator", viewModel);
            }

            return RedirectToAction("Index", "Calculator");
        }

        [HttpPost]
        public IActionResult Edit(ProjectsViewModel model)
        {
            return Index();
        }

        [HttpPost]
        public IActionResult Delete(ProjectsViewModel model)
        {
            return View("Index");
        }
    }
}