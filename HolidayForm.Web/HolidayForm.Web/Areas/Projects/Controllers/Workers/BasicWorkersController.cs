using HolidayForm.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.Projects.Controllers.Workers
{
    [Area(AdminConstants.WORKERS_AREA)]
    [Authorize(Roles = IdentitiesConstants.REGULAR_ROLE)]
    public abstract class BasicWorkersController : Controller
    {
        
    }
}
