using HolidayForm.Constants;
using HolidayForm.Data.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.HumanResources.Models.HR
{
    public class EditEmployeeFormModel
    {
        public string EmployeeId { get; set; }

        public string UserName { get; set; }

        [Required]
        [MinLength(DataConstants.NAME_MIN_LENGTH)]
        [MaxLength(DataConstants.NAME_MAX_LENGTH)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The First Name should contain only letters.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataConstants.NAME_MIN_LENGTH)]
        [MaxLength(DataConstants.NAME_MAX_LENGTH)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The Last Name should contain only letters.")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Address { get; set; }
   
        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [Required]
        public double Salary { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public bool Gender { get; set; }
    }
}
