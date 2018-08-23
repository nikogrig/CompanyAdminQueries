using AutoMapper.QueryableExtensions;
using HolidayForm.Data;
using HolidayForm.Data.Enums;
using HolidayForm.Data.Models;
using HolidayForm.Services.Admin.Contracts;
using HolidayForm.Services.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HolidayForm.Constants.PaginationConstants;

namespace HolidayForm.Services.Admin.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly CompanyDbContext db;

        public AdminUserService(CompanyDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> GetAllUsersAsync(int page = START_PAGE)
        {
            var users = await this.db
                .Users
                .OrderBy(u => u.UserName)
                .Skip(GetSkippedPage(page, PAGE_SIZE))
                .Take(PAGE_SIZE)
                .ProjectTo<AdminUserListingServiceModel>()
                .ToListAsync();

            return users;
        }

        public async Task<int> GetTotalUsersCountAsync() => await this.db.Users.CountAsync();

        public async Task<AdminUserListingServiceModel> GetUserByIdAsync(string id)
        {
            var user = await this.db
                .Users
                .Where(u => u.Id == id)
                .ProjectTo<AdminUserListingServiceModel>()
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task CreateDepartmentASync(DepartmentEnums title, string description)
        {
            var department = new Department
            {
                Title = title.ToString(),
                Description = description,
            };

            await this.db.Departments.AddAsync(department);

            await this.db.SaveChangesAsync();
        }

        private int GetSkippedPage(int page, int pagesize)
        {
            var skippedpage = (page - 1) * pagesize;

            return skippedpage;
        }
    }
}
