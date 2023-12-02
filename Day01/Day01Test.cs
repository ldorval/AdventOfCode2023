using FluentAssertions;

namespace AdventOfCode2023.Day01;

public class Day01Test
{
    private List<string> inputPart1 = new() { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };
    private List<string> inputPart2 = new() { "two1nine","eightwothree","abcone2threexyz","xtwone3four","4nineeightseven2", "zoneight234","7pqrstsixteen" };
    
    [Test]
    public void GetsFirstDigit()
    {
        Day01.GetFirstDigit("1abc2").Should().Be(1);
        Day01.GetFirstDigit("treb7uchet").Should().Be(7);
    }

    [Test]
    public void GetsLastDigit()
    {
        Day01.GetLastDigit("1abc2").Should().Be(2);
        Day01.GetLastDigit("treb7uchet").Should().Be(7);
    }

    [Test]
    public void CleansInput()
    {
        Day01.CleanInput("eightwothree").Should().Be("eight8eightwo2twothree3three");
        Day01.CleanInput("4nineeightseven2").Should().Be("4nine9nineeight8eightseven7seven2");
        Day01.CleanInput("7pqrstsixteen").Should().Be("7pqrstsix6sixteen");
    }
    
    [Test]
    public void ExamplePart1()
    {
        Day01.SolvePart1(inputPart1).Should().Be(142);
    }
    
    [Test]
    public void ExamplePart2()
    {
        Day01.SolvePart2(inputPart2).Should().Be(281);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day01.SolvePart1("Day01".ReadAll().LinesToString()));
    }
    
    [Test]
    public void SolutionPart2()
    {
        Console.Write(Day01.SolvePart2("Day01".ReadAll().LinesToString()));
    }
}