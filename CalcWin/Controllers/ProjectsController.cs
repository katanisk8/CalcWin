using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CalcWin.Data;
using Microsoft.EntityFrameworkCore;
using Calculator.Models;
using CalcWin.Views.Projects;
using CalcWin.Views.Calculator;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
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
        [Authorize]
        public IActionResult Open(ProjectsViewModel model)
        {

            if (model.SelectedWineProjectId > 0)
            {
                CalculatorViewModel viewModel = new CalculatorViewModel();

                WineProject wineProject = db.Projects
                    .Include(x => x.Flavor)
                    .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Fruit)
                    .First(x => x.Id == model.SelectedWineProjectId);

                viewModel.Ingredients = wineProject.Ingredients;
                //viewModel.Flavors = new SelectList(db.Flavors, "Id", "Name");
                viewModel.SelectedFlavor = wineProject.Flavor.Id;
                viewModel.SelectedAlcoholQuantity = wineProject.AlcoholQuantity;

                return RedirectToAction("Open", "Calculator", viewModel);
            }

            return RedirectToAction("Index", "Calculator");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(ProjectsViewModel model)
        {
            db.Projects.Update(model.WineProject);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(ProjectsViewModel model)
        {
            WineProject wineProject = db.Projects.First(x => x.Id == model.SelectedWineProjectId);

            db.Projects.Remove(wineProject);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}