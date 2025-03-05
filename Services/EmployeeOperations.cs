using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeOperations
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeOperations(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task AddEmployeeAsync()
        {
            Console.WriteLine("\n\nYou've chosen to add an employee!\n\n");

            string id = MenuHelper.GetValidStringInput("Enter the employee id: ");
            string name = MenuHelper.GetValidStringInput("Enter the name of employee: ");
            string position = MenuHelper.GetValidStringInput("Enter the position of employee: ");
            decimal salary = MenuHelper.GetValidDecimalInput("Enter the salary of employee: ");
            DateTime dateOfBirth = MenuHelper.GetValidDateInput("Enter the date of birth (yyyy-mm-dd): ");
            string email = MenuHelper.GetValidStringInput("Enter the email of employee: ");
            string phoneNumber = MenuHelper.GetValidStringInput("Enter the phone number of employee: ");
            string department = MenuHelper.GetValidStringInput("Enter the department of employee: ");
            DateTime dateOfJoining = MenuHelper.GetValidDateInput("Enter the date of joining (yyyy-mm-dd): ");

            var employee = new Employee
            {
                Id = id,
                Name = name,
                Position = Enum.Parse<Position>(position),
                Salary = salary,
                DateOfBirth = dateOfBirth,
                Email = email,
                PhoneNumber = phoneNumber,
                Department = department,
                DateOfJoining = dateOfJoining
            };

            await _employeeService.AddEmployeeAsync(employee);
            Console.WriteLine("\nEmployee added successfully!");
        }

        public async Task UpdateEmployeeAsync()
        {
            Console.WriteLine("Enter the employee id to update: ");
            string updateId = Console.ReadLine()!;
            var updateEmployee = await _employeeService.GetEmployeeAsync(updateId);
            if (updateEmployee != null)
            {
                updateEmployee.Name = MenuHelper.GetValidStringInput("Enter the new name of employee: ");
                updateEmployee.Position = Enum.Parse<Position>(MenuHelper.GetValidStringInput("Enter the new position of employee: "));
                updateEmployee.Salary = MenuHelper.GetValidDecimalInput("Enter the new salary of employee: ");
                updateEmployee.DateOfBirth = MenuHelper.GetValidDateInput("Enter the new date of birth (yyyy-mm-dd): ");
                updateEmployee.Email = MenuHelper.GetValidStringInput("Enter the new email of employee: ");
                updateEmployee.PhoneNumber = MenuHelper.GetValidStringInput("Enter the new phone number of employee: ");
                updateEmployee.Department = MenuHelper.GetValidStringInput("Enter the new department of employee: ");
                updateEmployee.DateOfJoining = MenuHelper.GetValidDateInput("Enter the new date of joining (yyyy-mm-dd): ");
                await _employeeService.UpdateEmployeeAsync(updateEmployee);
                Console.WriteLine("\nEmployee updated successfully!");
            }
            else
            {
                Console.WriteLine("\nEmployee not found!");
            }
        }

        public async Task DeleteEmployeeAsync()
        {
            Console.WriteLine("Enter the employee id to delete: ");
            string deleteId = Console.ReadLine()!;
            var employee = await _employeeService.GetEmployeeAsync(deleteId);
            if (employee != null)
            {
                await _employeeService.DeleteEmployeeAsync(deleteId);
                Console.WriteLine("\nEmployee deleted successfully!");
            }
            else
            {
                Console.WriteLine("\nEmployee not found!");
            }
        }

        public async Task SearchEmployeeAsync()
        {
            Console.WriteLine("Enter the employee id to search: ");
            string searchId = Console.ReadLine()!;
            var searchEmployee = await _employeeService.GetEmployeeAsync(searchId);
            if (searchEmployee != null)
            {
                Console.WriteLine($"\nEmployee found: ID: {searchEmployee.Id}, Name: {searchEmployee.Name}, Position: {searchEmployee.Position}, Salary: {searchEmployee.Salary}, Date of Birth: {searchEmployee.DateOfBirth}, Email: {searchEmployee.Email}, Phone Number: {searchEmployee.PhoneNumber}, Department: {searchEmployee.Department}, Date of Joining: {searchEmployee.DateOfJoining}");
            }
            else
            {
                Console.WriteLine("\nEmployee not found!");
            }
        }

        public async Task DisplayAllEmployeesAsync()
        {
            var allEmployees = await _employeeService.GetAllEmployeesAsync();
            if (allEmployees.Any())
            {
                Console.WriteLine("\nList of all employees:");
                foreach (var employee in allEmployees)
                {
                    Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Position: {employee.Position}, Salary: {employee.Salary}, Date of Birth: {employee.DateOfBirth}, Email: {employee.Email}, Phone Number: {employee.PhoneNumber}, Department: {employee.Department}, Date of Joining: {employee.DateOfJoining}");
                }
            }
            else
            {
                Console.WriteLine("\nNo employees found.");
            }
        }
    }
}