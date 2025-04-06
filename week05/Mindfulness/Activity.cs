public  class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected static Random _random = new Random();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public virtual void DisplayStartingMessage()
    {
        Console.WriteLine($"\nWelcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        int durationInput = 0;

        while (durationInput <= 0)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            int.TryParse(input, out durationInput);

            if (durationInput <= 0)
            {
                Console.WriteLine("Please enter a positive number.");
            }
        }

        _duration = durationInput;
        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    public virtual void DisplayEndingMessage(int elapsedSeconds)
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed another {elapsedSeconds} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public virtual void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(animationStrings[i]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            i = (i + 1) % animationStrings.Count;
        }
    }

    public virtual void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rStarting in: {i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\r                  \r");
    }

  
    
}
