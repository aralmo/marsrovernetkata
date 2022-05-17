namespace MarsRover.Tests;

public class MarsRoverShould
{
    private MarsRover marsRover = new MarsRover();

    [Fact]
    public void BeOnStartingPosition()
    {
        marsRover.Execute("").Should().Be("0:0:N");
    }

    [Theory]
    [InlineData("M","0:1:N")]
    [InlineData("MM","0:2:N")]
    public void Move(String command,String expectedResult)
    {
        marsRover.Execute(command).Should().Be(expectedResult);
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
        return command switch
        {
            "M" => "0:1:N",
            "L" => "0:0:W",
            "R" => "0:0:E",
            _ => "0:0:N"
        };
    }
}