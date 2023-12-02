using FluentAssertions;

namespace AdventOfCode2023.Day02;

public class Day02Test
{
    [Test]
    public void GetsGameId()
    {
        Day02.GetGameId("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red").Should().Be(4);
    }

    [Test]
    [TestCase("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
    [TestCase("Game 2: 16 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", false)]
    [TestCase("Game 2: 14 blue, 13 green, 12 red", true)]
    public void ValidatesIfGameIsPossible(string line, bool possible)
    {
        Day02.GameIsPossible(line).Should().Be(possible);
    }
    
    [Test]
    [TestCase("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
    [TestCase("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
    [TestCase("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
    [TestCase("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
    [TestCase("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
    public void CalculatesGamePower(string line, int power)
    {
        Day02.GetGamePower(line).Should().Be(power);
    }
    
    [Test]
    public void ExamplePart1()
    {
        Day02.Solve("Day02Example".ReadAll().AsListOfStrings()).Should().Be(8);
    }
    
    [Test]
    public void ExamplePart2()
    {
        Day02.SolvePart2("Day02Example".ReadAll().AsListOfStrings()).Should().Be(2286);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day02.Solve("Day02".ReadAll().AsListOfStrings()));
    }
    
    [Test]
    public void SolutionPart2()
    {
        Console.Write(Day02.SolvePart2("Day02".ReadAll().AsListOfStrings()));
    }
}