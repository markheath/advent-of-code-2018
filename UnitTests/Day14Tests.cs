using NUnit.Framework;
using Solvers;

namespace Tests
{
    public class Day14Tests
    {
        private const string testData = @"";

        [TestCase(9, "5158916779")]
        [TestCase(5, "0124515891")]
        [TestCase(18, "9251071085")]
        [TestCase(2018, "5941429882")]
        public void Part1TestData(int recipes, string expected)
        {
            var result = Day14.Part1Solver(recipes);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Part1Solution()
        {
            var result = Day14.Part1Solver(702831);

            Assert.AreEqual("1132413111", result);
        }

        [Test]
        public void Part2TestData()
        {
            var result = Day14.Part2Solver(testData.Split("\r\n"));

            Assert.AreEqual("", result);
        }

        [Test]
        public void Part2Solution()
        {
            var result = Day14.Part2Solver(Helpers.GetInputLines(14));

            Assert.AreEqual("", result);
        }
    }
}