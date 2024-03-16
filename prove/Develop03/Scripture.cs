using System;
using System.Collections.Generic;

class Scripture
{
    private static List<Scripture> _scriptureLibrary = new List<Scripture>(); // Static field to hold all scriptures

    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
        _scriptureLibrary.Add(this); // Add the created scripture to the library
    }

    public static Scripture GetRandomScripture()
    {
        if (_scriptureLibrary.Count == 0)
            return null;

        Random rnd = new Random();
        int index = rnd.Next(_scriptureLibrary.Count);
        return _scriptureLibrary[index];
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rnd = new Random();
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        // Shuffle the list of visible words
        for (int i = visibleWords.Count - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            Word temp = visibleWords[i];
            visibleWords[i] = visibleWords[j];
            visibleWords[j] = temp;
        }

        // Hide a fixed number of words from the beginning of the shuffled list
        for (int i = 0; i < Math.Min(numberToHide, visibleWords.Count); i++)
        {
            visibleWords[i].Hide();
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}
