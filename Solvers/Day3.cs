using MoreLinq;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solvers
{
    public static class Day3
    {
        public static int Part1Solver(string[] input)
        {
            var state = new int[1000, 1000];
            var shapes = ParseInput(input);
            foreach(var shape in shapes)
            {
                for (var x = shape.x; x < shape.x + shape.w; x++)
                    for (var y = shape.y; y < shape.y + shape.h; y++)
                        state[x, y]++; //state[x, y] == 0 ? shape.n : -1;
            }

            int overlaps = 0;
            for (var x = 0; x < 1000; x++)
                for (var y = 0; y < 1000; y++)
                    if (state[x,y] > 1) overlaps++;
            return overlaps;
        }

        public static int Part2Solver(string[] input)
        {
            var state = new int[1000, 1000];
            var free = Enumerable.Range(1, input.Length).ToHashSet();
            var shapes = ParseInput(input);
            foreach (var shape in shapes)
            {
                for (var x = shape.x; x < shape.x + shape.w; x++)
                    for (var y = shape.y; y < shape.y + shape.h; y++)
                    {
                        if (state[x,y] == 0)
                        {
                            state[x, y] = shape.n;
                        }
                        else
                        {
                            free.Remove(shape.n);
                            free.Remove(state[x, y]);
                            state[x, y] = shape.n;
                        }
                    }
            }

            return free.Single();
        }

        private static IEnumerable<(int n, int x, int y, int w, int h)> ParseInput(string[] input)
        {
            var regex = new Regex(@"\#(\d+) \@ (\d+),(\d+)\: (\d+)x(\d+)");
            return input.Select(s => regex.Match(s).Groups)
                .Select(g => (int.Parse(g[1].Value),
                    int.Parse(g[2].Value),
                    int.Parse(g[3].Value),
                    int.Parse(g[4].Value),
                    int.Parse(g[5].Value)));
        }
    }
}
