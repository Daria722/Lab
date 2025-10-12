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
    
    
}