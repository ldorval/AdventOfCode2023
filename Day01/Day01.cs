namespace AdventOfCode2023.Day01;

public class Day01
{
    public static int Solve(List<string> input)
    {
        return input.Sum(x => Convert.ToInt32(GetFirstDigit(x).ToString() + GetLastDigit(x)));
    }

    public static int GetFirstDigit(string s) => s.First(Char.IsNumber) - '0';
    public static int GetLastDigit(string s) => s.Last(Char.IsNumber) - '0';
}