using Calculator.Models;
using System.Collections.Generic;

namespace CalcWin.Views.Projects
{
    public class ProjectsViewModel
    {
        // Start data
        public List<WineProject> Projects { get; set; }

        // Edit Project
        public WineProject WineProject { get; set; }

        // Open/Delete project
        public int SelectedWineProjectId { get; set; }
    }
}
