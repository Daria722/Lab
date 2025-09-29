namespace Lab2;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите размер поля: ");
        int size = int.Parse(Console.ReadLine());

        Game game = new Game(size);
        game.Run();
    }
}