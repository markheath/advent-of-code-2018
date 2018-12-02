using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solvers
{
    public class Day2
    {
        public static int Part1Solver(string[] input)
        {
            return input.Count(s => HasAGroupOf(s, 2))
                * input.Count(s => HasAGroupOf(s, 3));
        }

        public static int Part2Solver(string[] input)
        {
            throw new NotImplementedException();
        }

        public static bool HasAGroupOf(string s, int count)
        {
            return s.CountBy(c => c).Any(n => n.Value == count);
        }
    }
}
