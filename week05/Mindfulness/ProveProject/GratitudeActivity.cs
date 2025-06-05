public class GratitudeActivity : MindfulnessActivity
{
    public GratitudeActivity() : base("Gratitude Journaling", "Write down things you are grateful for.")
    {
    }

    public void StartGratitude()
    {
        StartActivity();
        Console.WriteLine("Start listing things you are grateful for:");
        List<string> gratitudeList = new List<string>();

        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).Seconds < duration)
        {
            Console.Write("- ");
            gratitudeList.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {gratitudeList.Count} things you're grateful for!");
        EndActivity();
    }
}
