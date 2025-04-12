public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"You recorded progress on the eternal goal '{Name}'. You earned {Points} points.");
        return Points;
    }

    public override bool IsComplete()
    {
        return false; 
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name}:{Description}:{Points}";
    }
}
