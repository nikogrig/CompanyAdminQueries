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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(u => u.Id);

            entity.HasOne(u => u.JobTitle)
                .WithMany(j => j.Employees)
                .HasForeignKey(u => u.JobTitleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.Property(e => e.Salary).HasColumnType("money");
        }
    }
}