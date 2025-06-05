public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity helps you relax by guiding you through deep breathing.")
    {
    }

    public void StartBreathing()
    {
        StartActivity();
        int duration = GetDuration();

        for (int i = 0; i < duration / 2; i++)
        {
            Console.WriteLine("Breathe in...");
            DisplayAnimation(2);
            Console.WriteLine("Breathe out...");
            DisplayAnimation(2);
        }

        EndActivity();
    }
}
