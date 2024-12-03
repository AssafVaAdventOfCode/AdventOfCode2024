using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2024.Days;

public class D1 : AocDay
{
    public (string a, string b) RunDay()
    {
        //var lines = Core.GetInputLines(1, 1);
        var lines = Core.GetInputLines(1);

        var lhsGroup = new SortedDictionary<int, int>();
        var rhsGroup = new SortedDictionary<int, int>();

        var tuples = lines
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .Select(arr => (int.Parse(arr[0]), int.Parse(arr[1])));

        foreach (var (g1, g2) in tuples)
        {
            lhsGroup.TryAdd(g1, 0);
            lhsGroup[g1] += 1;

            rhsGroup.TryAdd(g2, 0);
            rhsGroup[g2] += 1;
        }


        int sumA = 0;
        foreach (var pair in FlatMapEnumerate(lhsGroup).Zip(FlatMapEnumerate(rhsGroup)))
        {
            Console.WriteLine($"{pair.First} , {pair.Second}");
            var diff = int.Abs(pair.First - pair.Second);
            sumA += diff;
        }

        var sumB = 0;
        foreach (var (lhs, instances) in lhsGroup)
        {
            rhsGroup.TryGetValue(lhs, out var rhsInstances);
            sumB += lhs * instances * rhsInstances;
        }

        return (sumA.ToString(), sumB.ToString());
    }

    private int MicroOptimizedB(IList<int> lhs, IList<int> rhs)
    {
        var iteratorLhs = lhs;
        var iteratorRhs = rhs;

        var lhsPointer = 0;
        var rhsPointer = 0;

        while (lhsPointer < lhs.Count)
        {
            int sameCount = 1;
            while (lhsPointer < lhs.Count - 1 && lhs[lhsPointer] == lhs[lhsPointer + 1])
            {
                lhsPointer++;
                sameCount++;
            }

            int instanceCount = 0;
            while (rhs[rhsPointer] == lhs[lhsPointer] && rhsPointer < rhs.Count)
            {
                
            }
        }

        return 0;
    }

    private class DuplicateKeyComparer : IComparer<int>
    {
        // I know it's incorrect, it works for this specific use
        public int Compare(int x, int y)
        {
            var comparison = x.CompareTo(y);
            return comparison != 0 ? comparison : 1;
        }
    }

    private static IEnumerable<int> FlatMapEnumerate(SortedDictionary<int, int> sortedDict)
    {
        foreach (var (number, instances) in sortedDict)
        {
            for (int i = 0; i < instances; i++)
            {
                yield return number;
            }
        }
    }
}
