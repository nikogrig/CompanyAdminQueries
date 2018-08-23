using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Services.Files.Contracts
{
    public interface IFileService
    {
        Task<byte[]> GetPdfFileAsync(string employeeId, int formId);
    }
}
