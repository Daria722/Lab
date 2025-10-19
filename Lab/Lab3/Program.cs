namespace Lab3;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Разделение текста на слова и предложения: ");
        
        Text text = Token.ParseText();
        
        Console.WriteLine("\nРезультаты разделения:");
        Console.WriteLine($"Найдено предложений: {text.Sentences.Count}");
        
        text.PrintAllSentences();
        text.PrintAllWords();
        
        text.ExportToXml("text_export.xml");
        
        Console.WriteLine("\nНажмите любую клавишу для выхода");
        Console.ReadKey();
    }
}