namespace Lab2;

public enum State
{
    Winner,
    Looser,
    Playing,
    NotInGame
}

public enum Anabolik
{
    Prinyat,
    NePrinyat
}

public class Player
{
    public string Name { get; }
    public int Location { get; private set; }
    public State State { get; set; }= State.NotInGame;
    public int DistanceTraveled { get; private set; }
    public Anabolik AnabolikState { get; private set; } = Anabolik.NePrinyat;

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
    
    public void Move(int steps, int boardSize)
    {
        if (State != State.Playing) return;
        
        Location = ((Location - 1 + steps) % boardSize + boardSize) % boardSize + 1;
        DistanceTraveled +=Math.Abs(steps);

        if (Name == "Mouse" && Location == 5)
        {
            AnabolikState = Anabolik.Prinyat;
        }
    }
}