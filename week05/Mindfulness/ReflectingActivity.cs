public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private string _currentPrompt;

    public ReflectingActivity() : base(
        "Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        return _questions[_random.Next(_questions.Count)];
    }

    private void DisplayPrompt()
    {
        Console.WriteLine($"\nConsider the following prompt:");
        Console.WriteLine($"--- {_currentPrompt} ---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(3);
    }

    private void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        int elapsedSeconds = 0;

        while (elapsedSeconds < _duration)
        {
            string question = GetRandomQuestion();
            Console.WriteLine($"\n{question}");
            ShowSpinner(3);
            elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
        }
    }

    public  void Run()
    {
        DisplayStartingMessage();
        _currentPrompt = GetRandomPrompt();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage(_duration);
    }
}
