using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine($"Consider the following prompt: \n --- {randomPrompt}---");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine(); // Wait for user to press Enter
        Console.WriteLine("Now ponder the following questions as they related to this experience.");
        ShowSpinner(5);

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

        // Calculate the time taken by each question
        int questionTime = 5; // 5 seconds per question

        // Ask questions until there's not enough time left for another question
        while (remainingTime >= questionTime)
        {
            foreach (string question in _questions)
            {
                // Check if there's enough time left to ask the next question
                if (remainingTime < questionTime)
                    break;

                DisplayQuestions();
                Console.WriteLine(question);
                ShowSpinner(5); // Show spinner for 5 seconds for each question

                // Deduct the time spent on the question
                remainingTime -= questionTime;
            }
        }

        DisplayEndingMessage(); // Display ending message once the activity duration has elapsed   
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Reflect on the following prompt:");
    }

    public void DisplayQuestions()
    {
        Console.Write("> ");
    }
}
