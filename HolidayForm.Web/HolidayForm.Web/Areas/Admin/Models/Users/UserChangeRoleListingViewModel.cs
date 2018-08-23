using HolidayForm.Services.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.Admin.Models.Users
{
    public class UserChangeRoleListingViewModel
    {
        public AdminUserListingServiceModel User { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
