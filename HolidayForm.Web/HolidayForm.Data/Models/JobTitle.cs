﻿using HolidayForm.Constants;
using HolidayForm.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Data.Models
{
    public class JobTitle
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.DESCRIPTION_MIN_LENGTH)]
        [MaxLength(DataConstants.DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }

        public ICollection<User> Employees { get; set; } = new HashSet<User>();
    }
}
