using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    public string ShortName
    {
        get { return _shortName; }
    }

    public string Description { get; set; }

    public string Points
    {
        get { return _points; }
    }

    public virtual bool IsEternal { get; } = false; // Default to false for all goals

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        Description = description; // Set the public property
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"{_shortName}: ({Description})";
    }

    public abstract string GetStringRepresentation();
}
