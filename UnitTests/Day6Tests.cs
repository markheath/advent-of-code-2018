using NUnit.Framework;
using Solvers;

namespace Tests
{
    public class Day6Tests
    {
        const string testData = @"1, 1
1, 6
8, 3
3, 4
5, 5
8, 9";
        [Test]
        public void Part1TestData()
        {
            var result = Day6.Part1Solver(testData.Split("\r\n"));
            Assert.AreEqual(17, result);
        }

        [Test]
        public void Part1Solution()
        {
            var result = Day6.Part1Solver(Helpers.GetInputLines(6));
            // not 8170 (too high)
            Assert.AreEqual(3907, result);
        }

        [Test]
        public void Part2TestData()
        {
            var result = Day6.Part2Solver(testData.Split("\r\n"), 32);
            Assert.AreEqual(16, result);
        }

        [Test]
        public void Part2Solution()
        {
            var result = Day6.Part2Solver(Helpers.GetInputLines(6), 10000);
            Assert.AreEqual(42036, result);
        }
    }

}