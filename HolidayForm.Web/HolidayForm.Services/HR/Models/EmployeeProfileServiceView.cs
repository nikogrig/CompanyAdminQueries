using AutoMapper;
using HolidayForm.Common.Mapping;
using HolidayForm.Data.Enums;
using HolidayForm.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.HR.Models
{
    public class EmployeeProfileServiceView : IMapFrom<User>, ICustomMapperProfile
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        public string Address { get; set; }

        public DateTime HireDate { get; set; }

        public double Salary { get; set; }

        public Status Status { get; set; }

        public bool Gender { get; set; }

        public string Department { get; set; }

        public string  JobTitle { get; set; }

        public string Manager { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<User, EmployeeProfileServiceView>()
                .ForMember(a => a.JobTitle, cfq => cfq.MapFrom(a => a.JobTitle.Title))
                .ForMember(a => a.Manager, cfq => cfq.MapFrom(a => a.Departments.Select(c => c.Department.Manager.UserName).FirstOrDefault()))
                .ForMember(a => a.Department, cfq => cfq.MapFrom(a => a.Departments.Select(c => c.Department.Title).FirstOrDefault()));


        }
    }
}
