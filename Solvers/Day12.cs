using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Solvers
{
    public static class Day12
    {    
        public static int Part1Solver(string[] input)
        {
            var (state, lookup) = ParseInput(input);
            var currentIndex = 0;
            for (int n = 0; n < 20; n++)
            {
                var (index, nextState) = Mutate(state, lookup);
                state = nextState;
                currentIndex += index;
            }
            return state.Select((c, n) => new { c, n = n + currentIndex })
                .Where(x => x.c == '#')
                .Sum(x => x.n);
        }

        public static (int,string) Mutate(string input, IDictionary<string,char> replacements)
        {
            var sb = new StringBuilder();
            var startPos = -1;
            var input2 = "...." + input + "....";
            for(int n = 0; n < input2.Length-5; n++)
            {
                if (!replacements.TryGetValue(input2.Substring(n, 5), out var c))
                    c = '.';
                if (sb.Length != 0)
                    sb.Append(c);
                else if (c == '#')
                {
                    startPos = n - 2;
                    sb.Append(c);
                }
            }
            while (sb.Length > 0 && sb[sb.Length - 1] == '.') sb.Length--;
            return (startPos, sb.ToString());
        }

        public static (string, IDictionary<string,char>) ParseInput(string[] testData)
        {
            var initialState = Regex.Match(testData[0], @"[\.\#]+").Value;
            var lookup = testData.Skip(1)
                .Select(s => Regex.Match(s, @"([\.\#]+) => ([.\#])"))
                .Where(m => m.Success)
                .ToDictionary(m => m.Groups[1].Value, m => m.Groups[2].Value[0]);
            return (initialState, lookup);
        }

        public static long Part2Solver(string[] input)
        {
            var (state, lookup) = ParseInput(input);
            var states = new Dictionary<string, (long,int)>();
            var currentIndex = 0L;

            var repeatStart = 0;
            var repeatLength = 0;
            var repeatShift = 0L;

            for (int n = 1; true; n++)
            {
                var (index, nextState) = Mutate(state, lookup);
                state = nextState;
                currentIndex += index;
                Console.WriteLine($"{n}: {currentIndex} {state}");
                if (states.ContainsKey(state))
                {
                    var (startIndex, startIteration) = states[state];
                    repeatLength = n - startIteration;
                    repeatShift = currentIndex - startIndex;
                    repeatStart = startIteration;
                    break;
                }
                states[state] = (currentIndex, n);
            }
            var extras = (50000000000 - repeatStart) % repeatLength;
            var loops = (50000000000 - repeatStart) / repeatLength;
            if (repeatShift != 0)
                currentIndex += repeatShift * (loops - 1);

            for (var n = 0; n < extras; n++)
            {
                var (index, nextState) = Mutate(state, lookup);
                state = nextState;
                currentIndex += index;
            }

            return state.Select((c, n) => new { c, n = n + currentIndex })
                .Where(x => x.c == '#')
                .Sum(x => x.n);
        }
    }
}
