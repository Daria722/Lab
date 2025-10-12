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

    public List<Word> GetWords()
    {
        var words = new List<Word>();
        foreach (var item in _items)
        {
            if (item is Word word)
            {
                words.Add(word);
            }
        }

        return words;

    }
}