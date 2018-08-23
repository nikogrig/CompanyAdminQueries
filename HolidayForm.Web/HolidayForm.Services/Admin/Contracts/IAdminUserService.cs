using HolidayForm.Data.Enums;
using HolidayForm.Services.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Admin.Contracts
{
    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingServiceModel>> GetAllUsersAsync(int page = 1);

        Task<AdminUserListingServiceModel> GetUserByIdAsync(string id);

        Task<int> GetTotalUsersCountAsync();

        Task CreateDepartmentASync(DepartmentEnums title, string description);
    }
}
