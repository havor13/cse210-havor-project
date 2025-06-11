public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) {}

    public override void RecordProgress()
    {
        Points += 100; // Gains points each time it's recorded
    }
}
