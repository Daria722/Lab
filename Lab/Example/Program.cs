class Program
{
    static void Main(string[] args)
    {
        SchoolBag bag = new SchoolBag();

        // Добавляем учебники и тетради
        bag.Add(new NoteBook(100, 48));
        bag.Add(new NoteBook(80, 24));
        bag.Add(new TextBook(500, "Математика"));
        bag.Add(new TextBook(450, "Русский язык"));
        bag.Add(new TextBook(600, "Физика"));
        bag.Add(new NoteBook(120, 96));

        Console.WriteLine("Исходное содержимое рюкзака:");
        Console.WriteLine(bag.ToString());

        // Сортируем содержимое по весу
        bag.SortByWeight();
        Console.WriteLine("После сортировки по весу:");
        Console.WriteLine(bag.ToString());

        // Проверяем вес и удаляем самый тяжелый компонент если превышает 3 кг
        const int MAX_WEIGHT = 3000;
        if (bag.Weight > MAX_WEIGHT)
        {
            Console.WriteLine($"Вес рюкзака ({bag.Weight}г) превышает 3 кг");
            bag.RemoveHeaviest();
            Console.WriteLine("Удален самый тяжелый компонент");
            Console.WriteLine(bag.ToString());
        }

        // Проверяем наличие учебника по математике
        bool hasMath = bag.HasMathTextbook();
        Console.WriteLine($"В рюкзаке {(hasMath ? "есть" : "нет")} учебник по математике");
        
        Console.WriteLine("\nФинальное содержимое рюкзака:");
        Console.WriteLine(bag.ToString());
    }
}