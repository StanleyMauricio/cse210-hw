using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    public List<Word> _words = new List<Word>(); 

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] wordsArray = text.Split(' ');
        foreach (string wordText in wordsArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> wordsToHide = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                wordsToHide.Add(word);
            }
        }
        if (wordsToHide.Count == 0) return;

        int numToHide = Math.Min(numberToHide, wordsToHide.Count);
        Random random = new Random();
        List<Word> hiddenWords = new List<Word>();
        for (int i = 0; i < numToHide; i++)
        {
            int randomIndex = random.Next(wordsToHide.Count);
            hiddenWords.Add(wordsToHide[randomIndex]);
            wordsToHide.RemoveAt(randomIndex);
        }
        foreach (Word word in hiddenWords)
        {
            word.Hide();
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + ": ";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}