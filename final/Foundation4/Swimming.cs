public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50) / 1000.0; // Distance in kilometers
    }

    public override double GetSpeed()
    {
        if (_length <= 0)
        {
            return 0;
        }
        else
        {
            return ((_laps * 50 / 1000.0) / (_length / 60.0)) * 60.0; // Speed in kilometers per hour
        }
    }

    public override double GetPace()
    {
        if (_laps <= 0)
        {
            return 0;
        }
        else
        {
            return (_length / ((_laps * 50) / 1000.0)); // Pace in minutes per kilometer
        }
    }

    public override string GetSummary()
    {
        return $"{_date:dd MMM yyyy} Swimming ({_length} min) - Distance {GetDistance()} km, Speed {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}
