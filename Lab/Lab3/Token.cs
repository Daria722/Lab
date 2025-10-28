using System.Xml.Serialization;
namespace Lab3;

public class Token
{
    [XmlText]
    public string Value { get; set; } = "";
    
    // Метод для разделения текста на предложения
    public static List<string>  SplitIntoSentences(string text)
    {
        text = text.Replace("\r", " ").Replace("\n", " ");

        List<string> sentences = new List<string>();
        char[] Separators = {'.', '?', '!'};
        
        int start = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (Separators.Contains(text[i]))
            {
                if (i + 2 < text.Length && text[i] == '.' && text[i + 1] == '.' && text[i + 2] == '.')
                {
                    i += 2;
                    continue;
                }
                
                if (i + 1 < text.Length && Separators.Contains(text[i + 1]))
                    continue;
                
                int next = i + 1;
                while (next < text.Length && (text[next] == '"' || text[next] == '\'' || text[next] == ')' || text[next] == ' '))
                    next++;
                
                string sentence = text.Substring(start, i - start + 1).Trim();
                if (!string.IsNullOrEmpty(sentence))
                    sentences.Add(sentence);
                
                start = next;
                i = next - 1;
            }
        }
        if (start < text.Length)
        {
            string last = text.Substring(start).Trim();
            if (!string.IsNullOrEmpty(last))
            {
                sentences.Add(last);
            }
        }
        
        return sentences;
    }
    
    //Функция для разделения предложения на слова
    public static List <Token> ParseSentenceWords(string sentenceText)
    {
        List<Token> tokens = new List<Token>();
        string currentWord = "";

        char[] punctuationChars = { '.', ',', '?', '!', ';', ':', '-', '(', ')', '[', ']', '{', '}', '"', '\'' };
        for (int i = 0; i < sentenceText.Length; i++)
        {
            char c = sentenceText[i];
            if (char.IsLetterOrDigit(c) || c == '\'')
            {
                currentWord += c;
            }
            else
            {
                if (currentWord.Length > 0)
                {
                    tokens.Add(new Word(currentWord));
                    currentWord = "";
                }
                
                if (punctuationChars.Contains(c))
                {
                    tokens.Add(new Punctuation(c.ToString()));
                }
            }
        }
        if (currentWord.Length > 0)
            tokens.Add(new Word(currentWord));

        return tokens;
    }

    public static Text ParseText(string inputText)
    {
        Text text = new Text();
        text.OriginalText = inputText;
        
        List<string> sentenceStrings = Token.SplitIntoSentences(inputText);
        
        foreach (var sentenceStr in sentenceStrings)
        {
            Sentence s = new Sentence();
            List<Token> tokens = ParseSentenceWords(sentenceStr);
                
            foreach (var t in tokens) 
                s.AddToken(t);
            
            text.AddSentence(s);
        }
        
        return text;
    }
    
    public override string ToString()
    {
        return Value;
    }
}