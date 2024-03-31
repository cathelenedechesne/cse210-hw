using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
        // No need for additional initialization in constructor
    }

    public override bool IsEternal { get; } = true; // Override IsEternal for EternalGoals

    public override void RecordEvent()
    {
        // No specific action needed as it's eternal
    }

    public override bool IsComplete()
    {
        // Eternal goals are never complete
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"{_shortName}, {_description}, {_points}";
    }
}
