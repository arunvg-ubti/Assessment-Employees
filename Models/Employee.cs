//Model creation
namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public string Id {get;set;}
        public string Name {get;set;}
        public Position Position {get;set;}
        public decimal Salary {get;set;}
        public DateTime DateOfBirth { get; set; } // New field
        public string Email { get; set; } // New field
        public string PhoneNumber { get; set; } // New field
        public string Department { get; set; } // New field
        public DateTime DateOfJoining { get; set; } // New field
    }
    public enum Position
    {
        Manager,
        Developer,
        Sales_Executive,
        HR_Specialist,
        Marketing_Manager
    }
}