﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Models;
using RazorPagesLessons.Services;

namespace RazorPagesGeneral.Pages.Employees
{
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeRepository _db;

        public IEnumerable<Employee> Employees { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public EmployeesModel(IEmployeeRepository db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Employees = _db.Search(SearchTerm);
        }
    }
}