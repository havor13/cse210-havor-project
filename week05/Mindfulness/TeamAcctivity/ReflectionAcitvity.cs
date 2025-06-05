using System.Collections.Generic;

public class ReflectionActivity : MindfulnessActivity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity helps you reflect on your strength and resilience.")
    {
    }

    public void StartReflection()
    {
        StartActivity();
        int duration = GetDuration();
        Random random = new Random();

        Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
        DisplayAnimation(3);

        for (int i = 0; i < duration / 3; i++)
        {
            Console.WriteLine(Questions[random.Next(Questions.Count)]);
            DisplayAnimation(3);
        }

        EndActivity();
    }
}
