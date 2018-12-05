using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Solvers
{
    public static class Day5
    {
        public static int Part1Solver(string[] input)
        {
            var output = React(input[0]);
            return output.Length;
        }

        private static string React(string input)
        {
            var sb = new StringBuilder();
            var diff = Math.Abs('A' - 'a');
            for(int n = 0; n < input.Length; n++)
            {
                if(sb.Length == 0)
                {
                    sb.Append(input[n]);
                }
                else if(Math.Abs(sb[sb.Length-1] - input[n]) == diff)
                {
                    sb.Length--;
                }
                else
                {
                    sb.Append(input[n]);
                }
            }
            return sb.ToString();
        }


        public static int Part2Solver(string[] input)
        {
            throw new NotImplementedException();
        }


    }
}
