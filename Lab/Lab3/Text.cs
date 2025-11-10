using System.Xml.Serialization;
namespace Lab3;

[XmlRoot("Text")]

public class Text
{
    [XmlElement("Sentence")]
    public List<Sentence> Sentences { get; set; }
    
    [XmlIgnore]
    public string OriginalText  { get; set; }

    public Text(string originalText) : this()
    {
        OriginalText = originalText;
    }
    
    public Text()
    {
        Sentences = new List<Sentence>();
        OriginalText = string.Empty;
    }

    public void AddSentence(Sentence sentence)
    {
        Sentences.Add(sentence);
    }
    
    private void ParseOriginalText()
    {
        if (string.IsNullOrEmpty(OriginalText)) return;

        var sentenceStrings = Token.SplitIntoSentences(OriginalText);
        foreach (var str in sentenceStrings)
        {
            var s = new Sentence();
            var tokens = Token.ParseSentenceWords(str);
            foreach (var t in tokens)
                s.AddToken(t);
            Sentences.Add(s);
        }
    }
    
    // Загрузка стоп-слов из файла
    public static HashSet<string> LoadStopWords(string path)
    {
        HashSet<string> stopWords = new HashSet<string>();
        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string word = line.Trim().ToLower();
                if (word.Length > 0)
                    stopWords.Add(word);
            }
        }
        return stopWords;
    }
    
    public void RefreshSentencesFromOriginalText()
    {
        Sentences.Clear();
        ParseOriginalText();
    }

    // 1. Сортировка по количеству слов
        public void SortByWordCount(string dir, string lang)
        {
            List<Sentence> sorted = new List<Sentence>(Sentences);
            sorted.Sort((s1, s2) =>  s1.GetWords().Count.CompareTo(s2.GetWords().Count));

            string path = Path.Combine(dir, $"1_sorted_by_wordcount_{lang}.txt");
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Sentence s in sorted)
                {
                    sw.WriteLine(s.ToString());
                }
            }
            Console.WriteLine($"Результат сохранён: 1_sorted_by_wordcount_{lang}.txt");
        }

        // 2. Сортировка по длине предложения
        public void SortBySentenceLength(string dir, string lang)
        {
            List<Sentence> sorted = new List<Sentence>(Sentences);
            sorted.Sort((s1, s2) =>  s1.ToString().Length.CompareTo(s2.ToString().Length));

            string path = Path.Combine(dir, $"2_sorted_by_length_{lang}.txt");
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Sentence s in sorted)
                {
                    sw.WriteLine(s.ToString());
                }
            }
            Console.WriteLine($"Результат сохранён: 2_sorted_by_length_{lang}.txt");
        }

        // 3. Слова заданной длины в вопросительных предложениях
        public void GetQuestionWords(int length, string dir, string lang)
        {
            HashSet<string> words = new HashSet<string>();

            foreach (Sentence sentence in Sentences)
            {
                string text = sentence.ToString().Trim();
                if (text.EndsWith("?"))
                {
                    foreach (Word w in sentence.GetWords())
                    {
                        if (w.Value.Length == length)
                            words.Add(w.Value.ToLower());
                    }
                }
            }

            string path = Path.Combine(dir, $"3_question_words_{lang}.txt");
            File.WriteAllLines(path, words);
            Console.WriteLine($"Результат сохранён: 3_question_words_{lang}.txt");
        }
    
        // 4. Удалить слова заданной длины, начинающиеся с согласной
        public void RemoveWordsByLengthAndConsonant(int length, string dir, string lang)
        {
            string consonants = "бвгджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxyz";

            foreach (Sentence sentence in Sentences)
            {
                List<Token> newTokens = new List<Token>();
                foreach (Token token in sentence.Tokens)
                {
                    if (token is Word w)
                    {
                        char first = char.ToLower(w.Value[0]);
                        if (w.Value.Length == length && consonants.Contains(first))
                            continue;
                    }
                    newTokens.Add(token);
                }
                sentence.Tokens = newTokens;
                sentence.Words = sentence.GetWords();
            }

            string path = Path.Combine(dir, $"4_removed_words_{lang}.txt");
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Sentence s in Sentences)
                {
                    sw.WriteLine(s.ToString());
                }
            }
            Console.WriteLine($"Результат сохранён: 4_removed_words_{lang}.txt");
        }

        // 5. Заменить слова заданной длины в указанном предложении
        public void ReplaceWordsInSentence(int index, int length, string newString, string dir, string lang)
        {
            if (index < 0 || index >= Sentences.Count)
            {
                Console.WriteLine("Некорректный номер предложения.");
                //throw new ArgumentException("Некорректный номер");
                return;
            }

            Sentence sentence = Sentences[index];
            foreach (Word w in sentence.GetWords())
            {
                if (w.Value.Length == length)
                    w.Value = newString;
            }

            string path = Path.Combine(dir, $"5_replaced_{lang}.txt");
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Sentence s in Sentences)
                {
                    sw.WriteLine(s.ToString());
                }
            }
            Console.WriteLine($"Результат сохранён: 5_replaced_{lang}.txt");
        }

        // 6. Удалить стоп-слова
        public void RemoveStopWords(HashSet<string> stopWords, string dir, string lang)
        {
            foreach (Sentence sentence in Sentences)
            {
                List<Token> newTokens = new List<Token>();
                foreach (Token token in sentence.Tokens)
                {
                    if (token is Word w)
                    {
                        if (stopWords.Contains(w.Value.ToLower()))
                            continue;
                    }
                    newTokens.Add(token);
                }
                sentence.Tokens = newTokens;
                sentence.Words = sentence.GetWords();
            }

            string path = Path.Combine(dir, $"6_no_stopwords_{lang}.txt");
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Sentence s in Sentences)
                {
                    sw.WriteLine(s.ToString());
                }
            }
            Console.WriteLine($"Результат сохранён: 6_no_stopwords_{lang}.txt");
        }
    
    // 7. Метод экспорта в XML
    public void ExportToXml(string path, string lang)
    {
        string filename = $"exported_text_{lang}.xml";
        string fullPath = Path.Combine(path, filename);
        
        XmlSerializer serializer = new XmlSerializer(typeof(Text));
        using (StreamWriter writer = new StreamWriter(fullPath))
        {
            serializer.Serialize(writer, this);
        }
        Console.WriteLine($"Текст экспортирован в: {filename}");
    }
    
    // 8. Метод для построения конкорданса
    public void BuildConcordance(string dir, string lang)
    {
        Dictionary<string, (int count, SortedSet<int> lines)> concordance = new Dictionary<string, (int, SortedSet<int>)>();
        
       // Dictionary<int, string> ggg = new Dictionary<int, string>();
       //Dictionary<string, int> newDict = new Dictionary<string, int>();
       //foreach (var item in ggg)
       //{
       //    newDict[item.Value] = item.Key;
       //}
       
        // Обрабатываем каждое предложение
        for (int i = 0; i < Sentences.Count; i++)
        {
            int lineNumber = i + 1;
            Sentence sentence = Sentences[i];
            
            foreach (Word word in sentence.GetWords())
            {
                string wordKey = word.Value.ToLower();
            
                if (!concordance.ContainsKey(wordKey))
                {
                    concordance[wordKey] = (0, new SortedSet<int>());
                }
                
                // Увеличиваем счетчик и добавляем номер строки
                concordance[wordKey].lines.Add(lineNumber);
                var current = concordance[wordKey];
                concordance[wordKey] = (current.count + 1, current.lines); 
            }
        }

        List<string> allWords = new List<string>(concordance.Keys);
        allWords.Sort();
        
    
        string path = Path.Combine(dir, $"concordance_{lang}.txt");
        using (StreamWriter sw = new StreamWriter(path))
        {
            char currentLetter = '\0';
            
            foreach (string word in allWords)
            {
                char start_simb = word[0];
                
                if (start_simb != currentLetter)
                {
                    if (currentLetter != '\0')
                    {
                        sw.WriteLine();
                    }
                    
                    currentLetter = start_simb;
                    sw.WriteLine(currentLetter.ToString().ToUpper() + ":");
                }
                
                var (count, lines) = concordance[word];
                string lineNumbers = string.Join(" ", lines);
                sw.WriteLine($"{word.PadRight(28)}{count}: {lineNumbers}");
            }
        }
    
        Console.WriteLine($"Конкорданс сохранён: concordance_{lang}.txt");
    }
}
