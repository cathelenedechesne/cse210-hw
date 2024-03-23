using System;


public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        int remainingTime = _duration; // Remaining time in seconds
        while (remainingTime > 0)
        {
            // Breathing in            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Breathing in...");
            ShowCountDown(4); // Countdown for breathing in
            remainingTime -= 4;
            // Reset color
            Console.ResetColor();            
            Console.WriteLine("\n");

            

            if (remainingTime <= 0)
                break;

            // Breathing out
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Breathing out...");
            ShowCountDown(6); // Countdown for breathing out
            remainingTime -= 6;
            // Reset color
            Console.ResetColor();            
            Console.WriteLine("\n");

            
        }

        DisplayEndingMessage();
    }
}