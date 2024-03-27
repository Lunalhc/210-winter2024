class Reference
{   
    // set up variables
    private string _book;
    private int _startChapter;
    private int _startVerse;
    private int _endVerse;

    // constructor
    public Reference(string book, int startChapter, int startVerse, int endVerse)
    {
        _book = book;
        _startChapter = startChapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    
    // getters and setters
    public string GetBook()
    {
        return _book;
    }

    public void SetBook(string book)
    {
        _book = book;
    }

    public int GetStartChapter()
    {
        return _startChapter;
    }

    public void SetStartChapter(int startChapter)
    {
        _startChapter = startChapter;
    }

    public int GetStartVerse()
    {
        return _startVerse;
    }

    public void SetStartVerse(int startVerse)
    {
        _startVerse = startVerse;
    }

    public int GetEndVerse()
    {
        return _endVerse;
    }

    public void SetEndVerse(int endVerse)
    {
        _endVerse = endVerse;
    }
    
    // differentiate if it's one verse or 2 consecutive verses
    public string GetVerseReference()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_startChapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_startChapter}:{_startVerse}-{_endVerse}";
        }
    }
}