// Handle all CRUD operations with database here
using System.Data.SQLite;
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
        TableVisualizer.MakeTable();
    }

    // Create a session
    // Ask user if they would like to enter a start time and endtime or if they would like to use the stopwatch
    public void InsertSession()
    {
        TimeSpan startTime = ValidateInput.CheckStartTime();

        TimeSpan endTime = ValidateInput.CheckEndTime();

        TimeSpan duration = ValidateInput.Duration(startTime, endTime);

        string getDate = Watch.GetCurrentDate();

        using (var connection = _dbService.CreateConnection())
        {
            string insertQuery =
                "INSERT INTO tracker (Date, StartTime, EndTime, Duration) VALUES (@date, @StartTime, @EndTime, @FullTimeDuration)";
            var rowsAffected = connection.Execute(
                insertQuery,
                new CodingSession
                {
                    date = getDate,
                    StartTime = startTime,
                    EndTime = endTime,
                    FullTimeDuration = duration,
                }
            );
            Console.WriteLine($"{rowsAffected} has been successfully added!");
        }
    }

    // Update a session
    public void UpdateSession()
    {
        // Ask for ID
        // update date, and time
        // create update query
        // output success

        Console.WriteLine("Enter id of session you would like to change: ");
        string? getId = Console.ReadLine();

        using (var connection = _dbService.CreateConnection())
        {
            // get date
            string getDate = Watch.GetDateInput();
            TimeSpan start = ValidateInput.CheckStartTime();
            TimeSpan end = ValidateInput.CheckEndTime();
            TimeSpan duration = ValidateInput.Duration(start, end);

            string updateQuery =
                "UPDATE tracker SET Date = @Date, StartTime = @StartTime, EndTime = @EndTime, Duration = @Duration WHERE Id=@Id;";

            connection.Execute(
                updateQuery,
                new
                {
                    Id = getId,
                    Date = getDate,
                    StartTime = start,
                    EndTime = end,
                    Duration = duration,
                }
            );
            Console.WriteLine("Item has been updated");
        }
    }

    // Delete a session
    public void DeleteSession()
    {
        Console.WriteLine("Enter id of the session you would like to delete: ");
        string? getId = Console.ReadLine();

        using (var connection = _dbService.CreateConnection())
        {
            string deleteQuery = "DELETE FROM tracker WHERE Id=@Id";
            connection.Execute(deleteQuery, new {Id = getId} );
            Console.WriteLine("Item has been deleted.");
            DisplayAllSessions();
        }
    }
}
