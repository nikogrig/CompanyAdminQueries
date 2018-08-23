using HolidayForm.Common.Mapping;
using HolidayForm.Data.Enums;
using HolidayForm.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Workers.Models
{
    public class FormServiceModel : IMapFrom<Form>
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public Query Query { get; set; }

        public string Status { get; set; }
    }
}
