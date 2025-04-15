using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 4, 11), 25, 4.8),
            new StationaryBicycles(new DateTime(2025, 4, 12), 40, 25.0),
            new Swimming(new DateTime(2025, 4, 13), 20, 40)
        };

        Console.WriteLine("Activity Summary:");
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
