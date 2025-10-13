namespace Lab3;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите текст для разделения на слова и предложения:\n ");

        string inputText = Console.ReadLine();
        TextParser parser = new TextParser();
        Text text = parser.Parse(inputText);
        
        Console.WriteLine($"\nРезультаты разделения:");
        Console.WriteLine($"Найдено предложений: {text.Sentences.Count}");
        
        text.PrintAllSentences();
        text.PrintAllWords();
        
        Console.WriteLine("\nНажмите любую клавишу для выхода");
        Console.ReadKey();
    }
}