using System;

class Program
{
    static GoalManager goalManager = new GoalManager(); // Create an instance of GoalManager

    static void Main(string[] args)
    {
        int points = GetTotalPoints(); // Get total points        

        while (true)
        {
            Console.WriteLine($"You have {points} points.");
            Console.WriteLine("Menu Option:");
            Console.WriteLine("   1. Create New Goal");
            Console.WriteLine("   2. List Goals");
            Console.WriteLine("   3. Save Goals");
            Console.WriteLine("   4. Load Goals");
            Console.WriteLine("   5. Record Event");
            Console.WriteLine("   6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("   1. Simple Goals");
        Console.WriteLine("   2. Eternal Goals");
        Console.WriteLine("   3. Checklist Goals");
        Console.Write("Which type of goal would you like to create? Enter the number: ");
        string goalTypeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine(); // Points are treated as strings

        int target = 0;
        int bonus = 0;
        if (goalTypeChoice == "3") // Checklist Goal
        {
            Console.Write("How many times does this goal need to be accomplished? ");
            int.TryParse(Console.ReadLine(), out target);
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int.TryParse(Console.ReadLine(), out bonus);
            goalManager.CreateChecklistGoal(name, description, points, target, bonus);
        }
        else if (goalTypeChoice == "2") // Eternal Goal
        {
            goalManager.CreateEternalGoal(name, description, points);
        }
        else // Simple Goal
        {
            goalManager.CreateSimpleGoal(name, description, points);
        }
    }


    static void ListGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < goalManager.Goals.Count; i++)
        {
            Goal goal = goalManager.Goals[i];
            string status = goal.IsComplete() && !(goal is EternalGoal) ? "[X]" : "[ ]";

            // Instead of combining the description again, directly call GetDetailsString()
            string details = $"{i + 1} {status} {goal.GetDetailsString()}";

            Console.WriteLine(details);
        }
    }


    static void SaveGoals()
    {
        Console.Write("Enter file name to save goals: ");
        string filename = Console.ReadLine();
        int totalPoints = GetTotalPoints();
        goalManager.SaveGoals(filename, totalPoints);
        Console.WriteLine("Goals saved successfully!");
    }

    static void LoadGoals()
    {
        Console.Write("Enter file name to load goals: ");
        string filename = Console.ReadLine();
        goalManager.LoadGoals(filename);
        Console.WriteLine("Goals loaded successfully!");
    }

    static void RecordEvent()
    {
        Console.Write("Enter goal name: ");
        string goalName = Console.ReadLine();
        int pointsEarned = 0; // Initialize pointsEarned variable
        goalManager.RecordEvent(goalName, ref pointsEarned); // Pass pointsEarned as reference
        Console.WriteLine($"Total points earned: {pointsEarned}"); // Display points earned
    }


    static int GetTotalPoints()
    {
        int totalPoints = 0;

        // Iterate through each goal and sum up the points
        foreach (Goal goal in goalManager.Goals)
        {
            if (goal is SimpleGoal simpleGoal)
            {
                // Add points for SimpleGoal
                totalPoints += int.Parse(simpleGoal.Points);
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                // Add points for ChecklistGoal
                totalPoints += int.Parse(checklistGoal.Points);
                // Bonus points if checklist goal is complete
                if (checklistGoal.IsComplete())
                {
                    totalPoints += checklistGoal.Bonus;
                }
            }
            else if (goal is EternalGoal eternalGoal)
            {
                // Add points for EternalGoal
                totalPoints += int.Parse(eternalGoal.Points);
            }
        }

        return totalPoints;
    }

}
