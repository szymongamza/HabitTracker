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
        public void DeleteRecord(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = $"DELETE FROM coffees WHERE Id = {id}";
                    int rowAffected = command.ExecuteNonQuery();
                    if (rowAffected == 0)
                    {
                        Console.WriteLine($"There was no record with Id: {id}");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Id: {id} has been deleted.");
                    }
                }
            }
        }
        public List<HabitModel> GetRecords()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = $"SELECT * FROM coffees ORDER BY DateOfDay";
                    List<HabitModel> tableData = new();
                    SqliteDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tableData.Add(
                                new HabitModel
                                {
                                    Id = reader.GetInt32(0),
                                    Date = DateOnly.FromDateTime(DateTime.Parse(reader.GetString(1))),
                                    Quantity = reader.GetInt32(2)

                                }); ;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    return tableData;
                }
            }

        }
        public void UpdateRecord(int id, string date, int quantity)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = $"UPDATE coffees SET DateOfDay = \"{date}\", Quantity = {quantity} WHERE Id = {id}";
                    try
                    {
                        int rowAffected = command.ExecuteNonQuery();
                        if (rowAffected == 0)
                        {
                            Console.WriteLine($"There was no record with Id: {id}");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Id: {id} has been updated.");
                        }
                    }
                    catch (SqliteException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }

}
