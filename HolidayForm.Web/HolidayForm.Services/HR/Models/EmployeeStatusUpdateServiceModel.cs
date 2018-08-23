using AutoMapper;
using HolidayForm.Common.Mapping;
using HolidayForm.Data.Enums;
using HolidayForm.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.HR.Models
{
    public class EmployeeStatusUpdateServiceModel : IMapFrom<User>, ICustomMapperProfile
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public Status Status { get; set; }

        public string JobTitle { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<User, EmployeeStatusUpdateServiceModel>()
                .ForMember(a => a.JobTitle, cfq => cfq.MapFrom(a => a.JobTitle.Title));
        }
    }
}
