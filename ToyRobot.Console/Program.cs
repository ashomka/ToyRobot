using ToyRobot;

var simulator = new Simulator(Console.WriteLine);

while (Console.ReadLine() is { } line)
{
    simulator.Execute(line);
}
