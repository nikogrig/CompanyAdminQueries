using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HolidayForm.Constants;
using HolidayForm.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace HolidayForm.Data.Models
{
    public class User : IdentityUser
    {
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

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public double Salary { get; set; }

        public Status Status { get; set; }

        [Required]
        public bool Gender { get; set; }

        public int? JobTitleId { get; set; }

        public JobTitle JobTitle { get; set; }
        
        public ICollection<Department> Staff { get; set; } = new HashSet<Department>();

        public ICollection<UserDepartment> Departments { get; set; } = new HashSet<UserDepartment>();

        public ICollection<Form> Forms { get; set; } = new HashSet<Form>();

    }
}
