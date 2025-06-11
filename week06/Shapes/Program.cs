using System;
using System.IO;

class Program
{
    static void Main()
    {
        UserProgress userProgress = new UserProgress();
        GoalManager goalManager = new GoalManager();
        string progressFile = "progress.xml";

        // Ensure progress.xml exists, or create a new one
        if (!File.Exists(progressFile))
        {
            Console.WriteLine("📂 No progress file found, creating a new one...");
            userProgress.AddGoal(new SimpleGoal("Read a Book", "Finish reading a book", 100));
            userProgress.AddGoal(new EternalGoal("Daily Exercise", "Workout every day", 50));
            userProgress.AddGoal(new ChecklistGoal("Complete Assignments", "Submit assignments", 50, 5, 200));
            userProgress.SaveProgress(progressFile);
        }

        // Load saved progress
        userProgress.LoadProgress(progressFile);

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("\n🎯 Welcome to Eternal Quest!");
            Console.WriteLine("1. Create a Goal");
            Console.WriteLine("2. Record a Goal Event");
            Console.WriteLine("3. View Progress & Score");
            Console.WriteLine("4. Save Progress");
            Console.WriteLine("5. Load Progress");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(goalManager);
                    break;
                case "2":
                    RecordGoalEvent(goalManager, userProgress);
                    break;
                case "3":
                    userProgress.DisplayProgress();
                    break;
                case "4":
                    userProgress.SaveProgress(progressFile);
                    break;
                case "5":
                    userProgress.LoadProgress(progressFile);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("⚠️ Invalid option, try again.");
                    break;
            }
        }

        Console.WriteLine("🚀 Thanks for playing Eternal Quest!");
    }

    static void CreateGoal(GoalManager goalManager)
    {
        Console.Write("\nEnter goal name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select an option: ");
        string type = Console.ReadLine();

        Goal goal = null;

        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, "A simple goal", 100);
                break;
            case "2":
                goal = new EternalGoal(name, "An eternal goal", 50);
                break;
            case "3":
                Console.Write("Enter required completions: ");
                if (int.TryParse(Console.ReadLine(), out int targetCount))
                {
                    goal = new ChecklistGoal(name, "Checklist goal", 50, targetCount, 200);
                }
                else
                {
                    Console.WriteLine("⚠️ Invalid number, goal not created.");
                    return;
                }
                break;
            default:
                Console.WriteLine("⚠️ Invalid type.");
                return;
        }

        goalManager.AddGoal(goal);
        Console.WriteLine($"✅ Goal '{goal.Name}' added successfully!");
    }

    static void RecordGoalEvent(GoalManager goalManager, UserProgress userProgress)
    {
        Console.WriteLine("\n🏆 Record a completed goal:");
        goalManager.ShowGoals();

        Console.Write("Enter goal name to record: ");
        string goalName = Console.ReadLine();

        userProgress.RecordGoalEvent(goalName);
    }
}
