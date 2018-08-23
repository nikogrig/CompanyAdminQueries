using AutoMapper;
using HolidayForm.Common.Mapping;
using HolidayForm.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.HR.Models
{
    public class RequestFromEmployeesListingServiceModel : IMapFrom<Form>, ICustomMapperProfile
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

        public string Employee { get; set; }

        public bool IsConfirmed { get; set; }

        public bool IsUpdated { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Form, RequestFromEmployeesListingServiceModel>()
                    .ForMember(a => a.Employee, cfq => cfq.MapFrom(a => a.Employee.UserName));
                    //.ForMember(a => a.Department, cfq => cfq.MapFrom(a => a.Employee.Departments.Where(e => e.EmployeeId == EmployeeId).Select(d => d.Department).FirstOrDefault()));
        }
    }
}
