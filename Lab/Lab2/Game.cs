using System;
using System.Collections.Generic;

namespace Lab2;

public enum GameState
{
    Start,
    End
}
public class Game
{
    private int size;
    private Player cat;
    private Player mouse;
    private GameState state;

    private List<(int catPos, int mousePas, int distance)> history;

    public Game(int size)
    {
        this.size = size;
        cat = new Player("Cat");
        mouse = new Player("Mouse");
        state = GameState.Start;
        history = new List<(int, int, int)>();
    }

    private int GetDistance()
    {
        if (cat.State == State.NotInGame || mouse.State == State.NotInGame)
            return -1;
        
    }

    public void Run()
    {
        Console.WriteLine("Cat and Mouse\n");
        Console.WriteLine("Введите команду (M x / C x)");
        Console.WriteLine("При завершении нажмите Q");
        Console.WriteLine("Начальная позиция кота: ");
        cat.SetPosition(int.Parse(Console.ReadLine()));
        
        Console.WriteLine("Начальная позиция мыши: ");
        mouse.SetPosition(int.Parse(Console.ReadLine()));
    }
}