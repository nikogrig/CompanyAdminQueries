using HolidayForm.Services.Managers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Managers.Contracts
{
    public interface IManagerService
    {
        Task<IEnumerable<ManagerDepartmentsServiceModel>> GetDepartmentsByManagerIdAsync(string managerId);

        Task<bool> IsManagerAsync(int departmentId, string managerId);

        Task<IEnumerable<EnrolledStaffInDepartmentServiceModel>> GetStaffInDepartmentAsync(int departmentId);

        Task<DepartmentsListingServiceModel> GetDepartmentByIdAsync(int departmentId);

        Task<EmployeeListingFormsServiceView> GetEmployeeFormsByIdAsync(string employeeId);

        Task<EmployeeQueryFormServiceModel> GetQueryFormByIdAsync(int formId);

        Task UpdateRequestConfirmationByIdAsync(int id, bool isConfirmed);

        //Task GetRequestByIdAsync(int id, string title, string description, DateTime startDate, DateTime endDate, string query, string employeeId, bool isConfirmed);
    }
}
