using Microsoft.EntityFrameworkCore;
using RazorPagesLessons.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLessons.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
