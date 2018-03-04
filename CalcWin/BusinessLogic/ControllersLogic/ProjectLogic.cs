using System.Linq;
using CalcWin.Data;
using Calculator.Models;
using CalcWin.Views.Calculator;
using Microsoft.AspNetCore.Identity;
using CalcWin.Models;
using Microsoft.EntityFrameworkCore;
using CalcWin.Models.ProjectsViewModel;

namespace CalcWin.BusinessLogic.ControllersLogic
{
    public class ProjectLogic
    {
        private readonly ApplicationDbContext db;

        public ProjectLogic(ApplicationDbContext context)
        {
            db = context;
        }

        internal ProjectsViewModel LoadProjects(string userId)
        {
            ProjectsViewModel viewModel = new ProjectsViewModel();

            viewModel.Projects = db.Projects.Where(x => x.User == userId)
                .Include(x => x.Flavor)
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Fruit)
                .ToList();

            return viewModel;
        }

        internal CalculatorViewModel OpenProject(int projectId)
        {
            CalculatorViewModel viewModel = new CalculatorViewModel();

            WineProject wineProject = db.Projects
                .Include(x => x.Flavor)
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Fruit)
                .First(x => x.Id == projectId);

            viewModel.Ingredients = wineProject.Ingredients;
            viewModel.SelectedFlavor = wineProject.Flavor.Id;
            viewModel.SelectedAlcoholQuantity = wineProject.AlcoholQuantity;

            return viewModel;
        }

        internal EditProjectViewModel EditProject(int projectId)
        {
            EditProjectViewModel model = new EditProjectViewModel();

            model.WineProject = db.Projects
                .Include(x => x.Flavor)
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Fruit)
                .First(x => x.Id == projectId);

            model.Flavors = db.Flavors.ToList();

            return model;
        }

        internal void DeleteProject(int projectId)
        {
            var projectIngerdients = db.Ingredients.Where(x => x.Project.Id == projectId);

            foreach (var ingerdient in projectIngerdients.ToList())
            {
                db.Ingredients.Remove(ingerdient);
            }

            WineProject project = db.Projects.First(x => x.Id == projectId);

            db.Projects.Remove(project);
            db.SaveChanges();
        }
        
        internal void Update(WineProject project)
        {
            db.Projects.Update(project);
            db.SaveChanges();
        }
    }
}
