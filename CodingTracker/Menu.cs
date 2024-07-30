using Spectre.Console;

namespace CodingTracker;

public class Menu()
{
    public static void ShowMenu()
    {

        // SpectreConsole Test
        string option = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Welcome to Coding Tracker")
        .AddChoices(new[] {
            "0. Close the Application", "1. Show all Sessions", "2. Start a new session", "3. Modify a Session", "4. Start", "5. End",
            })
        );

        switch (option)
        {
            case "0. Close The Application":
                break;
            case "1. Show all Sessions":
                // Show all sessions
                break;
            case "2. Start a new session":
                // Start a new session
                break;
            case "3. Modify a session":
                // Modify a session
                // Allows the user to enter a new time
                break;

        }

    }
}