using HolidayForm.Constants;
using HolidayForm.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Data.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.DESCRIPTION_MIN_LENGTH)]
        [MaxLength(DataConstants.DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }

        public string ManagerId { get; set; }

        public User Manager { get; set; }

        public ICollection<UserDepartment> Employees { get; set; } = new HashSet<UserDepartment>();
    }
}
