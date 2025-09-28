using System;

namespace Lab2;

public enum State
{
    Winner,
    Looser,
    Playing,
    NotInGame
}

public class Player
{
    public string Name { get; }
    public int Location { get; private set; }
    public State State { get; set; }= State.NotInGame;
    public int DistanceTraveled { get; private set; }

    public Player(string name)
    {
        Name = name;
        Location = -1;
    }

    public void SetPosition(int pos)
    {
        Location = pos;
        State = State.Playing;
    }
    
    public void Move(int steps, int size)
    {
        if (State == State.NotInGame) return;

        Location = (Location + steps) % size;
        if (Location < 0) Location += size;
        
        DistanceTraveled +=Math.Abs(steps);
    }
}