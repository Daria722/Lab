namespace Lab3;

public class Text
{
    public List<Sentence> Sentences { get; private set; }

    public Text()
    {
        Sentences = new List<Sentence>();
    }

    public void AddSentence(Sentence sentence)
    {
        Sentences.Add(sentence);
    }

    public void PrintAllSentences()
    {
        Console.WriteLine("\nВсе предложения: ");
        for (int i = 0; i < Sentences.Count; i++)
        {
            Console.WriteLine($"Предложение {i+1}: {Sentences[i]}");
        }
    }

    public void PrintAllWords()
    {
        Console.WriteLine("\nВсе слова текста: ");
        foreach (var sentence in Sentences)
        {
            foreach (var word in sentence.GetWords())
            {
                Console.WriteLine($"Слово: {word}");
            }
        }
    }
}