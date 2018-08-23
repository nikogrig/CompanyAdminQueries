using HolidayForm.Data.Enums;
using HolidayForm.Services.HR.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.HumanResources.Models.HR
{
    public class EditDepartmentFormModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Manager { get; set; }

        [Required]
        [Display(Name = "Choose Manager")]
        public string ManagerId { get; set; }

        public IEnumerable<SelectListItem> Managers { get; set; }

        public IEnumerable<EmployeeInDepartmentListingServiceModel> Staff { get; set; }
    }
}
