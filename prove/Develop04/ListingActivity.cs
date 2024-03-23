using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _count = 0; // Initialize _count to 0
    }

    public void Run()
    {
        DisplayStartingMessage();
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine($"List as many responses you can to the following prompt: \n --- {randomPrompt} ---");
        Console.WriteLine("Get ready to list...");
        ShowSpinner(3); // Initial countdown

        int remainingTime = _duration; // Remaining time in seconds

        // Calculate the time taken by displaying the prompt and waiting for user's input
        remainingTime -= 5; // Assuming it takes 5 seconds

        if (remainingTime <= 0)
        {
            // Handle case where the activity duration is too short
            Console.WriteLine("Activity duration is too short.");
            DisplayEndingMessage();
            return;
        }

        // Start the timer for user input
        DateTime startTime = DateTime.Now;

        // Allow the user to list items until time runs out
        List<string> items = new List<string>();
        do
        {
            string input = Console.ReadLine();
            if (input.ToLower() != "done")
            {
                items.Add(input);

                // Calculate the elapsed time since the start of user input
                TimeSpan elapsedTime = DateTime.Now - startTime;
                remainingTime = _duration - (int)elapsedTime.TotalSeconds;
            }
            else
            {
                break;
            }
        } while (remainingTime > 0);

        // Display the count of items listed
        _count = items.Count;
        Console.WriteLine($"You listed {_count} items.");

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();        
        string input;
        do
        {
            input = Console.ReadLine();
            if (input.ToLower() != "done")
                items.Add(input);
        } while (input.ToLower() != "done");
        return items;
    }
}