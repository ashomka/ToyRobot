namespace ToyRobot;

public class Simulator
{
    private readonly Robot _robot = new();
    private readonly Action<string> _output;
    
    public Simulator(Action<string> output)
    {
        _output = output;
    }
    
    public void Execute(string command)
    {
        var parsed = ParseCommand(command);
        parsed?.Execute(_robot);
    }
    
    private ICommand? ParseCommand(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;
            
        var parts = input.Trim().Split(' ', 2);
        var cmd = parts[0].ToUpper();
        
        return cmd switch
        {
            "PLACE" => ParsePlace(parts.Length > 1 ? parts[1] : ""),
            "MOVE" => new MoveCommand(),
            "LEFT" => new LeftCommand(),
            "RIGHT" => new RightCommand(),
            "REPORT" => new ReportCommand(_output),
            _ => null
        };
    }
    
    private static PlaceCommand? ParsePlace(string args)
    {
        var parts = args.Split(',');
        if (parts.Length < 2) return null;
        
        if (!int.TryParse(parts[0].Trim(), out int x) ||
            !int.TryParse(parts[1].Trim(), out int y))
            return null;
        
        Direction? dir = null;
        if (parts.Length > 2 && Enum.TryParse<Direction>(parts[2].Trim(), true, out var d))
            dir = d;
        
        return new PlaceCommand(x, y, dir);
    }
}

