using System.Xml.Serialization;
namespace Lab3;

public class Sentence
{
    [XmlElement("Word", Type = typeof(Word))]
    [XmlElement("Punctuation", Type = typeof(Punctuation))]
    public List<Token> Tokens { get; set; }

    public Sentence()
    {
        Tokens = new List<Token>();
    }

    public void AddToken(Token token)
    {
        Tokens.Add(token);
    }

    public List<Word> GetWords()
    {
        List<Word> result = new List<Word>();
        foreach (var token in Tokens)
        {
            if (token is Word word)
                result.Add(word);
        }
        return result;
    }
    
    public override string ToString()
    {
        string result = "";
        foreach (var token in Tokens)
        {
            if (token is Word)
            {
                if (result.Length > 0)
                result += " ";
                result += token.Value;
            }
            else if (token is Punctuation)
            {
                result += token.Value;
            }
        }
        return result.Trim();
    }
}