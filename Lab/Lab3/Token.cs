namespace Lab3;

public class Token
{
    public string Value { get; protected set; }

    private static string _defaultText = "Привет!! Как дела? Это предложение... Разделение ";
    
    public static string GetText()
    {
        return _defaultText;
    }
    
    // Функция для разделения текста на предложения
    public static List<string>  SplitIntoSentences(string text)
    {
        var sentences = new List<string>();
        char[] sentenceSeparators = {'.', '?', '!', ';', '/'};
        
        int start = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (sentenceSeparators.Contains(text[i]))
            {
                int j = i;
                while (j < text.Length && sentenceSeparators.Contains(text[j]))
                {
                    j++;
                }
                
                string sentence = text.Substring(start, j - start).Trim();
                if (!string.IsNullOrEmpty(sentence))
                {
                    sentences.Add(sentence);
                }
                start = j;
                i = j + 1;
            }
        }
        if (start < text.Length)
        {
            string lastSentence = text.Substring(start).Trim();
            if (!string.IsNullOrEmpty(lastSentence))
            {
                sentences.Add(lastSentence);
            }
        }
        
        return sentences;
    }
    
    //Функция для разделения предложения на слова
    public static List <Word> ParseSentenceWords(string sentenceText)
    {
        var words = new List<Word>();
        string currentWord = "";

        for (int i = 0; i < sentenceText.Length; i++)
        {
            char c = sentenceText[i];
            if (char.IsLetterOrDigit(c) || c == '\'')
            {
                currentWord += c;
            }
            else
            {
                if (!string.IsNullOrEmpty(currentWord))
                {
                    words.Add(new Word(currentWord));
                    currentWord = "";
                }
            }
        }
        if (!string.IsNullOrEmpty(currentWord))
        {
            words.Add(new Word(currentWord));
        }

        return words;
    }

    public static Text ParseText()
    {
        Text text = new Text();
        string inputText = GetText();
        
        if (string.IsNullOrEmpty(inputText))
            return text;
        
        List<string> sentencesList = SplitIntoSentences(inputText);
        
        foreach (string sentenceStr in sentencesList)
        {
            if (string.IsNullOrWhiteSpace(sentenceStr))
                continue;

            Sentence sentence = ParseSentence(sentenceStr);
            text.AddSentence(sentence);
        }
        
        return text;
    }
    
    private static Sentence ParseSentence (string sentenceText)
    {
        Sentence sentence = new Sentence();
        List<Word> words = ParseSentenceWords(sentenceText);
        
        foreach (Word word in words)
        {
            sentence.AddToken(word);
        }
        
        foreach (char c in sentenceText)
        {
            char[] punctuationChars = { '.', '!', '?', ',', ';', ':', '-', '(', ')', '[', ']', '{', '}', '"', '\'' };
            if (punctuationChars.Contains(c))
            {
                sentence.AddToken(new Punctuation(c.ToString()));
            }
        }

        return sentence;
    }

    public override string ToString()
    {
        return Value;
    }
}