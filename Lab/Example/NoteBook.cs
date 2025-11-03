// Производный от Item класс NoteBook
public class NoteBook : Item
{
    public int PageCount { get; private set; }

    // Конструктор с параметрами (исключаем дублирование кода базового класса)
    public NoteBook(int weight, int pageCount) : base(weight) // Вызов конструктора базового класса
    {
        if (pageCount <= 0)
            throw new ArgumentException("Количество страниц должно быть больше 0");
        PageCount = pageCount;
    }

    // Метод ToString() (исключаем дублирование кода базового класса)
    public override string ToString()
    {
        return $"Тетрадь - {base.ToString()}, Страниц: {PageCount}";
    }
}