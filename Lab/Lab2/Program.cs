namespace Lab2;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game("1.ChaseData.txt", "1.PursuitLog.txt");
        game.Run();
    }
}