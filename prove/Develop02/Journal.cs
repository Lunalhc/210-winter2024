
public class Journal
{
    public List<Entry> Entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public List<Entry> GetEntriesForDate(string date)
    {
        return Entries.Where(entry => entry._Date == date).ToList();
    }

    public void Save(string filePath)
    {
        using (StreamWriter sw = File.AppendText(filePath))
        {
            foreach (Entry entry in Entries)
            {
                sw.WriteLine($"{entry._Date},{entry._Name},{entry._Response}");
            }
        }
    }

    public void Load(string filePath)
    {
        Entries.Clear();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                Entry entry = new Entry
                {
                    _Date = parts[0],
                    _Name = parts[1],
                    _Response = parts[2]
                };
                Entries.Add(entry);
            }
        }
        else
        {
            Console.WriteLine("The specified file does not exist.");
        }
    }

    public void Display()
    {
        foreach (Entry entry in Entries)
        {
            Console.WriteLine($"Date: {entry._Date}, Name: {entry._Name}, Response: {entry._Response}");
        }
    }
}