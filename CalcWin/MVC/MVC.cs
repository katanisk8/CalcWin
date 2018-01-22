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

      public static class Shared
      {
         public const string Error = "~/Views/Calculator/Error.cshtml";
      }
   }

   public static class Actions
   {
      public static class Calculator
      {
         public const string Index = "Index";
         public const string Add = "Add";
         public const string Calculate = "Calculate";
      }

      public static class Projects
      {
         public const string Index = "Index";
         public const string Open = "Open";
         public const string Edit = "Edit";
         public const string Update = "Update";
         public const string Delete = "Delete";
      }
   }
}
