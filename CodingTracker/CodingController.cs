// Handle all CRUD operations with database here
using System.Globalization;
using Dapper;

namespace CodingTracker;

public class CodingController
{
    // Get the date
    public static DateTime getDate() {
      Console.WriteLine("Please enter the date with the format (dd-mm-yyyy): ");
      string getDate = Console.ReadLine() ?? "";

      string format = "dd-mm-yyyy";

      CultureInfo provider = CultureInfo.InvariantCulture;
      bool checkDate = DateTime.TryParseExact(getDate,
                                              format,
                                              provider,
                                              DateTimeStyles.None,
                                              out DateTime parsedDate);
      return parsedDate;
    }

    // Create a session
    public static void InsertSession()
    {
        Console.WriteLine("Insert a new session here!");
    }

    // Display all times
    public static void DisplayAllSessions()
    {
        Console.WriteLine("Display all sessions");
    }

    // Update a session
    public static void UpdateSession()
    {
        Console.WriteLine("Update a session");
    }

    // Delete a session
    public static void DeleteSession()
    {
        Console.WriteLine("Delete a session");
    }
}
