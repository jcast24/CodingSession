using System.Configuration;
using Spectre.Console;

namespace CodingTracker;

public class Menu()
{
    private static readonly string connectionString =
        ConfigurationManager.AppSettings.Get("ConnectionString") ?? "";

    public static void ShowMenu()
    {
        DatabaseService db = new DatabaseService(connectionString);
        Engine engine = new Engine(db);

        engine.CreateTable();

        bool keepRunning = true;

        while (keepRunning)
        {
            string option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Welcome to Coding Tracker")
                    .AddChoices(
                        new[]
                        {
                            "0. Close the Application",
                            "1. Show all Sessions",
                            "2. Start a new session",
                            "3. Modify a Session",
                            "4. Delete a session",
                            "5. Start Timer",
                            "6. End Timer",
                        }
                    )
            );

            switch (option)
            {
                case "0. Close the Application":
                    keepRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;
                case "1. Show all Sessions":
                    // Show all sessions
                    engine.DisplayAllSessions();
                    break;
                case "2. Start a new session":
                    // Start a new session
                    engine.InsertSession();
                    break;
                case "3. Modify a Session":
                    // Modify a session
                    // Allows the user to enter a new time, new date
                    engine.UpdateSession();
                    break;
                case "4. Delete a session":
                    engine.DeleteSession();
                    break;
                case "5. Start Timer":
                    // Start timer
                    // If the timer has already started, then shoot message "Timer has been running"
                    Console.WriteLine("Timer is running");
                    Watch.Start();
                    break;
                case "6. End Timer":
                    // End timer
                    // If the time isn't running, shoot message "Timer never started"
                    Console.WriteLine("Timer has ended");
                    break;
                default:
                    Console.WriteLine("Please choose an option!");
                    break;
            }
        }
        // SpectreConsole Test
    }
}
