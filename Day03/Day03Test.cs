using FluentAssertions;

namespace AdventOfCode2023.Day03;

public class Day03Test
{
    [Test]
    [TestCase('.', false)]
    [TestCase(',', true)]
    [TestCase('3', false)]
    [TestCase('$', true)]
    [TestCase('#', true)]
    public void ChecksIfCharIsSymbol(char c, bool expected)
    {
        Day03.IsSymbol(c).Should().Be(expected);
    }

    [Test]
    public void BuildsNumberCoordinates()
    {
        var input = "467..114..\r\n...*......\r\n..35..633.\r\n......#..".AsListOfStrings();
        var coordinates = Day03.BuildNumberCoordinates(input);

        coordinates.Should().BeEquivalentTo(new List<Day03.NumberCoordinates>
        {
            new(467, 0, 0),
            new(114, 5, 0),
            new(35, 2, 2),
            new(633, 6, 2)
        });
    }

    [Test]
    public void ExamplePart1()
    {
        Day03.Solve("Day03Example".ReadAll().AsListOfStrings()).Should().Be(4361);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day03.Solve("Day03".ReadAll().AsListOfStrings()));
    }

    [Test]
    public void ExamplePart2()
    {
        Day03.SolvePart2("Day03Example".ReadAll().AsListOfStrings()).Should().Be(467835);
    }
    
    [Test]
    public void SolutionPart2()
    {
        Console.Write(Day03.SolvePart2("Day03".ReadAll().AsListOfStrings()));
    }
}