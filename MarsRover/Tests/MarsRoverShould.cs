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

    [Theory]
    [InlineData("L","0:0:W")]
    [InlineData("LL","0:0:S")]
    [InlineData("LLL","0:0:E")]
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
        CompassDirections compass = CompassDirections.N;
        
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
                    compass = compass switch
                    {
                        CompassDirections.N => CompassDirections.E,
                        CompassDirections.S => CompassDirections.W,
                        CompassDirections.E => CompassDirections.S,
                        CompassDirections.W => CompassDirections.N,
                    };
                    break;
                default:
                    return "0:0:N";
            }
        }

        return $"0:{y}:{compass}";
    }

    private enum CompassDirections
    {
        N,
        S,
        E,
        W
    }
}