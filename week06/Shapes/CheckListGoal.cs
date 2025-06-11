public class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; private set; }
    public int BonusPoints { get; private set; }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override void RecordProgress()
    {
        CurrentCount++;
        if (CurrentCount >= TargetCount)
        {
            IsCompleted = true;
            Points += BonusPoints;
        }
        else
        {
            Points += 50; // Increment for each step
        }
    }

    public override string DisplayStatus()
    {
        return IsCompleted ? $"[✔] {Name} (Completed {TargetCount}/{TargetCount})"
                           : $"[ ] {Name} (Completed {CurrentCount}/{TargetCount})";
    }
}
