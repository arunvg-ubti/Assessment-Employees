using EmployeeManagementSystem.Models;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(User user);
        Task<User> LoginUserAsync(string username, string password);
    }
}