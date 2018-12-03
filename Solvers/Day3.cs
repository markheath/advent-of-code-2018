using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Solvers
{
    public class Day3
    {
        public static int Part1Solver(string[] input)
        {
            var state = new int[1000, 1000];
            var regex = new Regex(@"\#(\d+) \@ (\d+),(\d+)\: (\d+)x(\d+)");
            var shapes = input.Select(s => regex.Match(s).Groups)
                 .Select(g => new
                 {
                     n = int.Parse(g[1].Value),
                     x = int.Parse(g[2].Value),
                     y = int.Parse(g[3].Value),
                     w = int.Parse(g[4].Value),
                     h = int.Parse(g[5].Value)
                 });
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
            var regex = new Regex(@"\#(\d+) \@ (\d+),(\d+)\: (\d+)x(\d+)");
            var shapes = input.Select(s => regex.Match(s).Groups)
                 .Select(g => new
                 {
                     n = int.Parse(g[1].Value),
                     x = int.Parse(g[2].Value),
                     y = int.Parse(g[3].Value),
                     w = int.Parse(g[4].Value),
                     h = int.Parse(g[5].Value)
                 });
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
    }
}
