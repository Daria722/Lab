namespace Lab3;

public class Word : Token
{
    public Word(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}