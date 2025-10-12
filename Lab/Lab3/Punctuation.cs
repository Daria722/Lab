namespace Lab3;

public class Punctuation
{
    public string Value { get; private set; }

    public Punctuation(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}