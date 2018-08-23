using HolidayForm.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Data.Configation
{
    public class UserDepartmentConfig : IEntityTypeConfiguration<UserDepartment>
    {
        public void Configure(EntityTypeBuilder<UserDepartment> entity)
        {
            entity.HasKey(ed => new { ed.EmployeeId, ed.DepartmentId });

            entity.HasOne(ed => ed.Employee)
                .WithMany(s => s.Departments)
                .HasForeignKey(ed => ed.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(ed => ed.Department)
                .WithMany(c => c.Employees)
                .HasForeignKey(ed => ed.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}