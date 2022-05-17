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
}


public class MarsRover
{
    public string Execute(string command)
        => "0:0:N";
}