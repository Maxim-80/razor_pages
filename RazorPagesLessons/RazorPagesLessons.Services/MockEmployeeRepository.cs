﻿using RazorPagesLessons.Models;
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

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(x => x.Id) + 1;

            _employeeList.Add(newEmployee);

            return newEmployee;
        }

        public Employee Delete(int id)
        {
            var employee = _employeeList.FirstOrDefault(x => x.Id == id);

            if (employee != null)
            {
                _employeeList.Remove(employee);
            }

            return employee;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept)
        {
            IEnumerable<Employee> query = _employeeList;

            if (dept.HasValue)
            {
                query = query.Where(x => x.Department == dept.Value);
            }

            return query.GroupBy(x => x.Department)
                .Select(x => new DeptHeadCount
                {
                    Department = x.Key.Value,
                    Count = x.Count()
                }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return _employeeList;
            }

            return _employeeList.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) || x.Email.ToLower().Contains(searchTerm.ToLower()));
        }

        public Employee Update(Employee updatedEmployee)
        {
            var employee = _employeeList.FirstOrDefault(x => x.Id == updatedEmployee.Id); 

            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Department = updatedEmployee.Department;
                employee.Email = updatedEmployee.Email;
                employee.PhotoPath = updatedEmployee.PhotoPath;
            }

            return employee;
        }
    }
}
