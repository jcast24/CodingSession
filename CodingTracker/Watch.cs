using System.Data.SQLite;
using System.Globalization;
using Dapper;
using Spectre.Console;

namespace CodingTracker;

public class Watch
{
    public static void StopwatchMenu()
    {
        string option = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Stopwatch")
                .AddChoices(
                    new[]
                    {
                        "1. Start Timer",
                        "2. End Timer",
                        "3. Reset Timer",
                        "4. Exit",
                        "5. Go back to main menu",
                    }
                )
        );

        switch (option)
        {
            case "1. Start Timer":
                Start();
                break;
            case "2. End Timer":
                if (option == "2. End Timer")
                {
                    Console.WriteLine("Make sure to start the timer!");
                }
                // Return back to this menu
                StopwatchMenu();
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

    public static void Start()
    {
        // DateTime startTime = DateTime.Now;
        // Console.WriteLine($"Stopwatch has started at {startTime}");
        // Stop();
        var stopwatch = new System.Diagnostics.Stopwatch();

        TimeSpan endTime;

        stopwatch.Start();
        AnsiConsole
            .Live(new Panel("[cyan]Stopwatch running...[/]"))
            .Start(ctx =>
            {
                while (true)
                {
                    ctx.UpdateTarget(
                        new Panel($"[cyan]Elapsed Time: {stopwatch.Elapsed:hh\\:mm\\:ss\\.ff}[/]")
                    );

                    if (Console.KeyAvailable)
                    {
                        stopwatch.Stop();
                        break;
                    }
                }
            });
        AnsiConsole.MarkupLine("[green]Stopwatch stopped![/]");
        AnsiConsole.MarkupLine(
            $"Final Time: [yellow]{endTime = stopwatch.Elapsed:hh\\:mm\\:ss\\.ff}[/]"
        );

        InsertFromWatchIntoTable(endTime);
    }

    // Ask the user if they would like to insert from stopwatch into sql table
    public static void InsertFromWatchIntoTable(TimeSpan end)
    {
        TimeSpan start = TimeSpan.Zero;
        TimeSpan duration = ValidateInput.Duration(start, end);
        string getDate = GetCurrentDate();
        using (var connection = new SQLiteConnection("Data source=tracker.db"))
        {
            string insertQuery =
                "INSERT INTO tracker (Date, StartTime, EndTime, Duration) VALUES(@date, @StartTime, @EndTime, @FullTimeDuration)";
            var insertItems = connection.Execute(
                insertQuery,
                new CodingSession
                {
                    date = getDate,
                    StartTime = start,
                    EndTime = end,
                    FullTimeDuration = duration,
                }
            );

            Console.WriteLine($"Items have been successfully added!");
        }
    }
}
