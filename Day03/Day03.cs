using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day03;

public class Day03
{
    public static int Solve(List<string> input)
    {
        return BuildNumberCoordinates(input)
            .Where(x => GetNeighbors(x, input).Any(p => IsSymbol(input[p.Y][p.X])))
            .Sum(x => x.Number);
    }
    
    public static int SolvePart2(List<string> input)
    {
        return BuildNumberCoordinates(input)
            .Select(x => GetGearCoortinate(x, GetNeighbors(x, input), input))
            .Where(x => !x.GearCoordinate.IsEmpty)
            .GroupBy(x => x.GearCoordinate)
            .Where(x => x.Count() == 2)
            .Select(x => x.ElementAt(0).Number * x.ElementAt(1).Number)
            .Sum();
    }

    private static GearNumber GetGearCoortinate(NumberCoordinates coordinate, List<Point> neighbors, List<string> input)
    {
        var gear = neighbors.FirstOrDefault(p => input[p.Y][p.X] == '*');
        return new GearNumber(coordinate.Number, new Point(gear.X, gear.Y));
    }

    public static List<Point> GetNeighbors(NumberCoordinates coordinate, List<string> input)
    {
        var neighbors = new List<Point>();
        for (var i = 0; i < coordinate.Number.ToString().Length; i++)
        {
            var x = coordinate.X + i;
            neighbors.AddRange(CoordinateHelper.GetNeighboringPoints(x, coordinate.Y).Where(p => IsWithinBounds(p, input)));
        }

        return neighbors;
    }

    public static bool IsSymbol(char c) => c != '.' && !Char.IsNumber(c);

    public static List<NumberCoordinates> BuildNumberCoordinates(List<string> input)
    {
        var regEx = new Regex(@"\d+");
        var numberCoordinates = new List<NumberCoordinates>();
        var y = 0;
        foreach (var line in input)
        {
            numberCoordinates.AddRange(regEx.Matches(line).Select(x => new NumberCoordinates(Convert.ToInt32(x.Value), Convert.ToInt32(x.Index), y)));
            y++;
        }

        return numberCoordinates;
    }

    public static bool IsWithinBounds(Point point, List<string> input) => CoordinateHelper.IsWithinBounds(point.X, point.Y, 0, 0, input.First().Length - 1, input.Count - 1);
    
    public record NumberCoordinates(int Number, int X, int Y);

    public record GearNumber(int Number, Point GearCoordinate);
}