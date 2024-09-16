namespace CodingTracker;

public class CodingSession
{
    public int Id { get; set; } = 0;
    public string? date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public TimeSpan FullTimeDuration { get; set; }
}
