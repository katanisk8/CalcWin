using Microsoft.AspNetCore.Mvc;
using CalcWin.Views.Projects;
using Microsoft.AspNetCore.Authorization;
using CalcWin.Views.Calculator;
using CalcWin.BusinessLogic.ControllersLogic;
using Calculator.Models;

namespace CalcWin.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectLogic _projectLogic;

        public ProjectsController(ProjectLogic projectLogic)
        {
            _projectLogic = projectLogic;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            ProjectsViewModel viewModel = _projectLogic.LoadProjects();

            return View(MVC.Views.Projects.Index, viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Open(int projectId)
        {
            CalculatorViewModel viewModel = _projectLogic.OpenProject(projectId);

            return View(MVC.Views.Calculator.Index, viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int projectId)
        {
            if (projectId > 0)
            {
                EditProjectViewModel viewModel = _projectLogic.EditProject(projectId);
                return View(MVC.Views.Projects.EditProject, viewModel);
            }

            return View(MVC.Views.Projects.EditProject);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(EditProjectViewModel model)
        {
            if (model.WineProject != null)
            {
                _projectLogic.Update(model.WineProject);
            }

            return View(MVC.Views.Projects.EditProject);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int projectId)
        {
            if (projectId > 0)
            {
                _projectLogic.DeleteProject(projectId);
            }

            return RedirectToAction(MVC.Actions.Projects.Index);
        }
    }
}