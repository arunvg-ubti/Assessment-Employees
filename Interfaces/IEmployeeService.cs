//Interface creation
using EmployeeManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IEmployeeService
    {
        Task AddEmployeeAsync(Employee employee);
        Task<Employee> GetEmployeeAsync(string id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(string id);
        string GetValidStringInput(string prompt);
        decimal GetValidDecimalInput(string prompt);
        DateTime GetValidDateInput(string prompt);
    }
}