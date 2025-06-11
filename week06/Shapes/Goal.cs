public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; protected set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsCompleted = false;
    }

    public abstract void RecordProgress(); // Polymorphic method

    public virtual string DisplayStatus()
    {
        return IsCompleted ? $"[✔] {Name}" : $"[ ] {Name}";
    }
}
