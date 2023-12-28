using System.Text.RegularExpressions;

namespace AdventOfCode_2023;

public partial class Day_02 : BaseDay
{
    private string[] _input;
    private sealed record GameSet(int Red, int Blue, int Green);
    private sealed record Game(int Id, List<GameSet> GameSets);


    [GeneratedRegex(@"(?<=Game\s)\d*")]
    private static partial Regex GameRegex();

    [GeneratedRegex(@"\d*(?=\sblue)")]
    private static partial Regex BlueRegex();

    [GeneratedRegex(@"\d*(?=\sred)")]
    private static partial Regex RedRegex();

    [GeneratedRegex(@"\d*(?=\sgreen)")]
    private static partial Regex GreenRegex();

    public Day_02()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new(Solve1().ToString());
    public override ValueTask<string> Solve_2() => new(Solve2().ToString());

    public int Solve1()
    {
        var validSet = new GameSet(Red: 12, Blue: 14, Green: 13);
        int sum = 0;
        foreach (var input in _input)
        {
            var game = ParseGame(input);
            bool isValid = true;
            foreach (var gameSet in game.GameSets)
            {
                if (gameSet.Red <= validSet.Red && gameSet.Blue <= validSet.Blue && gameSet.Green <= validSet.Green)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid) sum += game.Id;
        }
        return sum;
    }

    public int Solve2()
    {
        int sum = 0;
        foreach (var input in _input)
        {
            int redMax = 0, blueMax = 0, greenMax = 0;

            var game = ParseGame(input);

            foreach (var gameSet in game.GameSets)
            {
                if (gameSet.Red > redMax) redMax = gameSet.Red;
                if (gameSet.Blue > blueMax) blueMax = gameSet.Blue;
                if (gameSet.Green > greenMax) greenMax = gameSet.Green;

            }
            sum += redMax * blueMax * greenMax;
        }

        return sum;
    }

    private Game ParseGame(string input)
    {
        var parts = input.Split([';', ':']);
        var gameNumber = int.Parse(GameRegex().Match(parts[0]).Value);
        var gameSets = new List<GameSet>();
        for (int i = 1; i < parts.Length; i++)
        {
            int red = 0, blue = 0, green = 0;

            _ = int.TryParse(RedRegex().Match(parts[i]).Value, out red);
            _ = int.TryParse(BlueRegex().Match(parts[i]).Value, out blue);
            _ = int.TryParse(GreenRegex().Match(parts[i]).Value, out green);

            gameSets.Add(new GameSet(red, blue, green));
        }

        return new Game(gameNumber, gameSets);
    }

}

