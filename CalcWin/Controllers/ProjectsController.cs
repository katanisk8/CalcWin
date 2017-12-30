using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CalcWin.Data;
using Microsoft.EntityFrameworkCore;
using Calculator.Models;
using CalcWin.Views.Projects;
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

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int ProjectId)
        {
            if (ProjectId > 0)
            {
                WineProject model = new WineProject();
                model = db.Projects
                    .Include(x => x.Flavor)
                    .Include(x => x.Ingredients)
                    .ThenInclude(x => x.Fruit)
                    .First(x => x.Id == ProjectId);

                return View("EditProject", model);
            }

            return View("Index");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(WineProject wineProject)
        {
            if (wineProject != null)
            {
                //db.Projects.Update(wineProject);
                //db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int projectId)
        {
            if (projectId > 0)
            {
                WineProject wineProject = db.Projects.First(x => x.Id == projectId);

                db.Projects.Remove(wineProject);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}