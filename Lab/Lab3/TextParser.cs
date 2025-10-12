namespace Lab3;

public class TextParser
{
    public Text Parse(string inputText)
    {
        Text text = new Text();

        if (string.IsNullOrEmpty(inputText))
            return text;

        string[] sentencesStrings = SplitIntoSentences(inputText);
        
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

            
    }
}