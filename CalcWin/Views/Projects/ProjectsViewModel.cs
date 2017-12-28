using Calculator.Models;
using System.Collections.Generic;

namespace CalcWin.Views.Projects
{
    public class ProjectsViewModel
    {
        // Start data
        public List<WineProject> Projects { get; set; }

        // Open project
        public int SelectedWineProjectId { get; set; }
    }
}
