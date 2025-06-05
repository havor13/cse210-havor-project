using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().StartBreathing();
                    break;
                case "2":
                    new ReflectionActivity().StartReflection();
                    break;
                case "3":
                    new ListingActivity().StartListing();
                    break;
                case "4":
                    Console.WriteLine("Goodbye! Stay mindful!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
