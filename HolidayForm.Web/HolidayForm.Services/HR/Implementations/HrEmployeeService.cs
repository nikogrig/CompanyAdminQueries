using AutoMapper.QueryableExtensions;
using HolidayForm.Data;
using HolidayForm.Data.Enums;
using HolidayForm.Data.Models;
using HolidayForm.Services.HR.Contracts;
using HolidayForm.Services.HR.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.HR.Implementations
{
    public class HrEmployeeService : IHrEmployeeService
    {
        private readonly CompanyDbContext db;

        public HrEmployeeService(CompanyDbContext db)
        {
            this.db = db;
        }

        public async Task<EmployeeDetailsServiceModel> GetEmployeeByIdAsync(string employeeId)
        {
            var employee = await this.db
                .Users
                .Where(e => e.Id == employeeId)
                .ProjectTo<EmployeeDetailsServiceModel>()
                .FirstOrDefaultAsync();

            return employee;
        }

        public async Task<IEnumerable<EmployeeJobsServiceModel>> GetAllJobTitleAsync()
        {
            var jobs = await this.db
                .JobTitles
                .OrderBy(j => j.Title)
                .ProjectTo<EmployeeJobsServiceModel>()
                .ToListAsync();

            return jobs;
        }

        public async Task<bool> EmployeeIsEnrolledInDepartmentAsync(string employeeId, int departmentId)
        {
            var isEnrolled = await this.db
                .Departments
                .AnyAsync(c => c.Employees.Any(s => s.EmployeeId == employeeId) && c.Id == departmentId);

            return isEnrolled;
        }

        public async Task<bool> UpdateEmployeePersonalInfoAsync(string employeeId, double salary, DateTime hireDate, Status status)
        {
            var employee = await this.db
                .Users
                .Where(e => e.Id == employeeId)
                .FirstOrDefaultAsync();


            employee.Salary = salary;
            employee.HireDate = hireDate;
            employee.Status = status;

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<EmployeeInDepartmentListingServiceModel>> GetEmployeesInDepartmentAsync(int id)
        {
            var employeesIdDepartment = await this.db
                .Departments
                .Where(d => d.Id == id)
                .SelectMany(e => e.Employees
                                  .Select(emp => emp.Employee))
                .ProjectTo<EmployeeInDepartmentListingServiceModel>()
                .ToListAsync();

            return employeesIdDepartment;
        }

        public async Task<IEnumerable<RequestFromEmployeesListingServiceModel>> GetRequestFromEmployees()
        {
            var forms = await this.db
                .Forms
                .OrderByDescending(f => f.Id)
                .Where(f => f.IsConfirmed == true)
                .ProjectTo<RequestFromEmployeesListingServiceModel>()
                .ToListAsync();

            return forms;
        }

        public async Task UpdateWorkStatusForEmployee(string id, Status status, int formId)
        {
            var employee = await this.db
                .Users
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            employee.Status = status;

            var form = await this.db
                .Forms
                .Where(f => f.Id == formId)
                .FirstOrDefaultAsync();

            form.IsUpdated = true;

            await this.db.SaveChangesAsync();
        }

        public async Task<bool> UpdateEmployeeDepartmentJobTitleAsync(string employeeId, int departmentId, int jobTitleId)
        {
            var departmentInfo = await this.GetDepartmentInfoAsync(employeeId, departmentId);

            var employee = await this.db
                .Users
                .Where(e => e.Id == employeeId)
                .FirstOrDefaultAsync();

            employee.JobTitleId = jobTitleId;

            if (departmentInfo == null || departmentInfo.EmployeeEnrolledInDepartment)
            {
                return false;
            }

            var employeeInDepartment = new UserDepartment
            {
                EmployeeId = employeeId,
                DepartmentId = departmentId
            };

            await this.db.AddAsync(employeeInDepartment);

            await this.db.SaveChangesAsync();

            return true;
        }

        private async Task<EmployeeWithDepartmentServiceModel> GetDepartmentInfoAsync(string employeeId, int departmentId)
        {
            var courseInfo = await this.db
                  .Departments
                  .Where(c => c.Id == departmentId)
                  .Select(c => new EmployeeWithDepartmentServiceModel
                  {
                      EmployeeEnrolledInDepartment = c.Employees.Any(s => s.EmployeeId == employeeId)
                  })
                  .FirstOrDefaultAsync();

            return courseInfo;
        }
    }
}
