using NUnit.Framework;
using Solvers;

namespace Tests
{
    public class Day8Tests
    {
        const string testData = @"2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";
        [Test]
        public void Part1TestData()
        {
            var result = Day8.Part1Solver(testData.Split("\r\n"));
            Assert.AreEqual(138, result);
        }

        [Test]
        public void Part1Solution()
        {
            var result = Day8.Part1Solver(Helpers.GetInputLines(8));
            Assert.AreEqual(49426, result);
        }

        [Test]
        public void Part2TestData()
        {
            var result = Day8.Part2Solver(testData.Split("\r\n"));
            Assert.AreEqual(66, result);
        }

        [Test]
        public void Part2Solution()
        {
            var result = Day8.Part2Solver(Helpers.GetInputLines(8));
            Assert.AreEqual(40688, result);
        }
    }
}