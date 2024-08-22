using Microsoft.Data.Sqlite;

namespace CodingTracker;

internal class DatabaseManager
{
    public static void CreateTable(string connectionString)
    {
        try
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            // tell connection to create command
            var tableCmd = connection.CreateCommand();

            // create the table if it doesn't exist
            tableCmd.CommandText =
                @"CREATE TABLE IF NOT EXISTS coding (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT NOT NULL, Duration TEXT NOT NULL)";

            tableCmd.ExecuteNonQuery();

            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
