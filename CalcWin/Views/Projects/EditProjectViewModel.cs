using Calculator.Models;
using System.Collections.Generic;

namespace CalcWin.Views.Projects
{
    public class EditProjectViewModel
    {
        public WineProject WineProject { get; set; }
        public IEnumerable<Flavor> Flavors { get; set; }
    }
}
