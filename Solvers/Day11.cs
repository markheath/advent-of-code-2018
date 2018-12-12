using MoreLinq;
using System.Linq;

namespace Solvers
{
    public static class Day11
    {
        public static string Part1Solver(string[] input)
        {
            var serialNumber = int.Parse(input[0]);
            var grid = CreateGrid(300, 300, serialNumber);
            var (x,y,_,_) = FindLargestSubgrid(grid, 3, 300, 300);
            return $"{x},{y}";
        }

        public static (int x,int y,int power,int gridSize) FindLargestSubgrid(int[,] grid, int subgridSize, int width, int height)
        {
            var maxSubgrid = Enumerable.Range(0, width - subgridSize + 1)
                .SelectMany(x => Enumerable.Range(0, height - subgridSize + 1).Select(y => (x, y)))
                .Select(c => new
                {
                    Coord = c,
                    Power = Enumerable.Range(0,subgridSize).SelectMany(dx => Enumerable.Range(0,subgridSize).Select(dy => (dx,dy)))
                        .Sum(q => grid[c.x + q.dx, c.y + q.dy])
                }).MaxBy(s => s.Power).First(); // for part 2 there can be shared maximums at various grid sizes
            return (maxSubgrid.Coord.x + 1, maxSubgrid.Coord.y + 1, maxSubgrid.Power, subgridSize);
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

        public static string Part2Solver(string[] input)
        {
            var serialNumber = int.Parse(input[0]);
            var grid = CreateGrid(300, 300, serialNumber);
            var (x,y,_,size) = Enumerable.Range(1, 300)
                .Select(g => FindLargestSubgrid(grid, g, 300, 300))
                .MaxBy(q => q.power)
                .Single();
            return $"{x},{y},{size}";
        }
    }
}
