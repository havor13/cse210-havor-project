// Checklist goal - requires multiple completions
public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _currentCount++;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetProgress() => $"Completed {_currentCount}/{_targetCount} times";
}
