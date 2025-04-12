public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
            return Points;
        }
        else
        {
            Console.WriteLine($"You have already completed the goal '{Name}'.");
            return 0;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name}:{Description}:{Points}:{_isComplete}";
    }
}
