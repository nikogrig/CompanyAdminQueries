using HolidayForm.Common.Mapping;
using HolidayForm.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Managers.Models
{
    public class ConfirmQueryFormServiceModel : IMapFrom<Form>
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public string Query { get; set; }

        public string EmployeeId { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
