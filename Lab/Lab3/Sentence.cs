namespace Lab3;

public class Sentence
{
    private List<object> _items;

    public Sentence()
    {
        _items = new List<object>();
    }

    public void AddWord(Word word)
    {
        _items.Add(word);
    }

    public void AddPunctuation(Punctuation punctuation)
    {
        _items.Add(punctuation);
    }
    
    
}