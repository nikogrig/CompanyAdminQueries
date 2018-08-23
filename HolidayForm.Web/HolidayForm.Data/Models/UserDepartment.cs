using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Data.Models
{
    public class UserDepartment
    {
        public string EmployeeId { get; set; }

        public User Employee { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
