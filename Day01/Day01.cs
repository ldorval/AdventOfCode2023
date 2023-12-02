namespace AdventOfCode2023.Day01;

public class Day01
{
    public static int SolvePart1(List<string> input) => input.Sum(x => Convert.ToInt32(GetFirstDigit(x).ToString() + GetLastDigit(x)));

    public static object SolvePart2(List<string> input)
    {
        var cleanedInput = input.Select(CleanInput).ToList();
        return SolvePart1(cleanedInput);
    }

    public static int GetFirstDigit(string s) => s.First(Char.IsNumber) - '0';
    public static int GetLastDigit(string s) => s.Last(Char.IsNumber) - '0';

    public static string CleanInput(string s)
    {
        return s
            .Replace("one", "one1one")
            .Replace("two", "two2two")
            .Replace("three", "three3three")
            .Replace("four", "four4four")
            .Replace("five", "five5five")
            .Replace("six", "six6six")
            .Replace("seven", "seven7seven")
            .Replace("eight", "eight8eight")
            .Replace("nine", "nine9nine");
    }
}