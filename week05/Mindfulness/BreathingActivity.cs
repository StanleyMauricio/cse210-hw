public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public  void Run()
    {
        DisplayStartingMessage();
        ShowCountDown(3);

        int elapsedTime = 0;
        DateTime startTime = DateTime.Now;

        while (elapsedTime < _duration)
        {
            Console.WriteLine("\nBreathe in...");
            ShowCountDown(3);

            Console.WriteLine("Now breathe out...");
            ShowCountDown(4);

            elapsedTime = (int)(DateTime.Now - startTime).TotalSeconds;
        }

        TimeSpan elapsed = DateTime.Now - startTime;
        DisplayEndingMessage((int)elapsed.TotalSeconds);
    }
}

