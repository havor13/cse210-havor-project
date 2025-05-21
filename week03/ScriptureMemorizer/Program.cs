using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only Son."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ who strengthens me."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding."),
            new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want.")
        };

        // Select a random scripture
        Random random = new Random();
        Scripture selectedScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        // Memorization loop
        while (!selectedScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine("Memorization Mode: ");
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words, type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            selectedScripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine("You’ve successfully memorized the scripture!");
    }
}
