using NUnit.Framework;
using Solvers;
using System;

namespace Tests
{
    public class Day10Tests
    {
        private const string testData = @"position=< 9,  1> velocity=< 0,  2>
position=< 7,  0> velocity=<-1,  0>
position=< 3, -2> velocity=<-1,  1>
position=< 6, 10> velocity=<-2, -1>
position=< 2, -4> velocity=< 2,  2>
position=<-6, 10> velocity=< 2, -2>
position=< 1,  8> velocity=< 1, -1>
position=< 1,  7> velocity=< 1,  0>
position=<-3, 11> velocity=< 1, -2>
position=< 7,  6> velocity=<-1, -1>
position=<-2,  3> velocity=< 1,  0>
position=<-4,  3> velocity=< 2,  0>
position=<10, -3> velocity=<-1,  1>
position=< 5, 11> velocity=< 1, -2>
position=< 4,  7> velocity=< 0, -1>
position=< 8, -2> velocity=< 0,  1>
position=<15,  0> velocity=<-2,  0>
position=< 1,  6> velocity=< 1,  0>
position=< 8,  9> velocity=< 0, -1>
position=< 3,  3> velocity=<-1,  1>
position=< 0,  5> velocity=< 0, -1>
position=<-2,  2> velocity=< 2,  0>
position=< 5, -2> velocity=< 1,  2>
position=< 1,  4> velocity=< 2,  1>
position=<-2,  7> velocity=< 2, -2>
position=< 3,  6> velocity=<-1, -1>
position=< 5,  0> velocity=< 1,  0>
position=<-6,  0> velocity=< 2,  0>
position=< 5,  9> velocity=< 1, -2>
position=<14,  7> velocity=<-2,  0>
position=<-3,  6> velocity=< 2, -1>";

        [Test]
        public void CanParseInput()
        {
            var result = Day10.ParseInput("position=<15, -2> velocity=<-3, 11>");
            Assert.AreEqual(15, result.Position.X);
            Assert.AreEqual(-2, result.Position.Y);
            Assert.AreEqual(-3, result.Velocity.X);
            Assert.AreEqual(11, result.Velocity.Y);
        }

        [Test]
        public void Part1Solution()
        {
            var result = Day10.Part1Solver(Helpers.GetInputLines(10));
            Assert.AreEqual(@"#.......#####....####...#####...#####...#....#..######..######
#.......#....#..#....#..#....#..#....#..#....#..#............#
#.......#....#..#.......#....#..#....#..#....#..#............#
#.......#....#..#.......#....#..#....#..#....#..#...........#.
#.......#####...#.......#####...#####...######..#####......#..
#.......#..#....#..###..#.......#....#..#....#..#.........#...
#.......#...#...#....#..#.......#....#..#....#..#........#....
#.......#...#...#....#..#.......#....#..#....#..#.......#.....
#.......#....#..#...##..#.......#....#..#....#..#.......#.....
######..#....#...###.#..#.......#####...#....#..######..######
", result); // LRGPBHEZ
        }

        [Test]
        public void Part1TestData()
        {
            var result = Day10.Part1Solver(testData.Split("\r\n"));
            Assert.AreEqual(@"#...#..###
#...#...#.
#...#...#.
#####...#.
#...#...#.
#...#...#.
#...#...#.
#...#..###
", result);
        }

        [Test]
        public void Part2TestData()
        {
            var result = Day10.Part2Solver(testData.Split("\r\n"));
            Assert.AreEqual(3, result);
        }


        [Test]
        public void Part2Solution()
        {
            var result = Day10.Part2Solver(Helpers.GetInputLines(10));
            Assert.AreEqual(10011, result);
        }

    }
}