using ToyRobot;

namespace ToyRobot.Tests;

public class SimulatorTests
{
    private readonly List<string> _output = new();
    private readonly Simulator _simulator;
    
    public SimulatorTests()
    {
        _simulator = new Simulator(s => _output.Add(s));
    }
    
    [Fact]
    public void Example_A()
    {
        _simulator.Execute("PLACE 0,0,NORTH");
        _simulator.Execute("MOVE");
        _simulator.Execute("REPORT");
        
        Assert.Single(_output);
        Assert.Equal("0,1,NORTH", _output[0]);
    }
    
    [Fact]
    public void Example_B()
    {
        _simulator.Execute("PLACE 0,0,NORTH");
        _simulator.Execute("LEFT");
        _simulator.Execute("REPORT");
        
        Assert.Single(_output);
        Assert.Equal("0,0,WEST", _output[0]);
    }
    
    [Fact]
    public void Example_C()
    {
        _simulator.Execute("PLACE 1,2,EAST");
        _simulator.Execute("MOVE");
        _simulator.Execute("MOVE");
        _simulator.Execute("LEFT");
        _simulator.Execute("MOVE");
        _simulator.Execute("REPORT");
        
        Assert.Single(_output);
        Assert.Equal("3,3,NORTH", _output[0]);
    }
    
    [Fact]
    public void Example_D()
    {
        _simulator.Execute("PLACE 1,2,EAST");
        _simulator.Execute("MOVE");
        _simulator.Execute("LEFT");
        _simulator.Execute("MOVE");
        _simulator.Execute("PLACE 3,1");
        _simulator.Execute("MOVE");
        _simulator.Execute("REPORT");
        
        Assert.Single(_output);
        Assert.Equal("3,2,NORTH", _output[0]);
    }
    
    [Fact]
    public void CommandsBeforePlace_AreIgnored()
    {
        _simulator.Execute("MOVE");
        _simulator.Execute("LEFT");
        _simulator.Execute("REPORT");
        
        Assert.Empty(_output);
    }
    
    [Fact]
    public void InvalidCommands_AreIgnored()
    {
        _simulator.Execute("PLACE 0,0,NORTH");
        _simulator.Execute("JUMP");
        _simulator.Execute("FLY");
        _simulator.Execute("");
        _simulator.Execute("   ");
        _simulator.Execute("REPORT");
        
        Assert.Single(_output);
        Assert.Equal("0,0,NORTH", _output[0]);
    }
    
    [Fact]
    public void CaseInsensitive()
    {
        _simulator.Execute("place 0,0,north");
        _simulator.Execute("move");
        _simulator.Execute("report");
        
        Assert.Single(_output);
        Assert.Equal("0,1,NORTH", _output[0]);
    }
}

