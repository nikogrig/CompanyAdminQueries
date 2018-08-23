using AutoMapper;
using HolidayForm.Common.Mapping;
using HolidayForm.Data.Enums;
using HolidayForm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Workers.Models
{
    public class EmployeeStatusServiceModel : IMapFrom<User>, ICustomMapperProfile
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string JobTitle { get; set; }

        public Status Status { get; set; }

        public ICollection<Form> Forms { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
              .CreateMap<User, EmployeeStatusServiceModel>()
              .ForMember(s => s.FullName, cfg => cfg.MapFrom(u => $"{u.FirstName} {u.LastName}"))
              .ForMember(s => s.JobTitle, cfg => cfg.MapFrom(u => u.JobTitle.Title));
        }
    }
}
