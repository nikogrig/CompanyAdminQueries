using HolidayForm.Services.Managers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.Managers.Models.Employees
{
    public class EnrolledEmployeesIndDepartmentViewModel
    {
        public IEnumerable<EnrolledStaffInDepartmentServiceModel> Employees { get; set; }

        public DepartmentsListingServiceModel Departments { get; set; }
    }
}
