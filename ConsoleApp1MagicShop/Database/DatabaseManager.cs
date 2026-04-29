using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

using MySqlConnector;

namespace MagicShop.Database
{
    public class DatabaseManager
    {
        private readonly string? _connString;
        private readonly string _dbSelection = "Aiven";

        public DatabaseManager()
        {
            _connString = GetConnectionStringJson("appsettingsdev.json");
        }

        private string? GetConnectionStringJson(string jsonFile)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(jsonFile)
                .Build();

            return config.GetConnectionString(_dbSelection);
        }

        public MySqlConnection GetConnection()
        {
            // Console.WriteLine(_connString);
            return new MySqlConnection(_connString);
        }
    }
}