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
    public class EmployeeQueryFormServiceModel : IMapFrom<Form>, ICustomMapperProfile
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string Query { get; set; }

        public string EmployeeId { get; set; }

        public bool IsConfirmed { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Form, EmployeeQueryFormServiceModel>()
                .ForMember(s => s.EmployeeId, cfg => cfg.MapFrom(u => u.EmployeeId));
        }
    }
}
