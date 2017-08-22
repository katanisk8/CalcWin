using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CalcWin.Data;
using Microsoft.EntityFrameworkCore;
using CalcWin.Models;

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
            var viewModel = db.Projects.Include(x => x.Flavor).Include(x => x.Ingredients).ThenInclude(x => x.Fruit).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Open(int wineProjectId)
        {
            return RedirectToAction("Index", "Calculator");
        }

        [HttpPost]
        public IActionResult Edit(WineProject wineProject)
        {
            return Index();
        }

        [HttpPost]
        public IActionResult Delete(int wineProjectId)
        {
            return View("Index");
        }
    }
}