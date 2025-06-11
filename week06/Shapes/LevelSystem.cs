public class LevelSystem
{
    public int Level { get; private set; } = 1;
    public int Experience { get; private set; }
    private const int XPPerLevel = 500;

    public void AddExperience(int points)
    {
        Experience += points;
        while (Experience >= XPPerLevel)
        {
            Experience -= XPPerLevel;
            Level++;
            Console.WriteLine($"🔝 Level Up! You are now Level {Level}");
        }
    }

    public void ShowLevel()
    {
        Console.WriteLine($"🌟 Level: {Level}, XP: {Experience}/{XPPerLevel}");
    }
}
