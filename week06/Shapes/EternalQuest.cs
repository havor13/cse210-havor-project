public class EternalQuest
{
    private GoalManager goalManager = new GoalManager();
    private UserProgress userProgress = new UserProgress();
    private LevelSystem levelSystem = new LevelSystem();
    private BadgeSystem badgeSystem = new BadgeSystem();

    public void Start()
    {
        Console.WriteLine("Welcome to Eternal Quest!");
        userProgress.LoadProgress("progress.json");
    }

    public void CompleteGoal(string goalName)
    {
        goalManager.RecordGoalEvent(goalName);
        levelSystem.AddExperience(100); // XP Bonus
        badgeSystem.AwardBadge("Goal Champion"); // Example badge
    }
}
