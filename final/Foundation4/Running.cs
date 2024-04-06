public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int length, double distance) : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return _distance / _length * 60; // Speed in miles per hour
    }

    public override double GetPace()
    {
        return _length / _distance; // Pace in minutes per mile
    }

    public override string GetSummary()
    {
        return $"{_date:dd MMM yyyy} Running ({_length} min) - Distance {_distance} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}
