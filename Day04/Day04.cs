namespace AdventOfCode2023.Day04;

public class Day04
{
    public static int Solve(List<string> input)
    {
        return input
            .Select(ExtractCard)
            .Select(x => GetCardScore(MatchingNumbersCount(x)))
            .Sum();
    }

    public static int SolvePart2(List<string> input)
    {
        var cardsIdCount = input.Select(ExtractCard).ToDictionary(x => x.Id, _ => 1);

        foreach (var card in input.Select(ExtractCard))
        {
            for (var i = 1; i <= MatchingNumbersCount(card); i++)
            {
                cardsIdCount[card.Id + i] += cardsIdCount[card.Id];
            }
        }

        return cardsIdCount.Sum(x => x.Value);
    }

    private static int MatchingNumbersCount(Card x) => x.Numbers.Intersect(x.WinningNumbers).Count();
    public static int GetCardScore(int matchingNumbersCount) => (int)Math.Pow(2, matchingNumbersCount - 1);

    public static Card ExtractCard(string line)
    {
        var numbers = line.Split(":")[1];
        var split = numbers.Split("|");
        return new Card(
            Convert.ToInt32(line.Split(":")[0].Replace("Card ", "")),
            split[0].Trim().Split(" ").Where(x => x != "").Select(x => Convert.ToInt32(x)).ToList(),
            split[1].Trim().Split(" ").Where(x => x != "").Select(x => Convert.ToInt32(x)).ToList()
        );
    }

    public record Card(int Id, List<int> WinningNumbers, List<int> Numbers);
}