using CalcWin.Controllers;

namespace MVC
{
    public static class Views
    {
        public static class Calculator
        {
            public const string Index = "~/Views/Calculator/Index.cshtml";
        }

        public static class Projects
        {
            public const string Index = "~/Views/Projects/Index.cshtml";
            public const string EditProject = "~/Views/Projects/EditProject.cshtml";
        }

        public static class Settings
        {
            public const string Index = "~/Views/Settings/Index.cshtml";
        }

        public static class AdminSettings
        {
            public const string Index = "~/Views/AdminSettings/Index.cshtml";
            public const string DefaultData = "~/Views/AdminSettings/DefaultData.cshtml";
        }

        public static class Shared
        {
            public const string Error = "~/Views/Shared/Error.cshtml";
        }
    }

    public static class Actions
    {
        public static class Home
        {
            public const string Index = nameof(HomeController.Index);
            public const string Contact = nameof(HomeController.Contact);
        }

        public static class Calculator
        {
            public const string Index = nameof(CalculatorController.Index);
            public const string Add = nameof(CalculatorController.Add);
            public const string Calculate = nameof(CalculatorController.Calculate);
        }

        public static class Projects
        {
            public const string Index = nameof(ProjectsController.Index);
            public const string Open = nameof(ProjectsController.Open);
            public const string Edit = nameof(ProjectsController.Edit);
            public const string Update = nameof(ProjectsController.Update);
            public const string Delete = nameof(ProjectsController.Delete);
        }

        public static class Settings
        {
            public const string Index = nameof(SettingsController.Index);
            public const string Fruits = nameof(SettingsController.Fruits);
            public const string Supplements = nameof(SettingsController.Supplements);
        }

        public static class AdminSettings
        {
            public const string Index = nameof(AdminSettingsController.Index);
            public const string DefaultData = nameof(AdminSettingsController.DefaultData);
        }
    }
    public static class Controllers
    {
        public const string Home = nameof(Actions.Home);
        public const string Calculator = nameof(Actions.Calculator);
        public const string Projects = nameof(Actions.Projects);
        public const string Settings = nameof(Actions.Settings);
        public const string AdminSettings = nameof(Actions.AdminSettings);
    }
}
