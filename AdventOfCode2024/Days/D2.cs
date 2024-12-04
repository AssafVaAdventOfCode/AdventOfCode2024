using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2024.Days;

// not my best work, but I've spent too long on it already :/
public class D2 : AocDay
{
    public (string a, string b) RunDay()
    {
        //var lines = Core.GetInputLines(2, 1);
        var lines = Core.GetInputLines(2);

        int sumA = 0;
        int sumB = 0;

        foreach (var line in lines)
        {
            var digits = line.SplitWhiteSpace().Select(int.Parse).ToList();

            sumA += A(digits);
            sumB += B(digits);
        }

        return (sumA.ToString(), sumB.ToString());
    }

    private int AIncreasing(List<int> digits)
    {
        for (int i = 1; i < digits.Count; i++)
        {
            var difference = digits[i-1] - digits[i];
            if (difference <= 0 || int.Abs(difference) > 3)
            {
                return 0;
            }
        }

        return 1;
    }

    private int ADecreasing(List<int> digits)
    {
        for (int i = 1; i < digits.Count; i++)
        {
            var difference = digits[i-1] - digits[i];
            if (difference >= 0 || int.Abs(difference) > 3)
            {
                return 0;
            }
        }

        return 1;
    }

    private int A(List<int> digits)
    {
        if (AIncreasing(digits) == 1 && ADecreasing(digits) == 1) Console.WriteLine($"WTF {string.Join(',', digits)}");
        return AIncreasing(digits) + ADecreasing(digits);
    }

    private int B(List<int> digits)
    {
        if (A(digits) == 1)
        {
            return 1;
        }

        for (int i = 0; i < digits.Count; i++)
        {
            var copy = new List<int>(digits);
            copy.RemoveAt(i);

            if (A(copy) == 1)
            {
                return 1;
            }
        }

        return 0;
    }
}
