class Scripture
{   
    // set up variables we need in this class
    private List<Word> _words;  // get thelist from Word class
    private Random _random;     // to be able to use built in class Random later
    
    // constructor
    public Scripture()
    {
        _words = new List<Word>();
        _random = new Random();
    }
    
    // getters and setters
    public List<Word> GetWords()
    {
        return _words;
    }

    public void SetWords(List<Word> words)
    {
        _words = words;
    }

    public Random GetRandom()
    {
        return _random;
    }

    public void SetRandom(Random random)
    {
        _random = random;
    }
    

    // a method that load the scipture file
    public void LoadRandomVersesFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        // Choose a random start line
        int startLine = _random.Next(0, lines.Length - 1);
        
        // Determine whether to select one or two consecutive verses
        int versesToSelect = _random.Next(1, 3);
        int endLine = startLine + versesToSelect - 1;

        // Extract chapter and verse numbers from the first selected line
        string[] startParts = lines[startLine].Split(':');
        string[] startVerseParts = startParts[0].Split(' ');
        int startChapter = 1; // i only have Matthew 1 
        int startVerse = startLine + 1;  // since the counts starts from 0


        // Extract chapter and verse numbers from the last selected line
        string[] endParts = lines[endLine].Split(':');
        string[] endVerseParts = endParts[0].Split(' ');
        int endVerse = endLine + 1;
        
        // create an reference object
        Reference reference = new Reference("Matthew", startChapter, startVerse, endVerse);
        // display the verse number
        Console.WriteLine($"Verse: {reference.GetVerseReference()}");

        // loop through each line
        for (int i = startLine; i <= endLine; i++)
        {
            string[] parts = lines[i].Split(':');  // split by ":"
            // trim the verse and store store each word
            foreach (string word in parts[1].Trim().Split(' '))
            {
                _words.Add(new Word(word));   // add to the word list
            }
        }
    }



    // a method to display the random verse/verses it chooses
    public void DisplayCurrentVerse()
    {
        foreach (Word word in _words)
        {
            Console.Write(word.Display() + " ");
        }
        Console.WriteLine();
    }
    
    // a method to hide random words
    public void HideWords()
    {
        int wordsToHide = 2;
        while (wordsToHide > 0)
        {
            int index = _random.Next(_words.Count);
            if (!_words[index].GetIsHidden())
            {
                _words[index].Hide();
                wordsToHide--;
            }
        }

        if (AllHidden())
        {
            Console.WriteLine("All words have been hidden. Press Enter to exit.");
            Console.ReadLine();
            Environment.Exit(0);   // Exit the program
        }
    }
    
    // a method to check if all words are hidden
    private bool AllHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.GetIsHidden())
                return false;
        }
        return true;
    }

}