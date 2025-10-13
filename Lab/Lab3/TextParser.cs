namespace Lab3;

public class TextParser
{
    public Text Parse(string inputText)
    {
        Text text = new Text();

        if (string.IsNullOrEmpty(inputText))
            return text;

        string[] sentenceStrings = SplitIntoSentences(inputText);
        
        foreach (string sentenceStr in sentenceStrings)
        {
            if (string.IsNullOrWhiteSpace(sentenceStr))
                continue;

            Sentence sentence = ParseSentence(sentenceStr);
            text.AddSentence(sentence);
        }
        
        return text;
    }
        // Функция для разделения текста на предложения
        string[] SplitIntoSentences(string text)
        {
            var sentences = new List<string>();
        
            int start = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '.' || text[i] == '!' || text[i] == '?')
                {
                    string sentence = text.Substring(start, i - start + 1).Trim();
                    if (!string.IsNullOrEmpty(sentence))
                    {
                        sentences.Add(sentence);
                    }
                    start = i + 1;
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
        
            return sentences.ToArray();
        }
        
        //Функция для разделения предложения на слова и знаки препинания
        private Sentence ParseSentence(string sentenceText)
        {
            Sentence sentence = new Sentence();
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
                        sentence.AddWord(new Word(currentWord));
                        currentWord = "";
                    }

                    if (!char.IsWhiteSpace(c))
                    {
                        sentence.AddPunctuation(new Punctuation(c.ToString()));
                    }
                }
            }

            if (!string.IsNullOrEmpty(currentWord))
            {
                sentence.AddWord(new Word(currentWord));
            }

            return sentence;
        }
}