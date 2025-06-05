using System;
using System.Threading;

public class MindfulnessActivity
{
    private string _name;
    private string _description;
    private int _duration;

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {_name}...");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        DisplayAnimation(3); // Pause for 3 seconds
    }

    public void EndActivity()
    {
        Console.WriteLine("Great job! You've completed the activity.");
        Console.WriteLine($"You just finished {_name} for {_duration} seconds.");
        DisplayAnimation(3); // Pause for 3 seconds before finishing
    }

    protected void DisplayAnimation(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{new string('.', i)} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public int GetDuration()
    {
        return _duration;
    }
}
