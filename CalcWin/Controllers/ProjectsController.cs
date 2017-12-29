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
        public IActionResult Edit(ProjectsViewModel model)
        {
            db.Projects.Update(model.WineProject);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int projectId)
        {
            WineProject wineProject = db.Projects.First(x => x.Id == projectId);

            db.Projects.Remove(wineProject);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}