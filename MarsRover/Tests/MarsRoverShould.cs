using static MarsRover.Tests.CompassDirections;

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
    public void MoveOnYAxis(String command, String expectedResult)
    {
        marsRover.Execute(command).Should().Be(expectedResult);
    }
    
    [Theory]
    [InlineData("RM", "1:0:E")]
    public void MoveOnXAxis(String command, String expectedResult)
    {
        marsRover.Execute(command).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("R", "0:0:E")]
    [InlineData("RR", "0:0:S")]
    [InlineData("RRR", "0:0:W")]
    [InlineData("RRRR", "0:0:N")]
    public void RotateRight(string command, string expectedResult)
    {
        marsRover.Execute(command).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("L", "0:0:W")]
    [InlineData("LL", "0:0:S")]
    [InlineData("LLL", "0:0:E")]
    [InlineData("LLLL", "0:0:N")]
    public void RotateLeft(string command, string expectedResult)
    {
        marsRover.Execute(command).Should().Be(expectedResult);
    }
}

public class MarsRover
{
    public string Execute(string commands)
    {
        int y = 0;
        int x = 0;
        
        CompassDirections compass = N;

        foreach (char command in commands)
        {
            switch (command)
            {
                case 'M':
                    if (compass == N)
                        y++;
                    else
                        x++;
                    break;
                case 'L':
                    compass = compass.ToLeft();
                    break;
                case 'R':
                    compass = compass.ToRight();
                    break;
                default:
                    return "0:0:N";
            }
        }

        return $"{x}:{y}:{compass}";
    }
}

public static class CompassDirectionsExtensions
{
    public static CompassDirections ToRight(this CompassDirections current)
    {
        return current switch
        {
            N => E,
            S => W,
            E => S,
            W => N,
        };
    }

    public static CompassDirections ToLeft(this CompassDirections current)
    {
        return current switch
        {
            N => W,
            S => E,
            E => N,
            W => S,
        };
    }
}

public enum CompassDirections
{
    N,
    S,
    E,
    W
}