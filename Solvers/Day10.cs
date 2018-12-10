using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solvers
{
    public static class Day10
    {    
        public static string Part1Solver(string[] input)
        {
            var lights = input.Select(ParseInput).ToArray();
            var previousSize = MeasureCanvas(lights);
            int iteratons = 0;
            while (true)
            {
                UpdateLights(lights);
                iteratons++;
                var size = MeasureCanvas(lights);
                if (size < previousSize)
                {
                    previousSize = size;
                }
                else
                {
                    UpdateLights(lights, -1);
                    RenderLights(lights);
                    break;
                }
            }
            throw new NotImplementedException();
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

        public static int MeasureCanvas(Light[] lights)
        { 
            var minX = lights.Min(p => p.Position.X);
            var maxX = lights.Max(p => p.Position.X);
            var minY = lights.Min(p => p.Position.Y);
            var maxY = lights.Max(p => p.Position.Y);
            return (maxX - minX) * (maxY - minY);
        }

        public static string RenderLights(Light[] lights)
        {
            var minX = lights.Min(p => p.Position.X);
            var maxX = lights.Max(p => p.Position.X);
            var minY = lights.Min(p => p.Position.Y);
            var maxY = lights.Max(p => p.Position.Y);

            throw new NotImplementedException();
        }


        public static long Part2Solver(string[] input)
        {
            throw new InvalidOperationException();
        }

        public class Light
        {
            public Point Position;
            public Point Velocity;
        }
    }
}
