using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solvers
{
    public class Day1
    {
        public static int Part1Solver(string part1Input)
        {
            var total = 
                Regex.Split(part1Input, "\r\n|\n")
                            .Where(s => !String.IsNullOrEmpty(s))
                           .Select(int.Parse)
                           .Sum();
            return total;
        }
    }
}
