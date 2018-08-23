using HolidayForm.Data.Models;
using HolidayForm.Services.HR.Contracts;
using HolidayForm.Web.Areas.HumanResources.Models.Employees;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayForm.Common.TempDataMessages;

namespace HolidayForm.Web.Areas.HumanResources.Controllers
{
    public class EmployeesController : BasicHRController
    {
        private readonly IHrService hrService;
        private readonly IHrEmployeeService hrEmpService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public EmployeesController(IHrService hrService, IHrEmployeeService hrEmpService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.hrService = hrService;
            this.hrEmpService = hrEmpService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Requests()
        {
            var forms = await this.hrEmpService.GetRequestFromEmployees();

            var model = new RequestListingViewModel
            {
                Forms = forms
            };

            return View(model);
        }

        public async Task<IActionResult> Status(string formId, string employeeId)
        {
            var employee = await this.hrEmpService.GetEmployeeByIdAsync(employeeId);

            var model = new EmployeeChangeStatusViewModel
            {
                UserName = employee.UserName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                HireDate = employee.HireDate,
                Status = employee.Status,
                JobTitle = employee.JobTitle
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Status(int formId, string employeeId, EmployeeChangeStatusViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var employee = await this.hrEmpService.GetEmployeeByIdAsync(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            await this.hrEmpService.UpdateWorkStatusForEmployee(employee.Id, model.Status, formId);

            TempData.AddSuccessMessage($"The Request for Username {model.UserName} successully updated");

            return RedirectToAction(
                nameof(EmployeesController.Status),
                new { employeeId });
        }
    }
}
