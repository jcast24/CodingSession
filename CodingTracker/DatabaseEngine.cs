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

    // Get the date
    public static DateTime GetDate()
    {
        Console.WriteLine("Please enter the date with the format (dd-mm-yyyy): ");
        string getDate = Console.ReadLine() ?? "";

        string format = "dd-mm-yyyy";

        CultureInfo provider = CultureInfo.InvariantCulture;
        bool checkDate = DateTime.TryParseExact(
            getDate,
            format,
            provider,
            DateTimeStyles.None,
            out DateTime parsedDate
        );
        return parsedDate;
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
            Duration TEXT NOT NULL
            )";

            using var command = new SQLiteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Tracker table has been created!");
        }
    }

    // Create a session
    public void InsertSession()
    {
        Console.WriteLine("Insert a new session here!");
    }

    // Display all times
    public void DisplayAllSessions()
    {
        Console.WriteLine("Display all sessions");
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
