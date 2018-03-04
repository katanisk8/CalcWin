using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CalcWin.Views.AdminSettings
{
    public static class AdminSettingsNavPages
    {
        public static string ActivePageKey => "ActivePage";
        public static string Index => "Index";
        public static string DefaultData => "DefaultData";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string DefaultDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DefaultData);
        
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActiveAdminSettingsPage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
