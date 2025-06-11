public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points) {}

    public override void RecordProgress()
    {
        if (!IsCompleted) // Prevent marking twice
        {
            IsCompleted = true;
            Console.WriteLine($"✅ Goal '{Name}' completed! +{Points} points awarded.");
        }
        else
        {
            Console.WriteLine($"⚠️ Goal '{Name}' is already completed.");
        }
    }
}
