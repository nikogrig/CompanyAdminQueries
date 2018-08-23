using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.HumanResources.Views.HR
{
    public static class ManageNavHrPages
    {
        public static string ActivePageKey => "ActivePage";

        public static string Employees => "Employees";

        public static string Departments => "Departments";

        public static string CreateJobTitle => "CreateJobTitle";

        public static string Requests => "Requests";

        public static string ExternalLogins => "ExternalLogins";

        public static string EmployeesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Employees);

        public static string DepartmentsUserNavClass(ViewContext viewContext) => PageNavClass(viewContext, Departments);

        public static string CreateJobTitleNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreateJobTitle);

        public static string RequestsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Requests);

        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActiveAdminPage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}