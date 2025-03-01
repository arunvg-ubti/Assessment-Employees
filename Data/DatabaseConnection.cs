using System;
using Microsoft.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagementSystem.Data
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection()
        {
            var configuration= new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Config/appsettings.json").Build();

            _connectionString=configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}