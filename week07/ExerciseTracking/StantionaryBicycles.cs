public class StationaryBicycles : Activity
{
    private double _speedKph;

    public StationaryBicycles(DateTime date, int durationMinutes, double speedKph)
        : base(date, durationMinutes)
    {
        _speedKph = speedKph;
    }

    public override double GetDistance()
    {
        return (_speedKph / 60) * DurationMinutes;
    }

    public override double GetSpeedKph()
    {
        return _speedKph;
    }

    public override double GetPacePerKm()
    {
        double distance = GetDistance();
        return distance > 0 ? DurationMinutes / distance : 0;
    }
}
