using HolidayForm.Data.Models;
using HolidayForm.Services.Managers.Contracts;
using HolidayForm.Web.Areas.HumanResources.Models.HR;
using HolidayForm.Web.Areas.Managers.Models.Employees;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayForm.Common.TempDataMessages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HolidayForm.Web.Areas.Managers.Controllers.Employees
{
    public class EmployeesController : BaseManagersController
    {
        private readonly IManagerService managerService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public EmployeesController(IManagerService managerService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.managerService = managerService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        
        public async Task<IActionResult> Tasks()
        {
            var userId = this.userManager.GetUserId(User);

            if (userId == null)
            {
                return NotFound();
            }

            var model = new ManagerDepartmentsListingViewModel
            {
                Departments = await this.managerService.GetDepartmentsByManagerIdAsync(userId)
            };

            return View(model);
        }

        public async Task<IActionResult> Staff(int departmentId)
        {
            var managerId = this.userManager.GetUserId(User);

            if (managerId == null)
            {
                return NotFound();
            }

            var isManager = await this.managerService.IsManagerAsync(departmentId, managerId);

            if (!isManager)
            {
                return BadRequest();
            }

            var staff = await this.managerService.GetStaffInDepartmentAsync(departmentId);

            var departments = await this.managerService.GetDepartmentByIdAsync(departmentId);

            var model = new EnrolledEmployeesIndDepartmentViewModel
            {
                Employees = staff,
                Departments = departments
            };

            return View(model);
        }

        public async Task<IActionResult> Queries(string employeeId)
        {
            var employee = await this.managerService.GetEmployeeFormsByIdAsync(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            var model = new EmployeeQueriesViewModel
            {
                Employee = employee
            };

            return View(model);
        }

        public async Task<IActionResult> Edit(int formId)
        {
            var query = await this.managerService.GetQueryFormByIdAsync(formId);

            var model = new FormViewModel
            {
                Id = query.Id,
                Title = query.Title,
                Description = query.Description,
                StartDate = query.StartDate,
                EndDate = query.EndDate,
                Query = query.Query,
                EmployeeId = query.EmployeeId,
                IsConfirmed = query.IsConfirmed
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int formId, FormViewModel model)
        {
            var query = await this.managerService.GetQueryFormByIdAsync(formId);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await this.managerService.UpdateRequestConfirmationByIdAsync(query.Id, model.IsConfirmed);

            TempData.AddSuccessMessage($"Query with ID:{query.Id} successfully updated.");

            return RedirectToAction(nameof(Queries), new { query.EmployeeId });
        }
    }
}
