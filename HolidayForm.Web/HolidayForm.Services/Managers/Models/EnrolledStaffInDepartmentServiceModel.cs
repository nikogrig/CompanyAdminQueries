using AutoMapper;
using HolidayForm.Common.Mapping;
using HolidayForm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Managers.Models
{
    public class EnrolledStaffInDepartmentServiceModel : IMapFrom<User>, ICustomMapperProfile
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Forms { get; set; }

        public string Status { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<User, EnrolledStaffInDepartmentServiceModel>()
                .ForMember(s => s.Forms, cfg => cfg.MapFrom(u => u.Forms
                                                                  .Select(d => d.Query)))
               .ForMember(s => s.Status, cfg => cfg.MapFrom(u => u.Status));
        }
    }
}
