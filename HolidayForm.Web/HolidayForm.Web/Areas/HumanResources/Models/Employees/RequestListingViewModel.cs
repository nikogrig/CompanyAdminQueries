using HolidayForm.Services.HR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.HumanResources.Models.Employees
{
    public class RequestListingViewModel
    {
        public IEnumerable<RequestFromEmployeesListingServiceModel> Forms { get; set; }
    }
}
