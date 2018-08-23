using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HolidayForm.Data.Models;
using HolidayForm.Data.Configation;

namespace HolidayForm.Data
{
    public class CompanyDbContext : IdentityDbContext<User>
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<JobTitle> JobTitles { get; set; }

        public DbSet<UserDepartment> UserDepartments { get; set; }

        public DbSet<Form> Forms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DepartmentConfig());

            builder.ApplyConfiguration(new JobTitleConfig());

            builder.ApplyConfiguration(new UserConfig());

            builder.ApplyConfiguration(new UserDepartmentConfig());

            builder.ApplyConfiguration(new FormConfig());

            base.OnModelCreating(builder);
        }
    }
}
