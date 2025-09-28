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
    
    
}