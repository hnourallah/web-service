using System;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace mysqlapp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get connection string
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Connect to database and retrieve data
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM `utilisateur`";
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming you have columns named 'id' and 'name' in your table
                            Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["nom"]}");
                        }
                    }
                }
            }
        }
    }
}
