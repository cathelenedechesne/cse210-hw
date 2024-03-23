using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "Generic Activity";
        _description = "This is a generic activity.";
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}");        
        Console.WriteLine(_description);
        Console.WriteLine("\n");
        Console.Write("Please enter the duration of the activity in seconds: ");
        _duration = int.Parse(Console.ReadLine());       
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(5);
    }

    public void DisplayEndingMessage()
    {        
        Console.WriteLine($"Congratulations! You've completed {_name}.");
        ShowSpinner(5);        
        Console.WriteLine($"You've spent {_duration} seconds on this activity.");
        ShowSpinner(5);        
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");        

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(500); // Pause for 1 second
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
        Console.WriteLine();
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000); // Pause for 1 second
            Console.Write("\b \b");
        }
    }
}