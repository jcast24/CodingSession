namespace CodingTracker;

public class CodingSession
{
    public int Id { get; set; } = 0;
    public DateTime date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public TimeSpan FullTimeDuration { get; set; }

    public TimeSpan CalculateDuration()
    {
        return EndTime - StartTime;
    }

}
