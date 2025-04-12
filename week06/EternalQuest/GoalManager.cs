using System;
using System.Collections.Generic;
using System.IO;
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _filename = "goals.txt"; 

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice;
        do
        {
            DisplayPlayerInfo(); 
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Console.WriteLine("Quitting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (choice != 6);
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points."); 
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nTus Objetivos:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals recorded yet.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].Name}");
            }
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals recorded yet.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }
    }

   private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

    if (int.TryParse(Console.ReadLine(), out int goalType))
        {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            switch (goalType)
            {
                case 1:
                    _goals.Add(new SimpleGoal(name, description, points));
                    Console.WriteLine("Simple Goal created successfully!");
                    break;
                case 2:
                    _goals.Add(new EternalGoal(name, description, points));
                    Console.WriteLine("Eternal Goal created successfully!");
                    break;
                case 3:
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    if (int.TryParse(Console.ReadLine(), out int target))
                    {
                        Console.Write("What is the amount of the bonus points for completing it that many times? ");
                        if (int.TryParse(Console.ReadLine(), out int bonus))
                        {
                            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                            Console.WriteLine("Checklist Goal created successfully!");
                        }
                    }
                    break;
            }
        }
     }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        if (_goals.Count > 0)
        {
            Console.Write("Which goal did you accomplish? ");
            if (int.TryParse(Console.ReadLine(), out int goalNumber) && goalNumber >= 1 && goalNumber <= _goals.Count)
            {
                Goal goalToRecord = _goals[goalNumber - 1];
                _score += goalToRecord.RecordEvent();
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
        else
        {
            Console.WriteLine("No goals to record events for.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save goals: ");
        string saveFilename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(saveFilename))
        {
            saveFilename = _filename; 
        }
        try
        {
            using (StreamWriter writer = new StreamWriter(saveFilename))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation().Replace(":", ","));
                }
            }
            Console.WriteLine($"Goals saved successfully to {saveFilename}!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals to {saveFilename}: {ex.Message}");
        }
    }

      public void LoadGoals()
{
    Console.Write("Enter the filename to load goals from: ");
    string loadFilename = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(loadFilename))
    {
        loadFilename = _filename;
    }

    if (File.Exists(loadFilename))
    {
        string[] lines = File.ReadAllLines(loadFilename);
        if (lines.Length > 0 && int.TryParse(lines[0], out _score))
        {
            _goals.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(',');

                if (parts.Length > 0)
                {
                    string goalType = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            bool isComplete = bool.Parse(parts[4]);
                            _goals.Add(new SimpleGoal(name, description, points));
                            if (isComplete) (_goals.Last() as SimpleGoal).RecordEvent();
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(name, description, points));
                            break;
                        case "ChecklistGoal":
                            int target = int.Parse(parts[4]);
                            int bonus = int.Parse(parts[5]);
                            int amountCompleted = int.Parse(parts[6]);
                            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                            _goals.Add(checklistGoal);
                            for (int j = 0; j < amountCompleted; j++)
                            {
                                _score += checklistGoal.Points;
                                if (j == amountCompleted - 1 && amountCompleted == target)
                                {
                                    _score += bonus;
                                }
                                
                            }
                            break;
                    }
                }
            }
            Console.WriteLine($"Goals loaded successfully from {loadFilename}!");
        }
    }
}
}