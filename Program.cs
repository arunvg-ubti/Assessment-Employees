using System;
using EmployeeManagementSystem.Services;
using EmployeeManagementSystem.Models;


class Program
{
    static void Main() //main method/fn
    {
        EmployeeService employeeService = new EmployeeService(); //Creating instance or object of Service class

        try //try block
        {
            while (true) //while loop
            {
                // Prompting the user for an option input to perform database operations
                Console.WriteLine("Hello Carol, this console application is designed to manage an employee database\n\n");
                Console.WriteLine("There are a variety of things that you can do:\n\n1) Add an employee\n2) Update an employee\n3) Delete an employee\n4) Search an employee\n5) Display all employees\n6) Exit\n\n");
                Console.WriteLine("What would you like to do? Kindly enter an option between 1 to 6: ");

                string opt = Console.ReadLine()!; // storing the value in a string type variable
                int option = int.Parse(opt); // converting string datatype to int for easy processing

                if (option < 1 || option > 6) // checking negative value condition
                {
                    throw new Exception("\n\nInvalid input! Kindly enter a valid option!"); // throwing an exception
                }

                switch (option)
                {
                    case 1:
                        employeeService.AddEmployee(); // Calling method to add employee
                        break;
                    case 2:
                        Console.WriteLine("Enter the employee id to update: ");
                        int updateId = int.Parse(Console.ReadLine()!);
                        var updateEmployee = employeeService.GetEmployee(updateId); //Calling method to update employee
                        if (updateEmployee != null)
                        {
                            updateEmployee.Name = employeeService.GetValidStringInput("Enter the new name of employee: ");
                            updateEmployee.Position = employeeService.GetValidStringInput("Enter the new position of employee: ");
                            updateEmployee.Salary = employeeService.GetValidDecimalInput("Enter the new salary of employee: ");
                            employeeService.UpdateEmployee(updateEmployee);
                        }
                        else
                        {
                            Console.WriteLine("\nEmployee not found!");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter the employee id to delete: ");
                        int deleteId = int.Parse(Console.ReadLine()!);
                        employeeService.DeleteEmployee(deleteId); //Calling method to delete employee
                        break;
                    case 4:
                        Console.WriteLine("Enter the employee id to search: ");
                        int searchId = int.Parse(Console.ReadLine()!);
                        var searchEmployee = employeeService.GetEmployee(searchId); //Calling method to search employee
                        if (searchEmployee != null)
                        {
                            Console.WriteLine($"\nEmployee found: ID: {searchEmployee.Id}, Name: {searchEmployee.Name}, Position: {searchEmployee.Position}, Salary: {searchEmployee.Salary}");
                        }
                        else
                        {
                            Console.WriteLine("\nEmployee not found!");
                        }
                        break;
                    case 5:
                        var allEmployees = employeeService.GetAllEmployees(); //Calling method to display employee
                        if (allEmployees.Any())
                        {
                            Console.WriteLine("\nList of all employees:");
                            foreach (var employee in allEmployees)
                            {
                                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Position: {employee.Position}, Salary: {employee.Salary}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo employees found.");
                        }
                        break;
                    case 6: //exit the loop
                        return;
                }
            }
        }
        catch (Exception ex) //catch block
        {
            Console.WriteLine(ex.Message); //exception handling
        }
        finally{
            Console.WriteLine("Program executed successfully"); //finally block
        }
    }
}