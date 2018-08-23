using HolidayForm.Services.Managers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.Managers.Models.Employees
{
    public class EmployeeQueriesViewModel
    {
        public EmployeeListingFormsServiceView Employee { get; set; }
    }
}
