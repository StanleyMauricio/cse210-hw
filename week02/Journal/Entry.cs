using System;

// Clase que representa una única entrada en el diario
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string date, string prompt, string entry)
    {
        _date = date;
        _promptText = prompt;
        _entryText = entry;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}\n");
    }
}
