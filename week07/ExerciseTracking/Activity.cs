public abstract class Activity
{
    private DateTime _date;
    private int _durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public DateTime Date => _date;
    public int DurationMinutes => _durationMinutes;

    public abstract double GetDistance();
    public abstract double GetSpeedKph();
    public abstract double GetPacePerKm();

    public virtual string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeedKph();
        double pace = GetPacePerKm();

        string formattedDate = Date.ToString("dd MMM yyyy");
        return $"{formattedDate} {GetType().Name} ({DurationMinutes} min): Distance {distance:F1} km, Speed: {speed:F1} km/h, Pace: {pace:F2} min/km";
    }
}
