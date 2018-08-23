using HolidayForm.Constants;
using HolidayForm.Data.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.Admin.Models.Users
{
    public class EditUserProfileViewModel
    {
        public string Id { get; set; }

        [MinLength(DataConstants.USERNAME_MIN_LENGTH)]
        [MaxLength(DataConstants.USERNAME_MAX_LENGTH)]
        public string Username { get; set; }

        [Required]
        [MinLength(DataConstants.NAME_MIN_LENGTH)]
        [MaxLength(DataConstants.NAME_MAX_LENGTH)]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The First Name should contain only letters.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataConstants.NAME_MIN_LENGTH)]
        [MaxLength(DataConstants.NAME_MAX_LENGTH)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The Last Name should contain only letters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public double Salary { get; set; }

        public Status Status { get; set; }

        public bool Gender { get; set; }

        public IEnumerable<SelectListItem> Managers { get; set; }
    }
}
