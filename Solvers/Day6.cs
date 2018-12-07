using MoreLinq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Solvers
{
    public static class Day6
    {
        public static int Part1Solver(string[] input)
        {
            var coords = input.Select(x => x.Split(','))
                .Select(c => (x: int.Parse(c[0]), y: int.Parse(c[1])))
                .ToArray();
            var minX = coords.Min(c => c.x);
            var maxX = coords.Max(c => c.x);
            var minY = coords.Min(c => c.y);
            var maxY = coords.Max(c => c.y);

            var edgePoints = new HashSet<int>();

            var grid = new Dictionary<(int,int),Neighbour>();
            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    var neighbour = FindNearestNeighbour(x, y, coords);
                    grid[(x, y)] = neighbour;
                    if (x == minX || x == maxX || y == minY || y == maxY)
                    {
                        edgePoints.Add(neighbour.Point);
                    }
                }
            }

            // assume areas are all contiguous
            return grid.Values
                .Where(n => n.Point != -1)
                .Where(n => !edgePoints.Contains(n.Point)
                )
                .CountBy(x => x.Point).Max(g => g.Value);
        }

        static Neighbour FindNearestNeighbour(int x, int y, (int,int)[] coords)
        {
            var nearest = coords.Select((c, n) => new Neighbour()
            {
                Point = n,
                Distance = Math.Abs(x - c.Item1) + Math.Abs(y - c.Item2)
            }).MinBy(n => n.Distance).ToArray();

            if (nearest.Length == 1) return nearest[0];
            return new Neighbour() { Point = -1, Distance = nearest[0].Distance };
        }

        static int FindDistanceToAll(int x, int y, (int, int)[] coords)
        {
            return coords.Sum(c => Math.Abs(x - c.Item1) + Math.Abs(y - c.Item2));
          }

        [DebuggerDisplay("{Point}:{Distance}")]
        struct Neighbour
        {
            public int Point { get; set; }
            public int Distance { get; set; }
            public override string ToString()
            {
                return $"{Point},{Distance}";
            }
        }

        public static int Part2Solver(string[] input, int maxDist)
        {

            var coords = input.Select(x => x.Split(','))
                .Select(c => (x: int.Parse(c[0]), y: int.Parse(c[1])))
                .ToArray();
            var minX = coords.Min(c => c.x);
            var maxX = coords.Max(c => c.x);
            var minY = coords.Min(c => c.y);
            var maxY = coords.Max(c => c.y);

            var grid = new Dictionary<(int, int), int>();
            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    grid[(x, y)] = FindDistanceToAll(x, y, coords);
                }
            }

            return grid.Values
                .Count(n => n < maxDist);
        }
    }
}
