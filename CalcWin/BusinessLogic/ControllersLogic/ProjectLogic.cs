using System.Linq;
using CalcWin.Data;
using Calculator.Models;
using CalcWin.Views.Calculator;
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

            viewModel.Projects = db.WineProjects.Where(x => x.User == userId)
                .Include(x => x.Flavor)
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Fruit)
                .ToList();

            return viewModel;
        }

        internal CalculatorViewModel OpenProject(int projectId)
        {
            CalculatorViewModel viewModel = new CalculatorViewModel();

            WineProject wineProject = db.WineProjects
                .Include(x => x.Flavor)
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Fruit)
                .First(x => x.Id == projectId);

            viewModel.Ingredients = wineProject.Ingredients;
            viewModel.SelectedFlavor = wineProject.Flavor.Id;
            viewModel.SelectedAlcoholQuantity = wineProject.AlcoholQuantity;

            return viewModel;
        }

        internal EditProjectViewModel EditProject(int wineProjectId)
        {
            EditProjectViewModel model = new EditProjectViewModel();

            model.WineProject = db.WineProjects
                .Include(x => x.Flavor)
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Fruit)
                .First(x => x.Id == wineProjectId);

            model.Flavors = db.Flavors.ToList();

            return model;
        }

        internal void DeleteProject(int wineProjectId)
        {
            var projectIngerdients = db.Ingredients.Where(x => x.WineProject.Id == wineProjectId);

            foreach (var ingerdient in projectIngerdients.ToList())
            {
                db.Ingredients.Remove(ingerdient);
            }

            WineProject wineProject = db.WineProjects.First(x => x.Id == wineProjectId);

            db.WineProjects.Remove(wineProject);
            db.SaveChanges();
        }
        
        internal void Update(WineProject project)
        {
            db.WineProjects.Update(project);
            db.SaveChanges();
        }
    }
}
