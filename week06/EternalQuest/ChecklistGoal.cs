public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            Console.WriteLine($"You recorded progress on the checklist goal '{Name}'. Completed {_amountCompleted}/{_target} times. You earned {Points} points.");
            if (_amountCompleted == _target)
            {
                Console.WriteLine($"Goal '{Name}' completed {_target} times! You earned a bonus of {_bonus} points.");
                return Points + _bonus;
            }
            return Points;
        }
        else
        {
            Console.WriteLine($"You have already completed the goal '{Name}' {_target} times.");
            return 0;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {Name} ({Description}) -- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name}:{Description}:{base.Points}:{_target}:{_bonus}:{_amountCompleted}";
    }

    
}
