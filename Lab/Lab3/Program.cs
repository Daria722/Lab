namespace Lab3;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Реализация методов: ");
        Console.WriteLine("Выберите язык текста (ru/en): \n");
        string lang = Console.ReadLine()?.Trim().ToLower();

        string textFile = lang == "en" ? "sample_text_en.txt" : "sample_text_ru.txt";
        string stopFile = lang == "en" ? "stopwords_en.txt" : "stopwords_ru.txt";

        if (!File.Exists(textFile))
        {
            Console.WriteLine($"Файл {textFile} не найден");
            return;
        }

        string inputText = File.ReadAllText(textFile);
        Text text = Token.ParseText(inputText);
        
        Console.WriteLine($"Текст загружен из файла {textFile}");
        Console.WriteLine($"Найдено предложений: {text.Sentences.Count}\n");

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Вывести предложения по возрастанию количества слов");
            Console.WriteLine("2. Вывести предложения по возрастанию длины");
            Console.WriteLine("3. Найти слова заданной длины в вопросительных предложениях");
            Console.WriteLine("4. Удалить слова заданной длины, начинающиеся с согласной");
            Console.WriteLine("5. Заменить слова заданной длины в указанном предложении");
            Console.WriteLine("6. Удалить стоп-слова");
            Console.WriteLine("7. Экспортировать текст в XML");
            Console.WriteLine("0. Выход");
            Console.Write("Ваш выбор: ");

            string? choice = Console.ReadLine();
            string dir = Directory.GetCurrentDirectory();

            switch (choice)
            {
                case "1" :
                    text.RefreshSentencesFromOriginalText();
                    text.SortByWordCount(dir, lang);
                    break;
                case "2" :
                    text.RefreshSentencesFromOriginalText();
                    text.SortBySentenceLength(dir, lang);
                    break;
                case "3" :
                    text.RefreshSentencesFromOriginalText();
                    Console.Write("Введите длину слова для поиска: ");
                    int lenQ = int.Parse(Console.ReadLine());
                    text.GetQuestionWords(lenQ, dir, lang);
                    break;
                case "4" :
                    text.RefreshSentencesFromOriginalText();
                    Console.Write("Введите длину слова для удаления: ");
                    int lenR = int.Parse(Console.ReadLine());
                    text.RemoveWordsByLengthAndConsonant(lenR, dir, lang);
                    break;
                case "5":
                    text.RefreshSentencesFromOriginalText();
                    Console.Write("Введите номер предложения (начиная с 1): ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Введите длину слова для замены: ");
                    int lenReplace = int.Parse(Console.ReadLine());
                    Console.Write("Введите подстроку для замены: ");
                    string newStr = Console.ReadLine();
                    text.ReplaceWordsInSentence(index, lenReplace, newStr, dir, lang);
                    break;
                case "6" :
                    text.RefreshSentencesFromOriginalText();
                    var stopWords = Text.LoadStopWords(stopFile);
                    text.RemoveStopWords(stopWords, dir, lang);
                    break;
                case "7" :
                    text.RefreshSentencesFromOriginalText();
                    text.ExportToXml(dir, lang);
                    break;
                case "0" :
                    running = false;
                    break;
                default :
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }
        }
        
        Console.WriteLine("\nРабота завершена. Все результаты сохранены в папке проекта.");
    }
}