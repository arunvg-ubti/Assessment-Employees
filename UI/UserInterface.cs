using System;
using System.Threading.Tasks;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Helpers;
using EmployeeManagementSystem.Services;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.UI
{
    public class UserInterface
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUserService _userService;
        private readonly EmployeeOperations _employeeOperations;

        public UserInterface(IEmployeeService employeeService, IUserService userService)
        {
            _employeeService = employeeService;
            _userService = userService;
            _employeeOperations = new EmployeeOperations(employeeService);
        }

        public async Task RunAsync()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Welcome to the Employee Management System\n\n");
                    Console.WriteLine("1) Admin\n2) User\n3) Exit\n\n");
                    Console.WriteLine("Please select your role: ");

                    string opt = Console.ReadLine()!;
                    int option = int.Parse(opt);

                    if (option < 1 || option > 3)
                    {
                        throw new Exception("\n\nInvalid input! Kindly enter a valid option!");
                    }

                    switch (option)
                    {
                        case 1:
                            await AdminMenuAsync();
                            break;
                        case 2:
                            await UserMenuAsync();
                            break;
                        case 3:
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Program executed successfully");
            }
        }

        private async Task AdminMenuAsync()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:\n\n1) Register\n2) Login\n3) Exit\n\n");
                Console.WriteLine("Please select an option: ");

                string opt = Console.ReadLine()!;
                int option = int.Parse(opt);

                if (option < 1 || option > 3)
                {
                    throw new Exception("\n\nInvalid input! Kindly enter a valid option!");
                }

                switch (option)
                {
                    case 1:
                        await RegisterUserAsync(true);
                        break;
                    case 2:
                        await LoginUserAsync(true);
                        break;
                    case 3:
                        return;
                }
            }
        }

        private async Task UserMenuAsync()
        {
            while (true)
            {
                Console.WriteLine("\nUser Menu:\n\n1) Register\n2) Login\n3) Exit\n\n");
                Console.WriteLine("Please select an option: ");

                string opt = Console.ReadLine()!;
                int option = int.Parse(opt);

                if (option < 1 || option > 3)
                {
                    throw new Exception("\n\nInvalid input! Kindly enter a valid option!");
                }

                switch (option)
                {
                    case 1:
                        await RegisterUserAsync(false);
                        break;
                    case 2:
                        await LoginUserAsync(false);
                        break;
                    case 3:
                        return;
                }
            }
        }

        private async Task RegisterUserAsync(bool isAdmin)
        {
            Console.WriteLine("\n\nYou've chosen to register!\n\n");

            string username = MenuHelper.GetValidStringInput("Enter your username: ");
            string password = MenuHelper.GetValidStringInput("Enter your password: ");

            var user = new User
            {
                Username = username,
                Password = password,
                IsAdmin = isAdmin
            };

            await _userService.RegisterUserAsync(user);
            Console.WriteLine("\nUser registered successfully!");
        }

        private async Task LoginUserAsync(bool isAdmin)
        {
            Console.WriteLine("\n\nYou've chosen to login!\n\n");

            string username = MenuHelper.GetValidStringInput("Enter your username: ");
            string password = MenuHelper.GetValidStringInput("Enter your password: ");

            var user = await _userService.LoginUserAsync(username, password);
            if (user != null && user.IsAdmin == isAdmin)
            {
                Console.WriteLine($"\nWelcome, {user.Username}!");
                if (user.IsAdmin)
                {
                    await AdminOperationsAsync();
                }
                else
                {
                    await UserOperationsAsync();
                }
            }
            else
            {
                Console.WriteLine("\nInvalid username or password!");
            }
        }

        private async Task AdminOperationsAsync()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Operations:\n\n1) Add an employee\n2) Update an employee\n3) Delete an employee\n4) Search an employee\n5) Display all employees\n6) Logout\n\n");
                Console.WriteLine("Please select an option: ");

                string opt = Console.ReadLine()!;
                int option = int.Parse(opt);

                if (option < 1 || option > 6)
                {
                    throw new Exception("\n\nInvalid input! Kindly enter a valid option!");
                }

                switch (option)
                {
                    case 1:
                        await _employeeOperations.AddEmployeeAsync();
                        break;
                    case 2:
                        await _employeeOperations.UpdateEmployeeAsync();
                        break;
                    case 3:
                        await _employeeOperations.DeleteEmployeeAsync();
                        break;
                    case 4:
                        await _employeeOperations.SearchEmployeeAsync();
                        break;
                    case 5:
                        await _employeeOperations.DisplayAllEmployeesAsync();
                        break;
                    case 6:
                        return;
                }
            }
        }

        private async Task UserOperationsAsync()
        {
            while (true)
            {
                Console.WriteLine("\nUser Operations:\n\n1) Search an employee\n2) Display all employees\n3) Logout\n\n");
                Console.WriteLine("Please select an option: ");

                string opt = Console.ReadLine()!;
                int option = int.Parse(opt);

                if (option < 1 || option > 3)
                {
                    throw new Exception("\n\nInvalid input! Kindly enter a valid option!");
                }

                switch (option)
                {
                    case 1:
                        await _employeeOperations.SearchEmployeeAsync();
                        break;
                    case 2:
                        await _employeeOperations.DisplayAllEmployeesAsync();
                        break;
                    case 3:
                        return;
                }
            }
        }
    }
}