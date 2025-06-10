public class BadgeSystem
{
    private List<string> _badges;

    public BadgeSystem()
    {
        _badges = new List<string>();
    }

    public void EarnBadge(string badgeName)
    {
        if (!_badges.Contains(badgeName))
        {
            _badges.Add(badgeName);
            Console.WriteLine($"🏅 You earned the '{badgeName}' badge!");
        }
    }

    public string GetBadges() => _badges.Count > 0 ? string.Join(", ", _badges) : "No badges earned yet.";
}
