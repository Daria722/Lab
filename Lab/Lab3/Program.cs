namespace Lab3;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите текст для разделения на слова и предложения: ");

        string inputText = Console.ReadLine();
        
        TextParser parser = new TextParser();
        Text text = parser.Parse(inputText);
    }
}