// Handle all CRUD operations with database here
using System.Data.SQLite;
using System.Globalization;
using Dapper;

namespace CodingTracker;

public class Engine
{
    private readonly DatabaseService _dbService;

    public Engine(DatabaseService dbService)
    {
        _dbService = dbService;
    }

    public void CreateTable()
    {
        using (var connection = _dbService.CreateConnection())
        {
            string createTableQuery =
                @"CREATE TABLE IF NOT EXISTS tracker (
                Id INTEGER PRIMARY KEY,
                Date TEXT NOT NULL,
                StartTime TEXT NOT NULL,
                EndTime TEXT NOT NULL, 
                Duration TEXT NOT NULL )";

            using var command = new SQLiteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Tracker table has been created!");
        }
    }

    // Display all times
    public void DisplayAllSessions()
    {
        using (var connection = _dbService.CreateConnection())
        {
            var reader = connection.ExecuteReader("SELECT * FROM tracker");

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string date = reader.GetString(1);
                string startTime = reader.GetString(2);
                string endTime = reader.GetString(3);
                string duration = reader.GetString(4);

                Console.WriteLine($"{id} {date} {startTime} {endTime} {duration}");
            }
        }
    }

    // Create a session
    // Ask user if they would like to enter a start time and endtime or if they would like to use the stopwatch
    public void InsertSession()
    {
        string date = Watch.GetCurrentDate(); 
        // string time = Watch.GetCurrentTime();
        // Console.WriteLine("Insert a new session here!");
        // Console.WriteLine($"{date} {time}");
        //
        Console.WriteLine("Enter your start time: ");
        string? getStartTime = Console.ReadLine();

        Console.WriteLine("Enter your end time: ");
        string? getEndTime = Console.ReadLine();

        // Calculate the duration between start and endtime
        // Convert getStartTime && getEndTime to TimeSpan

        TimeSpan startTime = TimeSpan.Parse(getStartTime, new CultureInfo("en-US"));
        TimeSpan endTime = TimeSpan.Parse(getEndTime, new CultureInfo("en-US"));

        TimeSpan duration = endTime - startTime;

        Console.WriteLine($"Date:{date}\nStart:{getStartTime}\nEnd:{getEndTime}\nDuration:{duration}");
        
    }

    // Update a session
    public void UpdateSession()
    {
        Console.WriteLine("Update a session");
    }

    // Delete a session
    public void DeleteSession()
    {
        Console.WriteLine("Delete a session");
    }
}
