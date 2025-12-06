namespace ToyRobot.Tests;

public class RobotTests
{
    [Fact]
    public void Example_A_PlaceMoveReport()
    {
        var robot = new Robot();
        robot.Place(0, 0, Direction.North);
        robot.Move();
        Assert.Equal("0,1,NORTH", robot.Report());
    }
    
    [Fact]
    public void Example_B_PlaceLeftReport()
    {
        var robot = new Robot();
        robot.Place(0, 0, Direction.North);
        robot.Left();
        Assert.Equal("0,0,WEST", robot.Report());
    }
    
    [Fact]
    public void Example_C_MultipleMoves()
    {
        var robot = new Robot();
        robot.Place(1, 2, Direction.East);
        robot.Move();
        robot.Move();
        robot.Left();
        robot.Move();
        Assert.Equal("3,3,NORTH", robot.Report());
    }
    
    [Fact]
    public void Example_D_PlaceWithoutDirection()
    {
        var robot = new Robot();
        robot.Place(1, 2, Direction.East);
        robot.Move();
        robot.Left();
        robot.Move();
        robot.Place(3, 1);
        robot.Move();
        Assert.Equal("3,2,NORTH", robot.Report());
    }
    
    [Fact]
    public void Place_OutsideTable_ReturnsFalse()
    {
        var robot = new Robot();
        Assert.False(robot.Place(10, 10, Direction.North));
        Assert.False(robot.IsPlaced);
    }
    
    [Fact]
    public void Place_NegativeCoordinates_ReturnsFalse()
    {
        var robot = new Robot();
        Assert.False(robot.Place(-1, 0, Direction.North));
        Assert.False(robot.IsPlaced);
    }
    
    [Fact]
    public void Move_BeforePlace_ReturnsFalse()
    {
        var robot = new Robot();
        Assert.False(robot.Move());
    }
    
    [Fact]
    public void Move_WouldFallOff_ReturnsFalse()
    {
        var robot = new Robot();
        robot.Place(0, 0, Direction.South);
        Assert.False(robot.Move());
        Assert.Equal("0,0,SOUTH", robot.Report());
    }
    
    [Fact]
    public void Left_BeforePlace_ReturnsFalse()
    {
        var robot = new Robot();
        Assert.False(robot.Left());
    }
    
    [Fact]
    public void Right_FullRotation()
    {
        var robot = new Robot();
        robot.Place(0, 0, Direction.North);
        robot.Right();
        Assert.Equal("0,0,EAST", robot.Report());
        robot.Right();
        Assert.Equal("0,0,SOUTH", robot.Report());
        robot.Right();
        Assert.Equal("0,0,WEST", robot.Report());
        robot.Right();
        Assert.Equal("0,0,NORTH", robot.Report());
    }
    
    [Fact]
    public void Report_BeforePlace_ReturnsNull()
    {
        var robot = new Robot();
        Assert.Null(robot.Report());
    }
}

