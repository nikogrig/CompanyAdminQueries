using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.HumanResources.Models.HR
{
    public class AddDepartmentAndJobForEmployeeViewModel
    {
        public string EmployeeId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [Display(Name = "Choose Department")]
        public int DepartmentId { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }

        [Required]
        [Display(Name = "Choose Job Title")]
        public int JobTitleId { get; set; }

        public IEnumerable<SelectListItem> JobTitles { get; set; }
    }
}
