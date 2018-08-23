using HolidayForm.Data.Enums;
using HolidayForm.Services.Workers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Workers.Contracts
{
    public interface IWorkersService
    {
       Task CreateFormAsync(string title, string description, DateTime startDate, DateTime endDate, Query query, string employeeId);

       Task<EmployeeStatusServiceModel> GetEmployeeStatusByIdAsync(string employeeId);
    }
}
