using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _context;

        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee); // Adding employee to the DbSet
            await _context.SaveChangesAsync(); // Saving changes to the database
        }

        public async Task<Employee> GetEmployeeAsync(string id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id); // Querying the database using LINQ
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync(); // Retrieving all employees using LINQ
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee); // Updating employee in the DbSet
            await _context.SaveChangesAsync(); // Saving changes to the database
        }

        public async Task DeleteEmployeeAsync(string id)
        {
            var employee = await GetEmployeeAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee); // Removing employee from the DbSet
                await _context.SaveChangesAsync(); // Saving changes to the database
            }
        }

        public string GetValidStringInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Input cannot be null or empty! Please enter a valid string.");
                }
            }
        }

        public decimal GetValidDecimalInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine()!;
                if (decimal.TryParse(input, out decimal result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                }
            }
        }

        public DateTime GetValidDateInput(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine()!;
                if (DateTime.TryParse(input, out DateTime result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid date (yyyy-mm-dd).");
                }
            }
        }
    }

    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
            {
            }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
    }
}