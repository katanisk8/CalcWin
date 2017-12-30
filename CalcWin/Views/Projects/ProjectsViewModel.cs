using Calculator.Models;
using System.Collections.Generic;

namespace CalcWin.Views.Projects
{
    public class ProjectsViewModel
    {
        // Start data
        public List<WineProject> Projects { get; set; }

        // Edit Project
        public int ProjectId { get; set; }
        public WineProject WineProject { get; set; }
    }
}
