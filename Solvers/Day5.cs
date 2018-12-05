using System;
using System.Linq;
using System.Text;

namespace Solvers
{
    public static class Day5
    {
        public static int Part1Solver(string[] input)
        {
            var output = React(input[0]);
            return output.Length;
        }

        private static string React(string input, char ignore = '*')
        {
            var sb = new StringBuilder();
            var diff = Math.Abs('A' - 'a');
            foreach (var c in input.Where(x => char.ToLower(x) != ignore))
            {
                if(sb.Length > 0 && Math.Abs(sb[sb.Length-1] - c) == diff)
                {
                    sb.Length--;
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }


        public static int Part2Solver(string[] input)
        {
            return Enumerable.Range('a', 26)
                .Select(c => React(input[0], (char)c).Length)
                .Min();
        }


    }
}
