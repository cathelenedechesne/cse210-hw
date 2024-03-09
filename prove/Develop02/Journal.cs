using System.IO;
using System.Collections.Generic;

public class Journal
{
    public List<Entry> _entries;

    public Journal()
    {
        // Initialize the list of entries
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        while (string.IsNullOrWhiteSpace(file))
        {
            Console.WriteLine("File name cannot be empty. Please enter a valid file name:");
            file = Console.ReadLine();
        }

        Console.WriteLine("Entries saved to file.");

        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date},{entry._promptText},{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        // Implement logic to load entries from a file
        // For simplicity, let's assume each entry is saved on a new line
        _entries.Clear();


        Console.WriteLine("Entries loaded from file.");

        using (StreamReader reader = new StreamReader(file))
        {
            while (!reader.EndOfStream)
            {
                string[] parts = reader.ReadLine().Split(',');
                Entry entry = new Entry
                {
                    _date = parts[0],
                    _promptText = parts[1],
                    _entryText = parts[2]
                };
                _entries.Add(entry);
            }
        }
    }

}