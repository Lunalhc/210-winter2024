class Word
{   
    // set up the variables, including a boolean value to check the status of word
    private string _text;
    private bool _isHidden;
    
    // constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;   // set this boolean value to false as default
    }
    
    // getters and setters
    public string GetText()
    {
        return _text;
    }

    public void SetText(string text)
    {
        _text = text;
    }

    public bool GetIsHidden()
    {
        return _isHidden;
    }

    public void SetIsHidden(bool isHidden)
    {
        _isHidden = isHidden;
    }
    
    public void Hide()
    {
        _isHidden = true;
    }
    
    // a method to check the status of the word, therefore to show the text or "__"
    public string Display()
    {
        return _isHidden ? "___" : _text;
    }
}
