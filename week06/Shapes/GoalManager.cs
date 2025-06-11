using System;
using System.Collections.Generic;

public class GoalManager
{
    public List<Goal> Goals { get; private set; } = new List<Goal>();

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void RecordGoalEvent(string goalName)
    {
        foreach (var goal in Goals)
        {
            if (goal.Name.Equals(goalName, StringComparison.OrdinalIgnoreCase))
            {
                goal.RecordProgress();
                Console.WriteLine($"✅ Goal '{goalName}' recorded!");
                return;
            }
        }
        Console.WriteLine("⚠️ Goal not found.");
    }

    public void ShowGoals()
    {
        Console.WriteLine("\nCurrent Goals:");
        foreach (var goal in Goals)
        {
            Console.WriteLine(goal.DisplayStatus());
        }
    }
}
