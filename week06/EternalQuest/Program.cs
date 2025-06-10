using System;

class Program
{
    static void Main()
    {
        GoalManager goalManager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("\n🎯 Welcome to Eternal Quest!");
            Console.WriteLine("1. Create a Goal");
            Console.WriteLine("2. Record a Goal Event");
            Console.WriteLine("3. View Progress");
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
                    RecordGoalEvent(goalManager);
                    break;
                case "3":
                    goalManager.DisplayProgress();
                    break;
                case "4":
                    goalManager.SaveGoals();
                    Console.WriteLine("📁 Progress saved successfully!");
                    break;
                case "5":
                    goalManager.LoadGoals();
                    Console.WriteLine("🔄 Progress loaded successfully!");
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
        string type = Console.ReadLine();

        Goal goal = null;

        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, 100);
                break;
            case "2":
                goal = new EternalGoal(name, 50);
                break;
            case "3":
                Console.Write("Enter required completions: ");
                int targetCount = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, 50, targetCount, 200);
                break;
            default:
                Console.WriteLine("⚠️ Invalid type.");
                return;
        }

        goalManager.AddGoal(goal);
    }

    static void RecordGoalEvent(GoalManager goalManager)
    {
        Console.WriteLine("\n🏆 Record a completed goal:");
        goalManager.DisplayGoals();

        Console.Write("Enter goal name to record: ");
        string goalName = Console.ReadLine();

        goalManager.RecordGoalEvent(goalName);
    }
}
