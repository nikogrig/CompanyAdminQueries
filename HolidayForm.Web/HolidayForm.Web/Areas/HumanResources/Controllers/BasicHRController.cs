using HolidayForm.Constants;
using HolidayForm.Services.HR.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.HumanResources.Controllers
{
    [Area(AdminConstants.HR_AREA)]
    [Authorize(Roles = IdentitiesConstants.HR_ROLE)]
    public abstract class BasicHRController : Controller
    {

    }
}
