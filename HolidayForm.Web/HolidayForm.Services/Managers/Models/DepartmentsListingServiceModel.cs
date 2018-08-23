using HolidayForm.Common.Mapping;
using HolidayForm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Managers.Models
{
    public class DepartmentsListingServiceModel : IMapFrom<Department>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
