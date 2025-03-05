namespace EmployeeManagementSystem.Helpers
{
    public static class MenuHelper
    {
        public static string GetValidStringInput(string prompt)
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

        public static decimal GetValidDecimalInput(string prompt)
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

        public static DateTime GetValidDateInput(string prompt)
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
}