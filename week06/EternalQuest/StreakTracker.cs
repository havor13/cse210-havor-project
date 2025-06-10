public class StreakTracker
{
    private Dictionary<string, int> _goalStreaks;

    public StreakTracker()
    {
        _goalStreaks = new Dictionary<string, int>();
    }

    public void RecordGoal(string goalName)
    {
        if (!_goalStreaks.ContainsKey(goalName))
            _goalStreaks[goalName] = 0;
        
        _goalStreaks[goalName]++;
        Console.WriteLine($"🔥 Streak for {goalName}: {_goalStreaks[goalName]} days in a row!");
    }

    public string GetStreaks()
    {
        return _goalStreaks.Count > 0 ? string.Join("\n", _goalStreaks.Select(g => $"{g.Key}: {g.Value}-day streak")) : "No active streaks.";
    }
}
