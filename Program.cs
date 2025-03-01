using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using System;

namespace EmployeeManagementSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            var dbConnection = new DatabaseConnection();
            IEmployeeService employeeService = new EmployeeService();

            var newEmployee= new Employee{Id=1,Name="John Doe",Position="Developer",Salary=60000};
            employeeService.AddEmployee(newEmployee);

            var employee=employeeService.GetEmployee(1);
            Console.WriteLine($"Employee: {employee.Name}, Position: {employee.Position}, Salary: {employee.Salary}");

            employee.Name="John Smith";
            employeeService.UpdateEmployee(employee);
            var updatedEmployee=employeeService.GetEmployee(1);
            Console.WriteLine($"Updated Employee: {updatedEmployee.Name}, Position: {updatedEmployee.Position}, Salary: {updatedEmployee.Salary}");

            employeeService.DeleteEmployee(1);
            var deletedEmployee=employeeService.GetEmployee(1);
            Console.WriteLine(deletedEmployee==null?"Employee deleted successfully":"Employee deletion failed");            
        }
    }
}