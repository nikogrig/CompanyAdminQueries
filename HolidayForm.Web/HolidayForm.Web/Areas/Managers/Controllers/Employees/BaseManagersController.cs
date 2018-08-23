using HolidayForm.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.Managers.Controllers.Employees
{
    [Area(AdminConstants.MANAGERS_AREA)]
    [Authorize(Roles = IdentitiesConstants.МANAGER_ROLE)]
    public abstract class BaseManagersController : Controller
    {
        
    }
}
