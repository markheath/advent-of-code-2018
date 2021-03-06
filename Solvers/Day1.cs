﻿using MoreLinq;
using System.Collections.Generic;
using System.Linq;

namespace Solvers
{
    public static class Day1
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
            var seen = new HashSet<int> { 0 };
            return input
                .Select(int.Parse)
                .Repeat() // perhaps should set a max here
                .Scan((a, b) => a + b)
                .First(n => !seen.Add(n));
        }
    }
}
