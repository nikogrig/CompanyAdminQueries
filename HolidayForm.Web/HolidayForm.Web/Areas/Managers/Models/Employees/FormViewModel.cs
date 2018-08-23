using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.Managers.Models.Employees
{
    public class FormViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string Query { get; set; }

        public string EmployeeId { get; set; }

        [Display(Name = "Will you confirm the request")]
        public bool IsConfirmed { get; set; }

    }
}
