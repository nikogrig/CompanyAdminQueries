using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.Admin.Views.Users
{
    public static class ManageNavAdminPages
    {
        public static string ActivePageKey => "ActivePage";

        public static string Index => "Index";

        public static string CreateUser => "Create";

        public static string CreateDepartment => "CreateDepartment";

        public static string ExternalLogins => "ExternalLogins";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string CreateUserNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreateUser);

        public static string CreateDepartmentNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreateDepartment);

        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActiveAdminPage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}