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
    public class Form
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

        public User Employee { get; set; }

        public bool IsConfirmed { get; set; }

        public bool IsUpdated { get; set; }

        [MaxLength(DataConstants.FILE_LENGTH)]
        public byte[] File { get; set; }
    }
}
