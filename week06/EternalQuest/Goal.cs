public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public string Name
    {
        get { return _shortName; }
        set { _shortName = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public int Points
    {
        get { return _points; }
        protected set { _points = value; }
    }

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent(); 
    public abstract bool IsComplete();
    public virtual string GetDetailsString() 
    {
        return $"[{(IsComplete() ? "X" : " ")}] {Name} ({Description})";
    }
    public abstract string GetStringRepresentation();
}