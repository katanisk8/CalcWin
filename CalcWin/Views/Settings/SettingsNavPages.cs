using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CalcWin.Views.Settings
{
    public static class SettingsNavPages
    {
        public static string ActivePageKey => "ActivePage";
        public static string Index => "Index";
        public static string Fruits => "Fruits";
        public static string Supplements => "Supplements";
        public static string AdminSettings => "AdminSettings";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string FruitsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Fruits);
        public static string SupplementsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Supplements);
        public static string AdminSettingsNavClass(ViewContext viewContext) => PageNavClass(viewContext, AdminSettings);
        
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
