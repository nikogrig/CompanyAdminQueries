using AutoMapper.QueryableExtensions;
using HolidayForm.Data;
using HolidayForm.Data.Models;
using HolidayForm.Services.Managers.Contracts;
using HolidayForm.Services.Managers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Managers.Implementations
{
    public class ManagerService : IManagerService
    {
        private readonly CompanyDbContext db;

        public ManagerService(CompanyDbContext db)
        {
            this.db = db;
        }

        public async Task<EmployeeQueryFormServiceModel> GetQueryFormByIdAsync(int formId)
        {
            var queryForm = await this.db
                .Forms
                .OrderBy(q => q.StartDate)
                .Where(f => f.Id == formId)
                .ProjectTo<EmployeeQueryFormServiceModel>()
                .FirstOrDefaultAsync();

            return queryForm;
        }

        public async Task<DepartmentsListingServiceModel> GetDepartmentByIdAsync(int departmentId)
        {
            var departments = await this.db
                .Departments
                .Where(d => d.Id == departmentId)
                .ProjectTo<DepartmentsListingServiceModel>()
                .FirstOrDefaultAsync();

            return departments;
        }

        public async Task<IEnumerable<ManagerDepartmentsServiceModel>> GetDepartmentsByManagerIdAsync(string managerId)
        {
            var departments = await this.db
                .Departments
                .OrderByDescending(d => d.Employees.Count())
                .Where(m => m.ManagerId == managerId)
                .ProjectTo<ManagerDepartmentsServiceModel>()
                .ToListAsync();

            return departments;
        }

        public async Task<EmployeeListingFormsServiceView> GetEmployeeFormsByIdAsync(string employeeId)
        {
            var employee = await this.db
                .Users
                .Where(e => e.Id == employeeId)
                .ProjectTo<EmployeeListingFormsServiceView>()
                .FirstOrDefaultAsync();

            return employee;
        }

        public async Task<IEnumerable<EnrolledStaffInDepartmentServiceModel>> GetStaffInDepartmentAsync(int departmentId)
        {
            var staff = await this.db
                .Departments
                .Where(d => d.Id == departmentId)
                .SelectMany(s => s.Employees
                                  .Select(e => e.Employee))
                .ProjectTo<EnrolledStaffInDepartmentServiceModel>()
                .ToListAsync();

            return staff;
        }

        public async Task<bool> IsManagerAsync(int departmentId, string managerId)
        {
            var isManager = await this.db
                .Departments
                .AnyAsync(d => d.Id == departmentId && d.ManagerId == managerId);

            return isManager;
        }

        public async Task UpdateRequestConfirmationByIdAsync(int id, bool isConfirmed)
        {

            var form = await this.db
                .Forms
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();


            form.IsConfirmed = isConfirmed;

            await this.db.SaveChangesAsync();
        }
    }
}
