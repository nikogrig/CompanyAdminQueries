using HolidayForm.Common.Mapping;
using HolidayForm.Data.Enums;
using HolidayForm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Admin.Models
{
    public class UserCreatingServiceModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Address { get; set; }

        public DateTime HireDate { get; set; }

        public double Salary { get; set; }

        public Status Status { get; set; }

        public bool Gender { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int JobTitleId { get; set; }

        public JobTitle JobTitle { get; set; }
    }
}
