using AutoMapper;
using HolidayForm.Common.Mapping;
using HolidayForm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.HR.Models
{
    public class DepartmentListingServiceModel : IMapFrom<Department>, ICustomMapperProfile
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Manager { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Department, DepartmentListingServiceModel>()
                .ForMember(a => a.Manager, cfq => cfq.MapFrom(a => $"{a.Manager.FirstName} {a.Manager.LastName}"));
        }
    }
}
