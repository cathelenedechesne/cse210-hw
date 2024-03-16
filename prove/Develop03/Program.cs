using System;

class Program
{
    static void Main(string[] args)
    {
        // Add scriptures to the library
        Reference reference1 = new Reference("John", 3, 16);
        Scripture scripture1 = new Scripture(reference1, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        Reference reference2 = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture2 = new Scripture(reference2, "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");

        // List to keep track of scriptures that are completely hidden
        List<Scripture> hiddenScriptures = new List<Scripture>();

        // Add all scriptures to the list
        hiddenScriptures.Add(scripture1);
        hiddenScriptures.Add(scripture2);

        // Main program loop
        while (hiddenScriptures.Count > 0)
        {
            // Get a random scripture from the list
            int index = new Random().Next(hiddenScriptures.Count);
            Scripture randomScripture = hiddenScriptures[index];

            // Display scripture and handle hiding words
            Console.WriteLine(randomScripture.GetDisplayText());
            while (!randomScripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nPress enter to hide words or type 'quit' to exit:");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    return; // Return from Main method to exit the program

                randomScripture.HideRandomWords(2); // Hides 2 random words each time
                Console.Clear();
                Console.WriteLine(randomScripture.GetDisplayText());
            }

            // Remove the completely hidden scripture from the list
            hiddenScriptures.Remove(randomScripture);
        }

        // Print message and exit program once all scriptures are completely hidden
        Console.WriteLine("All scriptures have been completely hidden. Exiting program.");
    }
}
