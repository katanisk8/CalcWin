using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CalcWin.Views.Calculator;
using CalcWin.BusinessLogic.ControllersLogic;
using CalcWin.BusinessLogic.ControllersValidations;
using CalcWin.Models.ProjectsViewModel;
using System;

namespace CalcWin.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectLogic _projectLogic;
        private readonly ProjectsValidation _validator;

        public ProjectsController(
            ProjectLogic projectLogic,
            ProjectsValidation validator)
        {
            _projectLogic = projectLogic;
            _validator = validator;
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
            try
            {
                _validator.ValidateOpenProjectId(projectId);
                CalculatorViewModel viewModel = _projectLogic.OpenProject(projectId);
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
                EditProjectViewModel viewModel = _projectLogic.EditProject(projectId);
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
                _projectLogic.Update(model.WineProject);
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
                _projectLogic.DeleteProject(projectId);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }

            return RedirectToAction(MVC.Actions.Projects.Index);
        }
    }
}