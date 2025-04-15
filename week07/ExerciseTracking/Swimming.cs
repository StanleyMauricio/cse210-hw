public class Swimming : Activity
{
    private int _laps;
    private const double LapDistanceMeters = 50;

    public Swimming(DateTime date, int durationMinutes, int laps)
        : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public int Laps => _laps;

    public override double GetDistance()
    {
        return (_laps * LapDistanceMeters) / 1000.0;
    }

    public override double GetSpeedKph()
    {
        double distanceKm = GetDistance();
        return DurationMinutes > 0 ? (distanceKm / DurationMinutes) * 60 : 0;
    }

    public override double GetPacePerKm()
    {
        double distanceKm = GetDistance();
        return distanceKm > 0 ? DurationMinutes / distanceKm : 0;
    }

    public override string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeedKph();

        string formattedDate = Date.ToString("dd MMM yyyy");
        return $"{formattedDate} Swimming ({DurationMinutes} min, {Laps} laps): Distance {distance:F1} km, Speed: {speed:F1} km/h";
    }
}
