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
    private string inputFile;
    private string outputFile;
    public Game(string inputFile, string outputFile)
    {
        this.inputFile = inputFile;
        this.outputFile = outputFile;
        cat = new Player("Cat");
        mouse = new Player("Mouse");
        state = GameState.Start;
        history = new List<(int, int, int)>();
    }

    private int GetDistance()
    {
        if (cat.State == State.NotInGame || mouse.State == State.NotInGame)
            return 0;
        
        return Math.Abs(cat.Location - mouse.Location);
    }

    private void SaveHistory()
    {
        int dist =GetDistance();
        history.Add((cat.State == State.NotInGame ? -1 : cat.Location, mouse.State== State.NotInGame ? -1 : mouse.Location, dist));
    }

    private bool IsCaught()
    {
        return cat.State == State.Playing && mouse.State == State.Playing &&cat.Location ==mouse.Location ;
    }
    public void Run()
    {
        string[] commands = File.ReadAllLines(inputFile);
        if (commands.Length == 0) return;

        size = int.Parse(commands[0]);
        
        for (int i = 1; i < commands.Length && state != GameState.End; i++)
        {
            string input = commands[i].Trim().ToUpper();
            if (string.IsNullOrWhiteSpace(input))
                continue;

            if (input == "W")
            {
                state = GameState.End;
                break;
            }

            if (input == "P")
            {
                SaveHistory();
                if (IsCaught()) state = GameState.End;
                continue;
            }

            string[] parts = input.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) continue;

            char command = parts[0][0];
            if (!int.TryParse(parts[1], out int steps))
                continue;

            switch (command)
            {
                case 'M':
                    if (mouse.State == State.NotInGame)
                        mouse.SetPosition(steps);
                    else
                    mouse.Move(steps, size);
                    break;
                
                case 'C':
                    if (cat.State == State.NotInGame)
                        cat.SetPosition(steps);
                    else
                    cat.Move(steps, size);
                    break;
            }

            if (IsCaught())
            {
                state = GameState.End;
            }
        }

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
        PrintTable(writer);
        PrintSummary(writer);
        }
    }
    
    private void PrintTable(StreamWriter writer)
    {
        writer.WriteLine("Cat and Mouse");
        writer.WriteLine("\nCat Mouse Distance");
        writer.WriteLine("------------------");

        foreach (var entry in history)
        {
            string catPos = entry.catPos == -1 ? "??" : entry.catPos.ToString();
            string mousePos = entry.mousePas == -1 ? "??" : entry.mousePas.ToString();
            string dist = (entry.catPos == -1 || entry.mousePas == -1) ? "" : entry.distance.ToString();
            writer.WriteLine($"{catPos, 3}{mousePos, 6}{dist, 9}");
        }
        writer.WriteLine("------------------");
    }
    private void PrintSummary(StreamWriter writer)
    {
        writer.WriteLine();
        writer.WriteLine();
        writer.WriteLine("Distance travelled: Mouse   Cat ");
        writer.WriteLine($"{mouse.DistanceTraveled, 24}{cat.DistanceTraveled, 7}");
        writer.WriteLine();
        
        if (IsCaught())
            writer.WriteLine($"Mouse caught at: {cat.Location}");
        else
            writer.WriteLine("Mouse evaded Cat");
        }
    }