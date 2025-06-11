public class StreakTracker
{
    public int CurrentStreak { get; private set; }
    public int BestStreak { get; private set; }

    public void UpdateStreak(bool goalCompletedToday)
    {
        if (goalCompletedToday)
        {
            CurrentStreak++;
            if (CurrentStreak > BestStreak)
                BestStreak = CurrentStreak;
        }
        else
        {
            CurrentStreak = 0;
        }
    }

    public void DisplayStreak()
    {
        Console.WriteLine($"🔥 Current Streak: {CurrentStreak}, Best Streak: {BestStreak}");
    }
}
