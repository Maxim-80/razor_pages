using RazorPagesLessons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorPagesLessons.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>
            {
                new Employee
                {
                    Id = 0,
                    Name = "Mary",
                    Email = "mary@expl.com",
                    PhotoPath = "avatar2.png",
                    Department = Dept.HR
                },
                new Employee
                {
                    Id = 1,
                    Name = "Tom",
                    Email = "tom@expl.com",
                    PhotoPath = "avatar.png",
                    Department = Dept.IT
                },
                new Employee
                {
                    Id = 2,
                    Name = "Bob",
                    Email = "bob@expl.com",
                    Department = Dept.Payroll
                }
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }
    }
}
