namespace Lab3;

public class Word
{
    public string Value { get; private set; }

    public Word(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}