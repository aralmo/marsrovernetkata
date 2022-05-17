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
}

public class MarsRover
{
    public string Execute(string command)
    {
        if (command == "M")
        {
            return "0:1:N";
        }

        return "0:0:N";
    }
}