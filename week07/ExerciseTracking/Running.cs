public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int durationMinutes, double distanceKm)
        : base(date, durationMinutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return _distanceKm;
    }

    public override double GetSpeedKph()
    {
        return (_distanceKm / DurationMinutes) * 60;
    }

    public override double GetPacePerKm()
    {
        return DurationMinutes / _distanceKm;
    }
}
