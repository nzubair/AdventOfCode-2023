namespace AdventOfCode_2023;

public class Day_01 : BaseDay
{
    private string[] _input;

    public Day_01()
    {
        _input = File.ReadAllLines(InputFilePath);
    }

    public override ValueTask<string> Solve_1() => new(Solve1().ToString());

    public override ValueTask<string> Solve_2() => new(Solve2().ToString());

    public static string StringToNumber(string input)
    {
        return input.Replace("one", "o1e")
                          .Replace("two", "t2o")
                          .Replace("three", "t3e")
                          .Replace("four", "f4r")
                          .Replace("five", "f5e")
                          .Replace("six", "s6x")
                          .Replace("seven", "s7n")
                          .Replace("eight", "e8t")
                          .Replace("nine", "n9e");
    }

    public int Solve1()
    {
        int sum = 0;
        foreach (var line in _input)
        {
            var first = line.First(Char.IsDigit);
            var last = line.Last(Char.IsDigit);
            var num = int.Parse($"{first}{last}");
            sum += num;
        }

        return sum;
    }

    public int Solve2()
    {

        int sum = 0;

        foreach (var line in _input)
        {
            string converted = StringToNumber(line);
            var first = converted.First(Char.IsDigit);
            var last = converted.Last(Char.IsDigit);
            var num = int.Parse($"{first}{last}");
            sum += num;
        }
        return sum;
    }

}

