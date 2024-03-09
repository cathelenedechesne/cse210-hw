using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        promptGenerator._prompts = new List<string>
        { "What's on your mind today?",
         "Describe a happy moment.",
         "What challenges did you face today?",
         "Who was the most interesting person I interacted with today?",
         "What was the best part of my day?",
         "How did I see the hand of the Lord in my life today?",
         "What was the strongest emotion I felt today?",
         "If I had one thing I could do over today, what would it be?",
        };
        string saveFile = ""; // Initialize saveFile here

        while (true)
        {
            Console.WriteLine("Please choose the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        // Write
                        Entry newEntry = new Entry
                        {
                            _date = DateTime.Now.ToString("yyyy-MM-dd"),
                            _promptText = promptGenerator.GetRandomPrompt()
                        };
                        Console.WriteLine("Prompt: " + newEntry._promptText);
                        Console.WriteLine("Enter your text:");
                        newEntry._entryText = Console.ReadLine();
                        journal.AddEntry(newEntry);
                        break;
                    case 2:
                        // Display
                        journal.DisplayAll();
                        break;
                    case 3:
                        // Load
                        Console.WriteLine("Enter the file name to load:");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;
                    case 4:
                        // Save
                    Console.WriteLine("Enter the file name to save entries to:");
                    saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                    case 5:
                        Console.Write("Did you save your entries? (1. Yes / 2. No): ");
                        int saveChoice;
                        if (int.TryParse(Console.ReadLine(), out saveChoice))
                        {
                            if (saveChoice == 1)
                            {
                                Console.WriteLine("Goodbye!");
                                Environment.Exit(0);
                            }
                            else if (saveChoice == 2)
                            {
                                Console.Write("Do you want to save your entries before quitting? (1. Yes / 2. No): ");
                                int saveBeforeQuitChoice;
                                if (int.TryParse(Console.ReadLine(), out saveBeforeQuitChoice))
                                {
                                    if (saveBeforeQuitChoice == 1)
                                    {
                                        journal.SaveToFile(saveFile); // Reusing saveFile from case 4
                                        Console.WriteLine("Entries saved successfully.");
                                    }
                                    Console.WriteLine("Goodbye!");
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a number.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 1 or 2.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
        }
    }
}