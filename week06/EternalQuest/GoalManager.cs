using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class GoalManager
{
    private List<Goal> _goals;
    private LevelSystem _levelSystem;
    private BadgeSystem _badgeSystem;
    private StreakTracker _streakTracker;
    private const string SaveFile = "goal_data.json";

    public GoalManager()
    {
        _goals = new List<Goal>();
        _levelSystem = new LevelSystem();
        _badgeSystem = new BadgeSystem();
        _streakTracker = new StreakTracker();

        LoadGoals(); // Load existing data
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
        Console.WriteLine($"✅ Goal '{goal.Name}' added successfully!");
        SaveGoals(); // Save after adding
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

            SaveGoals(); // Save progress
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

    public void SaveGoals()
    {
        try
        {
            var saveData = new
            {
                Goals = _goals,
                LevelInfo = _levelSystem.GetLevelInfo()
            };

            string json = JsonSerializer.Serialize(saveData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SaveFile, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        if (File.Exists(SaveFile))
        {
            try
            {
                string json = File.ReadAllText(SaveFile);
                var saveData = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

                // Deserialize goals
                _goals = JsonSerializer.Deserialize<List<Goal>>(saveData["Goals"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error loading goals: {ex.Message}");
            }
        }
    }
}
