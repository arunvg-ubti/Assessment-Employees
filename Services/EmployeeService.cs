//Services Creation
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public int GetValidIntInput(string prompt) //method to check and return valid int input
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine()!;
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("\n\nThe employee id cannot be null!");
                    continue;
                }
            }
        }

        public string GetValidStringInput(string prompt) //method to check and return valid string input
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

        public decimal GetValidDecimalInput(string prompt) //method to check and return valid decimal input
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

        public void AddEmployee() //Method to add employee(s) - without parameter
        {
            Console.WriteLine("\n\nYou've chosen to add an employee!\n\n");

            int id = GetValidIntInput("Enter the employee id: ");
            string name = GetValidStringInput("Enter the name of employee: ");
            string position = GetValidStringInput("Enter the position of employee: ");
            decimal salary = GetValidDecimalInput("Enter the salary of employee: ");

            _employees.Add(new Employee { Id = id, Name = name, Position = position, Salary = salary });
            Console.WriteLine("\nEmployee added successfully!");
        }

        public void AddEmployee(Employee employee) //Method to add employee(s) - with parameter
        {
            _employees.Add(employee);
            Console.WriteLine("\nEmployee added successfully!");
        }

        public Employee GetEmployee(int id) //Method to search employee(s)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployees() //Method to display all employees
        {
            return _employees;
        }

        public void UpdateEmployee(Employee employee) //Method to update existing employee(s)
        {
            var existingEmployee = GetEmployee(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Position = employee.Position;
                existingEmployee.Salary = employee.Salary;
                Console.WriteLine("\nEmployee updated successfully!");
            }
            else
            {
                Console.WriteLine("\nEmployee not found!");
            }
        }

        public void DeleteEmployee(int id) //Method to delete employee(s)
        {
            var employee = GetEmployee(id);
            if (employee != null)
            {
                _employees.Remove(employee);
                Console.WriteLine("\nEmployee deleted successfully!");
            }
            else
            {
                Console.WriteLine("\nEmployee not found!");
            }
        }
    }
}