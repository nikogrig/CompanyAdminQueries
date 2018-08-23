using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HolidayForm.Data;
using HolidayForm.Web.Models;
using HolidayForm.Data.Models;
using HolidayForm.Services.MailSender.Contracts;
using HolidayForm.Services.MailSender.Implementations;
using HolidayForm.Infrastructure.ServiceExtension;
using HolidayForm.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;
using HolidayForm.Infrastructure.DbExtension;
using AutoMapper;

namespace HolidayForm.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CompanyDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<CompanyDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.

            // Add AutoMapper
            services.AddAutoMapper();

            // Custom Service extension
            services.AddDomainServices();

            // Configure Urls - lower case
            services.AddRouting(routing => routing.LowercaseUrls = true);

            // Configure global Antiforgery
            services.AddMvc(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // custom extensions method for Db migrations and Identity roles
            //app.UseDatabaseMigration();
            app.UseDatabaseMigrationWithIdentities();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
