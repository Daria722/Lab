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
    
}