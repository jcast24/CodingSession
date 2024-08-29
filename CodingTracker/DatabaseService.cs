using System.Data.SQLite;

namespace CodingTracker;

internal class DatabaseService
{
    private readonly string _connectionString;

    // DB constructor
    public DatabaseService(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Returns a connection
    public SQLiteConnection CreateConnection()
    {
        var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        return connection;
    }
}
