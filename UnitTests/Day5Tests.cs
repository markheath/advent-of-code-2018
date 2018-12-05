using NUnit.Framework;
using Solvers;

namespace Tests
{
    public class Day5Tests
    {
        private const string testData = @"dabAcCaCBAcCcaDA";

        [Test]
        public void Part1TestData()
        {
            var polymerLength = Day5.Part1Solver(new[] { testData });
            Assert.AreEqual(10, polymerLength);
        }

        [Test]
        public void Part1Solution()
        {
            var polymerLength = Day5.Part1Solver(Helpers.GetInputLines(5));
            Assert.AreEqual(9238, polymerLength);
        }

        [Test]
        public void Part2TestData()
        {
            var polymerLength = Day5.Part2Solver(testData.Split('\n'));
            Assert.AreEqual(4, polymerLength);
        }

        [Test]
        public void Part2Solution()
        {
            var polymerLength = Day5.Part2Solver(Helpers.GetInputLines(5));
            Assert.AreEqual(4052, polymerLength);
        }
    }

}