// Eternal goal - never fully completed
public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, int points) : base(name, points)
    {
        _timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
    }

    public override bool IsComplete() => false; // Never fully complete

    public override string GetProgress() => $"Completed {_timesCompleted} times";
}
