using HolidayForm.Constants;
using HolidayForm.Data.Enums;
using HolidayForm.Services.Admin.Models;
using HolidayForm.Services.HR.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HolidayForm.Constants.PaginationConstants;

namespace HolidayForm.Web.Areas.HumanResources.Models.HR
{
    public class DepartmentsListingViewModel
    {
        public IEnumerable<DepartmentListingServiceModel> Departments { get; set; }

        public int TotalDepartments { get; set; }

        public int TotalPages
            => (int)Math.Ceiling((double)this.TotalDepartments / PAGE_SIZE);

        public int CurrentPage { get; set; }

        public int PreviousPage
            => this.CurrentPage <= 1
                                 ? 1
                                 : this.CurrentPage - 1;

        public int NextPage
            => this.CurrentPage == this.TotalPages
                                 ? this.TotalPages
                                 : this.CurrentPage + 1;
    }
}
