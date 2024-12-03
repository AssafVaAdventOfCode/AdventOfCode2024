namespace AdventOfCode2024;

public static class Core
{
    public static IEnumerable<string> GetInputLines(int day, int? test = null)
    {
        var testString = test is null ? string.Empty : $".t{test}";
        return File.ReadLines($"Inputs/d{day.ToString().PadLeft(2, '0')}/input{testString}.txt");
    }
}
