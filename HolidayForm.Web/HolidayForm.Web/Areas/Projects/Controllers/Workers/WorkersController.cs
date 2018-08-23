using HolidayForm.Data.Models;
using HolidayForm.Services.Workers.Contracts;
using HolidayForm.Web.Areas.Projects.Models.Workers;
using HolidayForm.Web.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayForm.Common.TempDataMessages;
using HolidayForm.Services.Files.Contracts;

namespace HolidayForm.Web.Areas.Projects.Controllers.Workers
{
    public class WorkersController : BasicWorkersController
    {
        private readonly IWorkersService workersService;
        private readonly IFileService fileService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public WorkersController(IWorkersService workersService, IFileService fileService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.workersService = workersService;
            this.fileService = fileService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Panel()
        {
            var employeeId = this.userManager.GetUserId(User);

            var user = await this.workersService.GetEmployeeStatusByIdAsync(employeeId);

            var model = new StatusPanelViewModel
            {               
                Employee = user,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(1)
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Panel(StatusPanelViewModel model)
        {        
            var employeeId = this.userManager.GetUserId(User);

            var user = await this.workersService.GetEmployeeStatusByIdAsync(employeeId);

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                TempData.AddSuccessMessage($"The '{model.Title} Form' for {model.Query} successfully created.");

                await this.workersService.CreateFormAsync(model.Title, model.Description, model.StartDate, model.EndDate, model.Query, employeeId);
            }


            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }

        public async Task<IActionResult> DownloadCertificate(int formId)
        {
            var userId = this.userManager.GetUserId(User);

            var certificateContents = await this.fileService.GetPdfFileAsync(userId, formId);

            if (certificateContents == null)
            {
                return BadRequest();
            }

            return File(certificateContents, "application/pdf", "File.pdf");
        }
    }
}
