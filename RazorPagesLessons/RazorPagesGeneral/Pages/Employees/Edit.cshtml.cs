using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Models;
using RazorPagesLessons.Services;

namespace RazorPagesGeneral.Pages.Employees
{
    public class EditModel : PageModel
    {
        public Employee Employee { get; private set; }

        [BindProperty]
        public bool Notify { get; set; }
        public string Message { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
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

        public IActionResult OnPost(Employee employee)
        {
            if (Photo != null)
            {
                if (employee.PhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", employee.PhotoPath);

                    System.IO.File.Delete(filePath);
                }

                employee.PhotoPath = ProcessUpdateFile();
            }

            Employee = _employeeRepository.Update(employee);

            TempData["SuccessMessage"] = $"Update {Employee.Name} successful!";

            return RedirectToPage("Employees");
        }

        public void OnPostUpdateNotificationPreference(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turn notifications";
            }
            else
            {
                Message = "You have turned off email notifications";
            }

            Employee = _employeeRepository.GetEmployee(id);
        }

        private string ProcessUpdateFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }

            return uniqueFileName;
        }
    }
}