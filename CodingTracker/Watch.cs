using System.Globalization;
using Spectre.Console;

namespace CodingTracker;

public class Watch
{
    public static void StopwatchMenu()
    {
        string option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Stopwatch")
                .AddChoices(new[] { "1. Start Timer", "2. End Timer", "3. Reset Timer", "4. Exit", "5. Go back to main menu" })
        );

        switch(option) {
            case "1. Start Timer":
                break;
            case "2. End Timer":
                break;
            case "3. Reset Timer":
                break;
            case "4. Exit":
                break;
            case "5. Go back to main menu":
                break;
            default: 
                Console.WriteLine("Please choose a correct option!");
                break;
        }
    }

    // Get the date from user
    public static string GetDateInput()
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

        string formattedDate = parsedDate.ToString("dd-mm-yyyy");
        return formattedDate;
    }

    // Get the current Date
    public static string GetCurrentDate()
    {
        // DateTime today = DateTime.Now;
        // return today.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));
        DateTime currentDate = DateTime.Now;
        string formattedDate = string.Format("{0:dd-MM-yyyy}", currentDate);
        return formattedDate;
    }

    // Get the current time
    public static string GetCurrentTime()
    {
        DateTime time = DateTime.Now;
        return time.ToString("hh:mm");
    }

    public static DateTime Start()
    {
        // Console.WriteLine("Press any key to start...");
        // Console.ReadKey();
        DateTime startTime = DateTime.Now;
        Console.WriteLine("Press any key to stop: ");
        Console.ReadKey();
        Console.WriteLine(startTime);
        return startTime;
    }

    public static DateTime Stop()
    {
        Console.WriteLine("Press any key to stop...");
        Console.ReadKey();
        DateTime stopTime = DateTime.Now;
        return stopTime;
    }
}
