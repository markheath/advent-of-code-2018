using MoreLinq;
using System;
using System.Linq;

namespace Solvers
{
    public static class Day11
    {    
        public static string Part1Solver(string[] input)
        {
            var serialNumber = int.Parse(input[0]);
            var grid = CreateGrid(300, 300, serialNumber);
            var (x,y) = FindLargestSubgrid(grid, 300, 300);
            return $"{x},{y}";
        }

        public static (int,int) FindLargestSubgrid(int[,] grid, int width, int height)
        {
            var maxSubgrid = Enumerable.Range(0, width - 2)
                .SelectMany(x => Enumerable.Range(0, height - 2).Select(y => (x, y)))
                .Select(c => new
                {
                    Coord = c,
                    Power = grid[c.x, c.y] + grid[c.x + 1, c.y] + grid[c.x + 2, c.y] +
                grid[c.x, c.y + 1] + grid[c.x + 1, c.y + 1] + grid[c.x + 2, c.y + 1] +
                grid[c.x, c.y + 2] + grid[c.x + 1, c.y + 2] + grid[c.x + 2, c.y + 2]
                }).MaxBy(s => s.Power).Single();
            return (maxSubgrid.Coord.x + 1, maxSubgrid.Coord.y + 1);
        }

        public static int[,] CreateGrid(int width, int height, int gridSerialNumber)
        {
            var grid = new int[width, height];
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    grid[x, y] = GetPowerLevel(x+1, y+1, gridSerialNumber);
            return grid;
        }

        public static int GetPowerLevel(int x, int y, int gridSerialNumber)
        {
            var rackId = x + 10;
            var powerLevel = rackId * y;
            powerLevel += gridSerialNumber;
            powerLevel *= rackId;
            powerLevel /= 100;
            return powerLevel % 10 - 5;
        }

        public static int Part2Solver(string[] input)
        {
            throw new InvalidOperationException();
        }
    }
}
