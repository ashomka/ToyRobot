namespace ToyRobot;

public interface ICommand
{
    void Execute(Robot robot);
}

public class PlaceCommand : ICommand
{
    private readonly int _x, _y;
    private readonly Direction? _direction;
    
    public PlaceCommand(int x, int y, Direction? direction = null)
    {
        _x = x; 
        _y = y; 
        _direction = direction;
    }
    
    public void Execute(Robot robot) => robot.Place(_x, _y, _direction);
}

public class MoveCommand : ICommand
{
    public void Execute(Robot robot) => robot.Move();
}

public class LeftCommand : ICommand
{
    public void Execute(Robot robot) => robot.Left();
}

public class RightCommand : ICommand
{
    public void Execute(Robot robot) => robot.Right();
}

public class ReportCommand : ICommand
{
    private readonly Action<string> _output;
    
    public ReportCommand(Action<string> output) => _output = output;
    
    public void Execute(Robot robot)
    {
        var result = robot.Report();
        if (result != null) _output(result);
    }
}

