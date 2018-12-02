using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solvers
{
    public class Day2
    {
        public static int Part1Solver(string[] input)
        {
            return input.Count(s => HasAGroupOf(s, 2))
                * input.Count(s => HasAGroupOf(s, 3));
        }

        public static string Part2Solver(string[] input)
        {
            return input.Subsets(2)
                .Select(s => OneCharDifferent(s[0], s[1]))
                .First(s => s != null);
        }

        public static string OneCharDifferent(string s, string s2)
        {
            var res = new StringBuilder();
            for(int n = 0; n < s.Length; n++)
            {
                if (s[n] == s2[n])
                    res.Append(s[n]);
            }
            return res.Length == s.Length - 1 ? res.ToString() : null;
        }

        public static bool HasAGroupOf(string s, int count)
        {
            return s.CountBy(c => c).Any(n => n.Value == count);
        }
    }
}
