using NUnit.Framework;
using Solvers;
using System;

namespace Tests
{
    public class Day9Tests
    {
        [TestCase(9, 25, 32)]
        [TestCase(10, 1618, 8317)]
        [TestCase(13, 7999, 146373)]
        [TestCase(17, 1104, 2764)]
        [TestCase(21, 6111, 54718)]
        [TestCase(30, 5807, 37305)]
        public void Part1TestData(int players, int lastMarble, int highScore)
        {
            var result = Day9.PlayGame(players, lastMarble);
            Assert.AreEqual(highScore, result);
        }

        [Test]
        public void Part1Solution()
        {
            var result = Day9.Part1Solver(Helpers.GetInputLines(9));
            Assert.AreEqual(399645, result);
        }


        [Test]
        public void Part2Solution()
        {
            var result = Day9.Part2Solver(Helpers.GetInputLines(9));
            Assert.AreEqual(3352507536, result);
        }
    }
}