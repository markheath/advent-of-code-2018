using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            var numbers = input
                           .Select(int.Parse)
                           .ToArray();
            var seen = new HashSet<int>() { 0 };
            var total = 0;
            var pos = 0;
            while(true)
            {
                var number = numbers[pos++];
                if (pos == numbers.Length) pos = 0;
                total += number;
                if (seen.Contains(total))
                    return total;
                seen.Add(total);
            }
            throw new InvalidOperationException("Didn't see any duplicates");
        }
    }
}
