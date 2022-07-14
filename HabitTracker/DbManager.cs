using Microsoft.Data.Sqlite;
using System;

namespace HabitTracker
{
    public class DbManager
    {
        readonly String _connectionString;
        public DbManager(string s)
        {
            _connectionString = s;
        }

        public void CreateTable()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = 
                    @"CREATE TABLE IF NOT EXISTS coffees (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    DateOfDay DATE,
                    Quantity INTEGER
                    )";
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqliteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
        }

        public void InsertRecord(string date, int quantity)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = $"INSERT INTO coffees(DateOfDay, Quantity) VALUES(\"{date}\",{quantity})";
                    Console.WriteLine($"DEBUG: {date}");
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch(SqliteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        public void DeleteRecord()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "";
                    command.ExecuteNonQuery();
                }
            }
        }
        public void GetRecords()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "";
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateRecord()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = "";
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
