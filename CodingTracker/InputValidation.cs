using System.Globalization;

namespace CodingTracker;

class ValidateInput()
{
    public static TimeSpan CheckStartTime()
    {
        Console.WriteLine("Enter start time: ");
        string? getStartTime = Console.ReadLine();

        TimeSpan startTime;

        if (getStartTime != null)
        {
            startTime = TimeSpan.Parse(getStartTime, new CultureInfo("en-US"));
        }
        else
        {
            startTime = TimeSpan.Zero;
        }
        return startTime;
    }

    public static TimeSpan CheckEndTime()
    {
        Console.WriteLine("Enter end time: ");
        string? getEndTime = Console.ReadLine();

        TimeSpan endTime;

        if (getEndTime != null)
        {
            endTime = TimeSpan.Parse(getEndTime, new CultureInfo("en-US"));
        }
        else
        {
            endTime = TimeSpan.Zero;
        }
        return endTime;
    }

    public static TimeSpan Duration(TimeSpan start, TimeSpan end) {
        return end - start;
    }
}
