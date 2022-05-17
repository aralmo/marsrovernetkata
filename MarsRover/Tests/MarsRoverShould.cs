namespace MarsRover.Tests;

public class MarsRoverShould
{
    private MarsRover marsRover = new MarsRover();

    [Fact]
    public void BeOnStartingPosition()
    {
        marsRover.Execute("").Should().Be("0:0:N");
    }

    [Fact]
    public void Move()
    {
        marsRover.Execute("M").Should().Be("0:1:N");
    }
    
    [Fact]
    public void RotateRight()
    {
        marsRover.Execute("R").Should().Be("0:0:E");
    }
    
    [Fact]
    public void RotateLeft()
    {
        marsRover.Execute("L").Should().Be("0:0:W");
    }
}

public class MarsRover
{
    public string Execute(string command)
    {
        if (command == "M")
        {
            return "0:1:N";
        }

        if (command == "R")
        {
            return "0:0:E";
        }

        return "0:0:N";
    }
}