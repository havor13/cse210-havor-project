using System;

public class Entry
{
    public string Date { get; set; }
    public string Text { get; set; }
    public string Prompt { get; set; }

    public Entry(string date, string text, string prompt)
    {
        Date = date;
        Text = text;
        Prompt = prompt;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}\nPrompt: {Prompt}\nEntry: {Text}\n");
    }
}
