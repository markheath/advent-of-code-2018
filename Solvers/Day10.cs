using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Solvers
{
    public static class Day10
    {    
        public static string Part1Solver(string[] input)
        {
            return FindSmallest(input).Item2;
        }

        private static (int,string) FindSmallest(string[] input)
        {
            var lights = input.Select(ParseInput).ToArray();
            var previousSize = MeasureCanvas(lights);
            int seconds = 0;
            while (true)
            {
                UpdateLights(lights);
                seconds++;
                var size = MeasureCanvas(lights);
                if (size < previousSize)
                {
                    previousSize = size;
                }
                else
                {
                    UpdateLights(lights, -1);
                    return (seconds-1, RenderLights(lights));
                }
            }
        }

        public static int Part2Solver(string[] input)
        {
            return FindSmallest(input).Item1;
        }



        public static Light ParseInput(string input)
        {
            var numbers = Regex.Matches(input, @"-?\d+").Cast<Match>().Select(m => int.Parse(m.Value)).ToArray();
            return new Light() {  Position = new Point(numbers[0], numbers[1]),
            Velocity = new Point(numbers[2],numbers[3])};
        }

        public static void UpdateLights(Light[] lights, int direction = 1)
        {
            foreach (var light in lights)
            {
                light.Position.X += light.Velocity.X * direction;
                light.Position.Y += light.Velocity.Y * direction;
            }
        }

        public static long MeasureCanvas(Light[] lights)
        { 
            long minX = lights.Min(p => p.Position.X);
            long maxX = lights.Max(p => p.Position.X);
            long minY = lights.Min(p => p.Position.Y);
            long maxY = lights.Max(p => p.Position.Y);
            return (maxX - minX) * (maxY - minY);
        }

        public static string RenderLights(Light[] lights)
        {
            var minX = lights.Min(p => p.Position.X);
            var maxX = lights.Max(p => p.Position.X);
            var minY = lights.Min(p => p.Position.Y);
            var maxY = lights.Max(p => p.Position.Y);
            var width = maxX - minX + 1;
            var height = maxY - minY + 1;
            var rows = Enumerable.Range(1, height).Select(_ => Enumerable.Repeat('.',width).ToArray()).ToArray();
            foreach (var light in lights)
            {
                rows[light.Position.Y - minY][light.Position.X - minX] = '#';
            }

            var sb = new StringBuilder();
            foreach (var row in rows)
            {
                sb.AppendLine(new string(row));
                Console.WriteLine(row);
            }

            return sb.ToString();
        }




        public class Light
        {
            public Point Position;
            public Point Velocity;
        }
    }
}
