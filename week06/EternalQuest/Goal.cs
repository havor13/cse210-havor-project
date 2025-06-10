public abstract class Goal
{
    protected string _name;
    protected int _points;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
    }

    public string Name => _name; // Public getter
    public int Points => _points; // Public getter

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetProgress();
}
