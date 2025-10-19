namespace Lab3;

public class Punctuation : Token
{
    public Punctuation(string value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}