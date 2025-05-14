using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string filename = "journal.txt";

        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Save to File");
            Console.WriteLine("4. Load from File");
            Console.WriteLine("5. Get Random Prompt");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the date (YYYY-MM-DD): ");
                    string date = Console.ReadLine();
                    Console.Write("Enter the journal entry: ");
                    string text = Console.ReadLine();
                    Console.Write("Enter a prompt or type 'random' for a random one: ");
                    string prompt = Console.ReadLine();

                    if (prompt.ToLower() == "random")
                    {
                        prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"Using prompt: {prompt}");
                    }

                    journal.AddEntry(new Entry(date, text, prompt));
                    Console.WriteLine("Entry added successfully!");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    journal.SaveToFile(filename);
                    Console.WriteLine("Journal saved to file.");
                    break;

                case "4":
                    journal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded from file.");
                    break;

                case "5":
                    Console.WriteLine($"Random Prompt: {promptGenerator.GetRandomPrompt()}");
                    break;

                case "6":
                    Console.WriteLine("Exiting the program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
