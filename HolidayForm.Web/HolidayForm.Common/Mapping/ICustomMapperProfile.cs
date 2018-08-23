using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Common.Mapping
{
    public interface ICustomMapperProfile
    {
        void ConfigureMapping(Profile mapper);

    }
}
