using HolidayForm.Data.Enums;
using HolidayForm.Services.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.HR.Contracts
{
    public interface IHrService
    {
        Task<IEnumerable<EmployeeProfileServiceView>> GetAllEmployeeAsync(int page = 1);

        Task<IEnumerable<DepartmentListingServiceModel>> GetAllDepartmentsAsync(int page = 1);

        Task<int> GetTotalDepartmentCountAsync();

        Task<int> GetTotalEmployeeCountAsync();

        Task<DepartmentInfoServiceModel> GetDepartmentById(int id);

        Task AddManagerDepartmentAsync(int departmentId, string description, string managerId);

        Task CreateJobTitleAsync(JobTitleEnums title, string description);
    }
}
