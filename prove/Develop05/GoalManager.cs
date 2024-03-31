using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public List<Goal> Goals => _goals;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        // Implement menu loop and other functionality here
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.ShortName);
        }
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateSimpleGoal(string name, string description, string points)
    {
        _goals.Add(new SimpleGoal(name, description, points));
    }

    public void CreateChecklistGoal(string name, string description, string points, int target, int bonus)
    {
        _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
    }

    public void CreateEternalGoal(string name, string description, string points)
    {
        _goals.Add(new EternalGoal(name, description, points));
    }

    public void RecordEvent(string goalName, ref int pointsEarned)
    {
        foreach (var goal in _goals)
        {
            if (goal.ShortName == goalName)
            {
                goal.RecordEvent();
                int points = int.Parse(goal.Points);
                _score += points;
                pointsEarned += points; // Update pointsEarned reference variable
                Console.WriteLine($"Event recorded for goal: {goalName}. You gained {points} points.");
                return;
            }
        }
        Console.WriteLine($"Goal '{goalName}' not found.");
    }



    public void SaveGoals(string filename, int totalPoints)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                // Write total points first
                writer.WriteLine(totalPoints);

                // Write each goal's details
                foreach (var goal in _goals)
                {
                    // Write specific goal type
                    string typeName = goal.GetType().Name;

                    if (goal is ChecklistGoal checklistGoal)
                    {
                        writer.Write($"{typeName},{goal.ShortName},{goal.Description},{goal.Points},{goal.IsComplete()},{checklistGoal.AmountCompleted},{checklistGoal.Target},{checklistGoal.Bonus}");
                    }
                    else if (goal is EternalGoal)
                    {
                        writer.Write($"{typeName},{goal.ShortName},{goal.Description},{goal.Points},{goal.IsComplete()}");
                    }
                    else
                    {
                        writer.Write($"{typeName},{goal.ShortName},{goal.Description},{goal.Points},{goal.IsComplete()}");
                    }

                    // End the line
                    writer.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals(string filename)
    {
        try
        {
            _goals.Clear(); // Clear existing goals before loading

            using (StreamReader reader = new StreamReader(filename))
            {
                int totalPoints = int.Parse(reader.ReadLine()); // Read total points

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    _score = totalPoints; // Update total points

                    // Parse common goal properties
                    string typeName = parts[0];
                    string shortName = parts[1];
                    string description = parts[2];
                    string points = parts[3];
                    bool isComplete = bool.Parse(parts[4]);

                    // Create appropriate goal type based on type name
                    Goal goal;
                    switch (typeName)
                    {
                        case "SimpleGoal":
                            goal = new SimpleGoal(shortName, description, points);
                            break;
                        case "EternalGoal":
                            goal = new EternalGoal(shortName, description, points);
                            break;
                        case "ChecklistGoal":
                            int amountCompleted = int.Parse(parts[5]);
                            int target = int.Parse(parts[6]);
                            int bonus = int.Parse(parts[7]);
                            goal = new ChecklistGoal(shortName, description, points, target, bonus)
                            {
                                AmountCompleted = amountCompleted
                            };
                            break;
                        default:
                            throw new ArgumentException("Invalid goal type found in file.");
                    }

                    // Set completeness
                    if (isComplete && !(goal is EternalGoal)) // Ensure eternal goals are not marked complete
                        goal.RecordEvent();

                    _goals.Add(goal);
                }

                _score = totalPoints; // Set the total points
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }



}
