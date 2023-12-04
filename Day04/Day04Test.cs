using FluentAssertions;

namespace AdventOfCode2023.Day04;

public class Day04Test
{
    [Test]
    public void ExamplePart1() => Day04.Solve("Day04Example".ReadAll().AsListOfStrings()).Should().Be(13);

    [Test]
    public void ExamplePart2() => Day04.SolvePart2("Day04Example".ReadAll().AsListOfStrings()).Should().Be(30);

    [Test]
    public void SolutionPart1() => Console.Write(Day04.Solve("Day04".ReadAll().AsListOfStrings()));

    [Test]
    public void SolutionPart2() => Console.Write(Day04.SolvePart2("Day04".ReadAll().AsListOfStrings()));

    [Test]
    public void ExtractsCardFromLine()
    {
        Day04.ExtractCard("Card 32: 41 48 83 86 17 | 83 86  6 31 17  9 48 53").Should().BeEquivalentTo(new Day04.Card(
            32, new List<int> { 41, 48, 83, 86, 17 }, new List<int> { 83, 86, 6, 31, 17, 9, 48, 53 })
        );
    }

    [Test]
    public void GetsCardScore()
    {
        Day04.GetCardScore(1).Should().Be(1);
        Day04.GetCardScore(2).Should().Be(2);
        Day04.GetCardScore(4).Should().Be(8);
        Day04.GetCardScore(5).Should().Be(16);
    }
}