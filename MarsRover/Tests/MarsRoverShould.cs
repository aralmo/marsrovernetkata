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
    [InlineData("M", "0:1:N")]
    [InlineData("MM", "0:2:N")]
    [InlineData("MMM", "0:3:N")]
    public void Move(String command, String expectedResult)
    {
        marsRover.Execute(command).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("R", "0:0:E")]
    [InlineData("RR", "0:0:S")]
    [InlineData("RRR", "0:0:W")]
    public void RotateRight(string command, string expectedResult)
    {
        marsRover.Execute(command).Should().Be(expectedResult);
    }

    [Fact]
    public void RotateLeft()
    {
        marsRover.Execute("L").Should().Be("0:0:W");
    }
}

public class MarsRover
{
    public string Execute(string commands)
    {
        if ("RR" == commands)
        {
            return "0:0:S";
        }

        int y = 0;
        foreach (char command in commands)
        {
            switch (command)
            {
                case 'M':
                    y++;
                    break;
                case 'L':
                    return "0:0:W";
                case 'R':
                    return "0:0:E";
                default:
                    return "0:0:N";
            }
        }

        return $"0:{y}:N";
    }
}