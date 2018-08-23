using HolidayForm.Constants;
using HolidayForm.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Web.Areas.HumanResources.Models.HR
{
    public class JobTitleFormModel
    {
        public int Id { get; set; }

        [Required]
        public JobTitleEnums Title { get; set; }

        [Required]
        [MinLength(DataConstants.DESCRIPTION_MIN_LENGTH)]
        [MaxLength(DataConstants.DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }
    }
}
