using System;
using System.Collections.Generic;

public class BadgeSystem
{
    private List<string> badges = new List<string>();

    public void AwardBadge(string badge)
    {
        badges.Add(badge);
        Console.WriteLine($"🏅 Badge Earned: {badge}!");
    }

    public void ShowBadges()
    {
        Console.WriteLine("\nYour Badges:");
        foreach (var badge in badges)
        {
            Console.WriteLine($"- {badge}");
        }
    }
}
