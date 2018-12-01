using MoreLinq;
using System.Collections.Generic;
using System.Linq;

namespace Solvers
{
    public class Day1
    {
        public static int Part1Solver(string[] input)
        {
            var total = input 
                           .Select(int.Parse)
                           .Sum();
            return total;
        }

        public static int Part2Solver(string[] input)
        {
            var seen = new HashSet<int>() { 0 };
            return input
                .Select(int.Parse)
                .Repeat()
                .Scan((a, b) => a + b)
                .Where(n => !seen.Add(n))
                .First();
        }
    }
}
