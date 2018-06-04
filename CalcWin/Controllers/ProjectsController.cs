using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CalcWin.Views.Calculator;
using CalcWin.BusinessLogic.ControllersLogic;
using CalcWin.BusinessLogic.ControllersValidations;
using CalcWin.Models.ProjectsViewModel;
using System;
using Microsoft.AspNetCore.Identity;
using CalcWin.Models.User;

namespace CalcWin.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectLogic _logic;
        private readonly IProjectsValidator _validator;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectsController(IProjectLogic logic, IProjectsValidator validator, UserManager<ApplicationUser> userManager)
        {
            _logic = logic;
            _validator = validator;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            ProjectsViewModel viewModel = _logic.LoadProjects(_userManager.GetUserId(User));

            return View(MVC.Views.Projects.Index, viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Open(int projectId)
        {
            try
            {
                _validator.ValidateOpenProjectId(projectId);
                CalculatorViewModel viewModel = _logic.OpenProject(projectId);
                return View(MVC.Views.Calculator.Index, viewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }

            return View(MVC.Views.Calculator.Index);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int projectId)
        {
            try
            {
                _validator.ValidateEditProjectId(projectId);
                EditProjectViewModel viewModel = _logic.EditProject(projectId);
                return View(MVC.Views.Projects.EditProject, viewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }

            return View(MVC.Views.Projects.EditProject);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Update(EditProjectViewModel model)
        {
            try
            {
                _validator.ValidateModelToUpdate(model);
                _logic.Update(model.WineProject);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }

            return View(MVC.Views.Projects.EditProject);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int projectId)
        {
            try
            {
                _validator.ValidateDeleteProjectId(projectId);
                _logic.DeleteProject(projectId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }

            return RedirectToAction(MVC.Actions.Projects.Index);
        }
    }
}