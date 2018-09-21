using System.Linq;
using DataAccess.Model;
using CalcWin.Views.Calculator;
using Microsoft.EntityFrameworkCore;
using CalcWin.Models.ProjectsViewModel;
using DataAccess.Data;

namespace CalcWin.BusinessLogic.ControllersLogic
{
   public class ProjectLogic : IProjectLogic
    {
        private readonly ApplicationDbContext _db;

        public ProjectLogic(ApplicationDbContext context)
        {
            _db = context;
        }

        public ProjectsViewModel LoadProjects(string userId)
        {
            ProjectsViewModel viewModel = new ProjectsViewModel();

            viewModel.Projects = _db.WineProjects.Where(x => x.User == userId)
                .Include(x => x.Flavor)
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Fruit)
                .ToList();

            return viewModel;
        }

        public CalculatorViewModel OpenProject(int projectId)
        {
            CalculatorViewModel viewModel = new CalculatorViewModel();

            WineProject wineProject = _db.WineProjects
                .Include(x => x.Flavor)
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Fruit)
                .First(x => x.Id == projectId);

            viewModel.Ingredients = wineProject.Ingredients.ToList();
            viewModel.SelectedFlavor = wineProject.Flavor.Id;
            viewModel.SelectedAlcoholQuantity = wineProject.AlcoholQuantity;

            return viewModel;
        }

        public EditProjectViewModel EditProject(int wineProjectId)
        {
            EditProjectViewModel model = new EditProjectViewModel();

            model.WineProject = _db.WineProjects
                .Include(x => x.Flavor)
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Fruit)
                .First(x => x.Id == wineProjectId);

            model.Flavors = _db.Flavors.ToList();

            return model;
        }

        public void DeleteProject(int wineProjectId)
        {
            var projectIngerdients = _db.Ingredients.Where(x => x.WineProject.Id == wineProjectId);

            foreach (var ingerdient in projectIngerdients.ToList())
            {
                _db.Ingredients.Remove(ingerdient);
            }

            WineProject wineProject = _db.WineProjects.First(x => x.Id == wineProjectId);

            _db.WineProjects.Remove(wineProject);
            _db.SaveChanges();
        }

        public void Update(WineProject project)
        {
            _db.WineProjects.Update(project);
            _db.SaveChanges();
        }
    }
}
