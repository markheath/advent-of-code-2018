using NUnit.Framework;
using Solvers;
using System;

namespace Tests
{
    public class Day11Tests
    {
        [Test]
        public void Part1Solution()
        {
            var result = Day11.Part1Solver(new[] { "6042" });
            Assert.AreEqual("21,61", result);
        }

        [TestCase(3, 5, 8, 4)]
        [TestCase(122, 79, 57, -5)]
        [TestCase(217, 196, 39, 0)]
        [TestCase(101, 153, 71, 4)]
        public void CanCalculatePowerLevel(int x, int y, int gridSerialNumber, int expected)
        {
            var powerLevel = Day11.GetPowerLevel(x,y,gridSerialNumber);
            Assert.AreEqual(expected, powerLevel);
        }

        [TestCase(18, 29, "33,45")]
        [TestCase(42, 30, "21,61")]
        public void Part1TestData(int gridSerialNumber, int power, string expected)
        {
            var coords = Day11.Part1Solver(new[] { gridSerialNumber.ToString() });
            Assert.AreEqual(expected, coords);
        }


        [Test]
        public void Part2Solution()
        {
            var result = Day11.Part2Solver(Helpers.GetInputLines(11));
            Assert.AreEqual(0, result);
        }

    }
}