using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly List<Employee> _employees= new List<Employee>();
        public void AddEmployee(Employee employee)
        {
            if(employee==null)
            {
                throw new ArgumentNullException(nameof(employee),"Employee cannot be null");
            }
            if(string.IsNullOrWhiteSpace(employee.Name) || string.IsNullOrWhiteSpace(employee.Position))
            {
                throw new ArgumentException("Employee name and position cannot be empty");
            }
            try
            {
                _employees.Add(employee);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(e=> e.Id==id);
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }
        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee=GetEmployee(employee.Id);
            if(existingEmployee!=null)
            {
                existingEmployee.Name=employee.Name;
                existingEmployee.Position=employee.Position;
                existingEmployee.Salary=employee.Salary;
            }
        }
        public void DeleteEmployee(int id)
        {
            var employee=GetEmployee(id);
            if(employee!=null)
            {
                _employees.Remove(employee);
            }
        }
    }
}