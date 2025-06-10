// Simple goal - completed once
public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string name, int points) : base(name, points)
    {
        _isCompleted = false;
    }

    public override void RecordEvent()
    {
        _isCompleted = true;
    }

    public override bool IsComplete() => _isCompleted;

    public override string GetProgress() => _isCompleted ? "[X] Completed" : "[ ] Not Completed";
}
