using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.UI;
using EmployeeManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using System.IO;

class Program
{
    static async Task Main()
    {
        var builder = new HostBuilder()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((hostContext, services) =>
            {
                var configuration = hostContext.Configuration;
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                services.AddDbContext<EmployeeContext>(options =>
                    options.UseSqlServer(connectionString));
                services.AddScoped<IEmployeeService, EmployeeService>();
                services.AddScoped<IUserService, UserService>();
            });

        var host = builder.Build();

        using (var serviceScope = host.Services.CreateScope())
        {
            var services = serviceScope.ServiceProvider;

            var employeeService = services.GetRequiredService<IEmployeeService>();
            var userService = services.GetRequiredService<IUserService>();
            var ui = new UserInterface(employeeService, userService);
            await ui.RunAsync();
        }
    }
}