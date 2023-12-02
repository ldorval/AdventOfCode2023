using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2023.Day01;

public class Day01Test
{
    private List<string> input = new() { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };

    [Test]
    public void GetsFirstDigit()
    {
        Day01.GetFirstDigit("1abc2").Should().Be(1);
        Day01.GetFirstDigit("pqr3stu8vwx").Should().Be(3);
        Day01.GetFirstDigit("a1b2c3d4e5f").Should().Be(1);
        Day01.GetFirstDigit("treb7uchet").Should().Be(7);
    }

    [Test]
    public void GetsLastDigit()
    {
        Day01.GetLastDigit("1abc2").Should().Be(2);
        Day01.GetLastDigit("pqr3stu8vwx").Should().Be(8);
        Day01.GetLastDigit("a1b2c3d4e5f").Should().Be(5);
        Day01.GetLastDigit("treb7uchet").Should().Be(7);
    }
    
    [Test]
    public void ExamplePart1()
    {
        Day01.Solve(input).Should().Be(142);
    }

    [Test]
    public void SolutionPart1()
    {
        Console.Write(Day01.Solve("Day01".ReadAll().LinesToString()));
    }
}