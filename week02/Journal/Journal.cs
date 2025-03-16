using System;
using System.Collections.Generic;
using System.IO;

// Clase que almacena y gestiona las entradas del diario
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (var entry in _entries)
            {
                outputFile.WriteLine($"{entry._date},{entry._promptText},{entry._entryText}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string fileName)
    {
        
        
            _entries.Clear();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] parts = line.Split(",");
                if (parts.Length == 3)
                {
                    string date = DateTime.Parse(parts[0]).ToShortDateString(); //date
                    string promptText = parts[1];
                    string entryText = parts[2];
                    _entries.Add(new Entry(date, promptText, entryText));
                }
            }
            Console.WriteLine("Journal successfully uploaded.");
       
    }
}
