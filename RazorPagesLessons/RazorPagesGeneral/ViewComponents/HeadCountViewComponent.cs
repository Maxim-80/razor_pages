using Microsoft.AspNetCore.Mvc;
using RazorPagesLessons.Models;
using RazorPagesLessons.Services;

namespace RazorPagesGeneral.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IViewComponentResult Invoke(Dept? dept = null)
        {
            var result = _employeeRepository.EmployeeCountByDept(dept);

            return View(result);
        }
    }
}
