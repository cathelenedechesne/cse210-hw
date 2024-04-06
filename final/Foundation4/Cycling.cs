public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int length, double speed) : base(date, length)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * _length / 60; // Distance in miles
    }

    public override double GetSpeed()
    {
        return _speed; // Speed in miles per hour
    }

    public override double GetPace()
    {
        return 60 / _speed; // Pace in minutes per mile
    }

    public override string GetSummary()
    {
        return $"{_date:dd MMM yyyy} Cycling ({_length} min) - Distance {GetDistance()} miles, Speed {_speed} mph, Pace: {GetPace()} min per mile";
    }
}
