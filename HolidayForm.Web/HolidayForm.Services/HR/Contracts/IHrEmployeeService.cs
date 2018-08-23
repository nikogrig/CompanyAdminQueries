using HolidayForm.Data.Enums;
using HolidayForm.Services.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.HR.Contracts
{
    public interface IHrEmployeeService
    {
        Task<EmployeeDetailsServiceModel> GetEmployeeByIdAsync(string employeeId);

        Task<IEnumerable<EmployeeJobsServiceModel>> GetAllJobTitleAsync();

        Task<bool> EmployeeIsEnrolledInDepartmentAsync(string employeeId, int departmentId);

        Task<bool> UpdateEmployeePersonalInfoAsync(string employeeId, double salary, DateTime hireDate, Status status);

        Task<IEnumerable<EmployeeInDepartmentListingServiceModel>> GetEmployeesInDepartmentAsync(int id);

        Task<IEnumerable<RequestFromEmployeesListingServiceModel>> GetRequestFromEmployees();

        Task UpdateWorkStatusForEmployee(string id, Status status, int formId);

        Task<bool> UpdateEmployeeDepartmentJobTitleAsync(string employeeId, int departmentId, int jobTitleId);
    }
}
