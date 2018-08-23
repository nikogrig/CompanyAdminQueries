using HolidayForm.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.HumanResources.Models.Employees
{
    public class EmployeeChangeStatusViewModel
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public Status Status { get; set; }

        public string JobTitle { get; set; }
    }
}
