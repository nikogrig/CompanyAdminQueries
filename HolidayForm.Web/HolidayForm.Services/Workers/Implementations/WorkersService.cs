using AutoMapper.QueryableExtensions;
using HolidayForm.Data;
using HolidayForm.Data.Enums;
using HolidayForm.Data.Models;
using HolidayForm.Services.Workers.Contracts;
using HolidayForm.Services.Workers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Workers.Implementations
{
    public class WorkersService : IWorkersService
    {
        private readonly CompanyDbContext db;

        public WorkersService(CompanyDbContext db)
        {
            this.db = db;
        }

        public async Task CreateFormAsync(string title, string description, DateTime startDate, DateTime endDate, Query query, string employeeId)
        {
            var form = new Form
            {
                Title = title,
                Description = description,
                StartDate = startDate.Date,
                EndDate = endDate.Date,
                Query = query.ToString(),
                EmployeeId = employeeId,
                IsConfirmed = false
            };

            await this.db.Forms.AddAsync(form);

            await this.db.SaveChangesAsync();
        }

        public async Task<EmployeeStatusServiceModel> GetEmployeeStatusByIdAsync(string employeeId)
        {
            var employee = await this.db
                .Users
                .Where(e => e.Id == employeeId)
                .ProjectTo<EmployeeStatusServiceModel>()
                .FirstOrDefaultAsync();

            return employee;
        }
    }
}
