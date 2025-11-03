// Производный от Item класс TextBook
public class TextBook : Item
{
    public string Subject { get; private set; }

    // Конструктор с параметрами (исключаем дублирование кода базового класса)
    public TextBook(int weight, string subject) : base(weight) // Вызов конструктора базового класса
    {
        if (string.IsNullOrWhiteSpace(subject))
            throw new ArgumentException("Название предмета не может быть пустым");
        Subject = subject;
    }

    // Метод ToString() (исключаем дублирование кода базового класса)
    public override string ToString()
    {
        return $"Учебник - {base.ToString()}, Предмет: {Subject}";
    }
}