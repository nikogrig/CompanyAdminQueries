using AutoMapper.QueryableExtensions;
using HolidayForm.Constants;
using HolidayForm.Data;
using HolidayForm.Data.Enums;
using HolidayForm.Data.Models;
using HolidayForm.Services.HR.Contracts;
using HolidayForm.Services.HR.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HolidayForm.Constants.PaginationConstants;

namespace HolidayForm.Services.HR.Implementations
{
    public class HrService : IHrService
    {
        private readonly CompanyDbContext db;

        public HrService(CompanyDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<EmployeeProfileServiceView>> GetAllEmployeeAsync(int page = START_PAGE)
        {
            var employee = await this.db
                .Users
                .OrderBy(d => d.HireDate)
                .Skip(GetSkippedPage(page, PAGE_SIZE))
                .Take(PAGE_SIZE)
                .ProjectTo<EmployeeProfileServiceView>()
                .ToListAsync();

            return employee;
        }

        public async Task<int> GetTotalEmployeeCountAsync() => await this.db.Users.CountAsync();

        public async Task<IEnumerable<DepartmentListingServiceModel>> GetAllDepartmentsAsync(int page = START_PAGE)
        {
            var departments = await this.db
                .Departments
                .OrderBy(d => d.Title)
                .Skip(GetSkippedPage(page, PAGE_SIZE))
                .Take(PAGE_SIZE)
                .ProjectTo<DepartmentListingServiceModel>()
                .ToListAsync();

            return departments;
        }

        public async Task<int> GetTotalDepartmentCountAsync() => await this.db.Departments.CountAsync();

        private int GetSkippedPage(int page, int pagesize)
        {
            var skippedpage = (page - 1) * pagesize;

            return skippedpage;
        }

        public async Task<DepartmentInfoServiceModel> GetDepartmentById(int id)
        {
            var department = await this.db
                .Departments
                .Where(d => d.Id == id)
                .ProjectTo<DepartmentInfoServiceModel>()
                .FirstOrDefaultAsync();

            return department;
        }

        public async Task AddManagerDepartmentAsync(int departmentId, string description, string managerId)
        {
            var department = await this.db
                .Departments
                .Where(d => d.Id == departmentId)
                .FirstOrDefaultAsync();

            department.Description = description;
            department.ManagerId = managerId;

            await this.db.SaveChangesAsync();
        }

        public async Task CreateJobTitleAsync(JobTitleEnums title, string description)
        {
            var jobTitle = new JobTitle
            {
                Title = title.ToString(),
                Description = description
            };

            await this.db.JobTitles.AddAsync(jobTitle);

            await this.db.SaveChangesAsync();
        }
    }
}
