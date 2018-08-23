using AutoMapper;
using HolidayForm.Common.Mapping;
using HolidayForm.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Managers.Models
{
    public class EmployeeListingFormsServiceView : IMapFrom<User>, ICustomMapperProfile
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public string JobTitle { get; set; }

        public string Status { get; set; }

        public ICollection<Form> Forms { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<User, EmployeeListingFormsServiceView>()
                .ForMember(s => s.Status, cfg => cfg.MapFrom(u => u.Status))
                .ForMember(s => s.JobTitle, cfg => cfg.MapFrom(u => u.JobTitle.Title));
        }
    }
}
