using HolidayForm.Constants;
using HolidayForm.Data;
using HolidayForm.Data.Enums;
using HolidayForm.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HolidayForm.Infrastructure.Identity
{
    public static class IdentitiesBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigrationWithIdentities(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider
                    .GetService<CompanyDbContext>();

                context.Database.Migrate();

                var userManager = serviceScope
                     .ServiceProvider
                     .GetService<UserManager<User>>();

                var roleManager = serviceScope
                    .ServiceProvider
                    .GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var adminRoleName = IdentitiesConstants.ADMINISTRATOR_ROLE;

                        var roles = new[]
                        {
                            adminRoleName,
                            IdentitiesConstants.МANAGER_ROLE,
                            IdentitiesConstants.REGULAR_ROLE,
                            IdentitiesConstants.HR_ROLE
                        };

                        foreach (var role in roles)
                        {
                            bool roleExists = await roleManager.RoleExistsAsync(role);

                            if (!roleExists)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = role
                                });
                            }
                        }

                        var adminEmail = "admin@myweb.com";

                        var adminUser = await userManager.FindByEmailAsync(adminEmail);

                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                UserName = adminRoleName,
                                Email = adminEmail,
                                HireDate = DateTime.UtcNow,
                                Salary = 1000.00,
                                FirstName = "Nikola",
                                LastName = "Grigorov",
                                Address = "Sofia",
                                PhoneNumber = "+0888123456",
                                Status = Status.Active,
                                Gender = true,
                                JobTitle = new JobTitle()
                                {
                                    Title = JobTitleEnums.Administrator.ToString(),
                                    Description = "Makes everthing for your calmness."
                                }                                                         

                            };

                           
                            await userManager.CreateAsync(adminUser, "admin123");

                            await userManager.AddToRoleAsync(adminUser, adminRoleName);
                        }
                    })
                .Wait();
            }

            return app;
        }
    }
}
