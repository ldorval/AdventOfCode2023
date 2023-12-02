namespace AdventOfCode2023.Day02;

public class Day02
{
    private static Dictionary<string, int> MaxCounts = new()
    {
        { "red", 12 }, { "green", 13 }, { "blue", 14 }
    };

    public static int Solve(List<string> input)
    {
        return input
            .Where(GameIsPossible)
            .Select(GetGameId)
            .Sum();
    }

    public static int SolvePart2(List<string> input)
    {
        return input
            .Select(GetGamePower)
            .Sum();
    }

    public static int GetGamePower(string line)
    {
        var colors = line.Split(":")[1].Split(";").Select(x => x.Trim())
            .SelectMany(x => x.Split(",").Select(y => y.Trim()))
            .Select(x => (Convert.ToInt32(x.Split(" ")[0]), x.Split(" ")[1]));

        return colors.Where(x => x.Item2 == "red").Select(x => x.Item1).Max() 
               * colors.Where(x => x.Item2 == "green").Select(x => x.Item1).Max() 
               * colors.Where(x => x.Item2 == "blue").Select(x => x.Item1).Max();
    }

    public static int GetGameId(string line) => Convert.ToInt32(line.Split(":")[0].Replace("Game ", ""));

    public static bool GameIsPossible(string line)
    {
        return line.Split(":")[1].Split(";").Select(x => x.Trim())
            .SelectMany(x => x.Split(",").Select(y => y.Trim()))
            .All(x => Convert.ToInt32(x.Split(" ")[0]) <= MaxCounts[x.Split(" ")[1]]);
    }
}