using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of activities
        Activity runningActivity = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        Activity cyclingActivity = new Cycling(new DateTime(2022, 11, 3), 30, 20.0);
        Activity swimmingActivity = new Swimming(new DateTime(2022, 11, 3), 50, 10);

        // Storing activities in a list
        var activities = new Activity[] { runningActivity, cyclingActivity, swimmingActivity };

        // Displaying summary for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

    }
}