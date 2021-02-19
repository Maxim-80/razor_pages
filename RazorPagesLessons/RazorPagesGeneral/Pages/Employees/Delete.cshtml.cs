using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Models;
using RazorPagesLessons.Services;

namespace RazorPagesGeneral.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public Employee Employee { get; set; }

        public DeleteModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var deletedEmployee = _employeeRepository.Delete(Employee.Id);

            if (deletedEmployee.PhotoPath != null)
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", deletedEmployee.PhotoPath);

                if (deletedEmployee.PhotoPath != "noimage.png")
                {
                    System.IO.File.Delete(filePath);
                }
            }

            if (deletedEmployee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("Employees");
        }
    }
}