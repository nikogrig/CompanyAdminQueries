using HolidayForm.Data;
using HolidayForm.Data.Models;
using HolidayForm.Services.Files.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayForm.Constants;
using Microsoft.EntityFrameworkCore;

namespace HolidayForm.Services.Files.Implementations
{
    public class FileService : IFileService
    {
        private readonly CompanyDbContext db;
        private readonly IPdfGeneratorService pdfService;

        public FileService(CompanyDbContext db, IPdfGeneratorService pdfService)
        {
            this.db = db;
            this.pdfService = pdfService;
        }

        public async Task<byte[]> GetPdfFileAsync(string employeeId, int formId)
        {
            var form = await this.db
                .FindAsync<Form>(formId);

            if (form == null)
            {
                return null;
            }

            var employee = await this.db
                .FindAsync<User>(employeeId);

            if (employee == null)
            {
                return null;
            }

            var fileData = await this.db
                .Forms
                .Where(c => c.Id == formId)
                .Select(c => new
                {
                    FormTitle = c.Title,
                    FormDescription = c.Description,
                    CourseStartDate = c.StartDate,
                    CourseEndDate = c.EndDate,
                    EmployeeFullName = $"{c.Employee.FirstName} {c.Employee.LastName}",
                    EmployeeQueryType = c.Query,
                    Department = c.Employee.Departments
                                        .Where(d => d.EmployeeId == employeeId)
                                        .Select(d => d.Department.Title)
                                        .FirstOrDefault()
                })
                .FirstOrDefaultAsync();
                

            var generator = this.pdfService.GeneratePdfFromHtml(string.Format(
                                                                       PdfFormatConstants.PDF_CERTIFICATE_FORMAT,
                                                                       fileData.FormTitle,
                                                                       fileData.FormDescription,
                                                                       fileData.CourseStartDate.ToShortDateString(),
                                                                       fileData.CourseEndDate.ToShortDateString(),
                                                                       fileData.EmployeeFullName,
                                                                       fileData.EmployeeQueryType,
                                                                       fileData.Department,
                                                                       DateTime.UtcNow.ToShortDateString()));

            return generator;
        }
    }
}
