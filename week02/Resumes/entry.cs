using System;

public class Entry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response}";
    }
}
