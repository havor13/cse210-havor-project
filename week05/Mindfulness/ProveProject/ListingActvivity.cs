public class ListingActivity : MindfulnessActivity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity helps you reflect on the good things in your life.")
    {
    }

    public void StartListing()
    {
        StartActivity();
        Random random = new Random();
        Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
        DisplayAnimation(3);

        Console.WriteLine("Start listing items:");
        List<string> items = new List<string>();

        int duration = GetDuration();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).Seconds < duration)
        {
            Console.Write("- ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {items.Count} items!");
        EndActivity();
    }
}
