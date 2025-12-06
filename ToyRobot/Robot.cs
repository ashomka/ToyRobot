namespace ToyRobot;

public enum Direction { North, East, South, West }

public class Robot
{
    private const int TableSize = 6;
    
    public int? X { get; private set; }
    public int? Y { get; private set; }
    public Direction? Facing { get; private set; }
    
    public bool IsPlaced => X.HasValue;
    
    private bool IsValidPosition(int x, int y) 
        => x >= 0 && x < TableSize && y >= 0 && y < TableSize;
    
    public bool Place(int x, int y, Direction? direction = null)
    {
        if (!IsValidPosition(x, y))
            return false;
        
        if (!IsPlaced && !direction.HasValue)
            return false;
            
        X = x;
        Y = y;
        if (direction.HasValue)
            Facing = direction;
        return true;
    }
    
    public bool Move()
    {
        if (!IsPlaced) return false;
        
        int x = X!.Value, y = Y!.Value;
        var (newX, newY) = Facing switch
        {
            Direction.North => (x, y + 1),
            Direction.South => (x, y - 1),
            Direction.East => (x + 1, y),
            Direction.West => (x - 1, y),
            _ => (x, y)
        };
        
        if (!IsValidPosition(newX, newY))
            return false;
            
        X = newX;
        Y = newY;
        return true;
    }
    
    public bool Left()
    {
        if (!IsPlaced) return false;
        Facing = Facing switch
        {
            Direction.North => Direction.West,
            Direction.West => Direction.South,
            Direction.South => Direction.East,
            Direction.East => Direction.North,
            _ => Facing
        };
        return true;
    }
    
    public bool Right()
    {
        if (!IsPlaced) return false;
        Facing = Facing switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            Direction.West => Direction.North,
            _ => Facing
        };
        return true;
    }
    
    public string? Report()
    {
        if (!IsPlaced) return null;
        return $"{X},{Y},{Facing!.Value.ToString().ToUpper()}";
    }
}

