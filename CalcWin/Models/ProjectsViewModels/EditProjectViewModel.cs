using Calculator.Model;
using System.Collections.Generic;

namespace CalcWin.Models.ProjectsViewModel
{
    public class EditProjectViewModel
    {
        public WineProject WineProject { get; set; }
        public IEnumerable<Flavor> Flavors { get; set; }
    }
}
