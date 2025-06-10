using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private LevelSystem _levelSystem;
    private BadgeSystem _badgeSystem;
    private StreakTracker _streakTracker;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _levelSystem = new LevelSystem();
        _badgeSystem = new BadgeSystem();
        _streakTracker = new StreakTracker();
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
        Console.WriteLine($"✅ Goal '{goal.Name}' added successfully!");
    }

    public Goal GetGoal(string name)
    {
        return _goals.Find(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void RecordGoalEvent(string goalName)
    {
        Goal goal = GetGoal(goalName);

        if (goal != null)
        {
            goal.RecordEvent();
            _levelSystem.AddXP(goal.Points);
            _streakTracker.RecordGoal(goalName);

            if (goal.IsComplete())
            {
                _badgeSystem.EarnBadge($"Completed {goalName}");
            }

            Console.WriteLine($"🎉 Recorded '{goalName}'. You earned {goal.Points} points!");
            Console.WriteLine($"📈 {GetLevelInfo()}");
        }
        else
        {
            Console.WriteLine("⚠️ Goal not found.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\n📋 Your Goals:");

        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"🔹 {goal.Name}: {goal.GetProgress()}");
        }
    }

    public void DisplayProgress()
    {
        Console.WriteLine("\n📊 Progress Overview:");
        DisplayGoals();
        Console.WriteLine($"🔹 {GetLevelInfo()}");
        Console.WriteLine($"🏅 Badges: {_badgeSystem.GetBadges()}");
        Console.WriteLine($"🔥 Streaks:\n{_streakTracker.GetStreaks()}");
    }

    public string GetLevelInfo() => _levelSystem.GetLevelInfo();
}
