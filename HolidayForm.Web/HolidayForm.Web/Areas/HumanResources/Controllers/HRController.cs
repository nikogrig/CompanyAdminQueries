using HolidayForm.Constants;
using HolidayForm.Data.Models;
using HolidayForm.Services.Admin.Contracts;
using HolidayForm.Services.HR.Contracts;
using HolidayForm.Web.Areas.HumanResources.Models.HR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayForm.Common.TempDataMessages;
using Microsoft.EntityFrameworkCore;

namespace HolidayForm.Web.Areas.HumanResources.Controllers
{
    public class HRController : BasicHRController
    {
        private readonly IHrService hrService;
        private readonly IHrEmployeeService hrEmpService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public HRController(IHrService hrService, IHrEmployeeService hrEmpService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.hrService = hrService;
            this.hrEmpService = hrEmpService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Employees(int page = 1)
        {
            var model = new EmployeeListingViewModel
            {
                Employees = await this.hrService.GetAllEmployeeAsync(page),
                TotalEmployees = await this.hrService.GetTotalEmployeeCountAsync(),
                CurrentPage = page,
            };

            return View(model);
        }

        public async Task<IActionResult> Departments(int page = 1)
        {
            var model = new DepartmentsListingViewModel()
            {
                Departments = await this.hrService.GetAllDepartmentsAsync(page),
                TotalDepartments = await this.hrService.GetTotalDepartmentCountAsync(),
                CurrentPage = page
            };

            return View(model);
        }

        public async Task<IActionResult> EditDepartments(int id)
        {
            var managers = await this.GetManagersAsync();

            var department = await this.hrService.GetDepartmentById(id);

            var employees = await this.hrEmpService.GetEmployeesInDepartmentAsync(id);

            var currentManagerDepartment = department.Manager;

            var model = new EditDepartmentFormModel
            {
                Id = department.Id,
                Title = department.Title,
                Manager = currentManagerDepartment,
                Description = department.Description,
                Managers = managers,
                Staff = employees
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditDepartments(EditDepartmentFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.hrService.AddManagerDepartmentAsync(model.Id, model.Description, model.ManagerId);

            TempData.AddSuccessMessage($"The '{model.Title} Department' was updated successfully!");

            return RedirectToAction(
                nameof(HRController.Departments),
                "HR",
                new { area = $"{AdminConstants.HR_AREA}", page = 1 });
        }

        public async Task<IActionResult> AddDepartment(string employeeId)
        {
            var employee = await this.hrEmpService.GetEmployeeByIdAsync(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            var departments = await this.GetAllDepartmentsAsync();

            var jobTitles = await this.GetJobTitlesAsync();

            var model = new AddDepartmentAndJobForEmployeeViewModel
            {
                EmployeeId = employee.Id,
                UserName = employee.UserName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Departments = departments,
                JobTitles = jobTitles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(AddDepartmentAndJobForEmployeeViewModel model)
        {
            var employee = await this.hrEmpService.GetEmployeeByIdAsync(model.EmployeeId);

            var successedEnrolled = await this.hrEmpService.UpdateEmployeeDepartmentJobTitleAsync(model.EmployeeId, model.DepartmentId, model.JobTitleId);

            if (!successedEnrolled)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage($"Employeee {model.UserName} successully added to department and Job");

            return RedirectToAction(
                nameof(HRController.Employees),
                "HR",
                new { area = $"{AdminConstants.HR_AREA}", page = 1 });
        }


        public async Task<IActionResult> Details(string employeeId)
        {
            var employee = await this.hrEmpService.GetEmployeeByIdAsync(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            var departments = await this.GetAllDepartmentsAsync();

            var jobTitles = await this.GetJobTitlesAsync();

            var model = new EditEmployeeFormModel
            {
                EmployeeId = employee.Id,
                UserName = employee.UserName,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Birthdate = employee.Birthdate,
                Address = employee.Address,
                HireDate = employee.HireDate,
                Salary = employee.Salary,
                Status = employee.Status,
                Gender = employee.Gender,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Details(EditEmployeeFormModel model)
        {
            var employee = await this.hrEmpService.GetEmployeeByIdAsync(model.EmployeeId);

            var successedEnrolled = await this.hrEmpService.UpdateEmployeePersonalInfoAsync(model.EmployeeId, model.Salary, model.HireDate, model.Status);

            if (!successedEnrolled)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage($"Employeee {model.UserName} successully Updated");

            return RedirectToAction(
                nameof(HRController.Employees),
                "HR",
                new { area = $"{AdminConstants.HR_AREA}", page = 1 });
        }

        public IActionResult CreateJobTitle() => View();

        [HttpPost]
        public async Task<IActionResult> CreateJobTitle(JobTitleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.hrService.CreateJobTitleAsync(model.Title, model.Description);

            TempData.AddSuccessMessage($"The '{model.Title} Job Title' successfully created.");

            return RedirectToAction(
                nameof(HRController.Employees),
                "HR",
                new { area = $"{AdminConstants.HR_AREA}", page = 1 });
        }

        private async Task<IEnumerable<SelectListItem>> GetManagersAsync()
        {
            var managers = await this.userManager
                .GetUsersInRoleAsync(IdentitiesConstants.МANAGER_ROLE);

            var managersListItem = managers
                .Select(t => new SelectListItem
                {
                    Text = t.UserName,
                    Value = t.Id
                })
                .ToList();

            return managersListItem;
        }

        private async Task<IEnumerable<SelectListItem>> GetAllDepartmentsAsync()
        {
            var departments = await this.hrService
                .GetAllDepartmentsAsync();

            var departmentsSelectList = departments
                .Select(t => new SelectListItem
                {
                    Text = t.Title,
                    Value = t.Id.ToString()
                })
                .ToList();

            return departmentsSelectList;
        }

        private async Task<IEnumerable<SelectListItem>> GetJobTitlesAsync()
        {
            var jobTitles = await this.hrEmpService.GetAllJobTitleAsync();

            var jobTitlesSelectList = jobTitles
                .Select(t => new SelectListItem
                {
                    Text = t.Title,
                    Value = t.Id.ToString()
                })
                .ToList();

            return jobTitlesSelectList;
        }
    }
}
