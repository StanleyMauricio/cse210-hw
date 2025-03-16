using System;
using System.Collections.Generic;

// Clase que proporciona preguntas aleatorias
public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person you interacted with today?",
        "What was the best part of your day?",
        "How did you see the hand of God in your life today?",
        "What was the strongest emotion you felt today?",
        "If you could do one thing today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        return _prompts[rnd.Next(_prompts.Count)];
    }
}
