

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please select an action:");
        Console.WriteLine("1. Start writing\n2. Load history\n3. Display the journal");

        int choice = int.Parse(Console.ReadLine());

        Journal journal = new Journal();
        string filePath = "myjournal.csv";

        switch (choice)
        {
            case 1:
                Console.WriteLine("What's your name?");
                string name = Console.ReadLine();

                do
                {
                    Prompt.DisplayRandomPrompt();
                    Console.WriteLine("Write your response (or type 'exit' to stop):");
                    string response = Console.ReadLine();

                    if (response.ToLower() == "exit")
                        break;

                    Entry entry = new Entry
                    {
                        _Date = DateTime.Now.ToShortDateString(),
                        _Name = name,
                        _Response = response
                    };

                    journal.AddEntry(entry);
                } while (true);

                journal.Save(filePath);
                Console.WriteLine("Entries have been saved to the file.");
                break;

            case 2:
                Console.WriteLine("Enter the date you want to see (date format: yyyy/MM/dd):");
                string selectDate = Console.ReadLine();
                journal.Load(filePath);

                var entriesForDate = journal.GetEntriesForDate(selectDate);

                if (entriesForDate.Any())
                {
                    foreach (var entry in entriesForDate)
                    {
                        Console.WriteLine($"Date: {entry._Date}, Name: {entry._Name}, Response: {entry._Response}");
                    }
                }
                else
                {
                    Console.WriteLine($"No entries found for date: {selectDate}");
                }
                break;

            case 3:
                journal.Load(filePath);
                journal.Display();
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}
