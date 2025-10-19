using System.Xml.Serialization;
namespace Lab3;

public class Sentence
{
    [XmlElement("Word", Type = typeof(Word))]
    [XmlElement("Punctuation", Type = typeof(Punctuation))]
    public List<Token> Tokens { get; private set; }

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
        return Tokens.OfType<Word>().ToList();
    }
    
    public override string ToString()
    {
        var result = "";
        foreach (var token in Tokens)
        {
            if (token is Word)
            {
                if (!string.IsNullOrEmpty(result) && !result.EndsWith(" "))
                {               
                    result += " ";
                }
                result += token.ToString();
            }
            else if (token is Punctuation)
            {
                result += token.ToString();
            }
        }
        return result;
    }
}