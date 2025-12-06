# Toy Robot Simulator

A simulation of a toy robot moving on a 6x6 square tabletop.

## Build

```bash
dotnet build
```

## Run

```bash
dotnet run --project ToyRobot.Console
```

Then enter commands:
```
PLACE 0,0,NORTH
MOVE
REPORT
```

## Test

```bash
dotnet test
```

## Library Usage

```csharp
var simulator = new Simulator(output => Console.WriteLine(output));
simulator.Execute("PLACE 0,0,NORTH");
simulator.Execute("MOVE");
simulator.Execute("REPORT");  // outputs: 0,1,NORTH
```

## Commands

- `PLACE X,Y,DIRECTION` - Place robot at position (X,Y) facing NORTH/SOUTH/EAST/WEST
- `MOVE` - Move one unit forward
- `LEFT` - Rotate 90 degrees left
- `RIGHT` - Rotate 90 degrees right
- `REPORT` - Output current position and direction

