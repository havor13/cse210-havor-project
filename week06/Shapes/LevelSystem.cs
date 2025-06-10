using System;

public class LevelSystem
{
    private int _xp;
    private int _level;

    public LevelSystem()
    {
        _xp = 0;
        _level = 1;
    }

    public void AddXP(int points)
    {
        _xp += points;
        if (_xp >= _level * 100) // Level up every 100 XP per level
        {
            _level++;
            Console.WriteLine($"🎉 Congratulations! You leveled up to Level {_level}!");
        }
    }

    public string GetLevelInfo()
    {
        return $"Level {_level} | XP: {_xp}";
    }
}
