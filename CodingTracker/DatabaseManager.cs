using Microsoft.Data.Sqlite;

namespace CodingTracker;

internal class DatabaseManager
{
    internal void CreateTable(string connectionString)
    {
        // Establish connection with db 
        using var connection = new SqliteConnection(connectionString);

        // open the connection
        connection.Open();

        // tell connection to create command 
        var tableCmd = connection.CreateCommand();

        // create the table if it doesn't exist
        tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS coding (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT, Duration TEXT)";

        tableCmd.ExecuteNonQuery();

        Console.WriteLine("Success");

        connection.Close();
    }
}