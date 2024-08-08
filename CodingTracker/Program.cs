using System.Configuration;

namespace CodingTracker;

internal static class Program
{
    private static readonly string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString") ?? "";
    public static void Main(string[] args)
    {
        DatabaseManager databaseManager = new();

        databaseManager.CreateTable(connectionString);

        Menu.ShowMenu();

    }
}