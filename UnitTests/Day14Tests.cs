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

        [TestCase(9, "51589")]
        [TestCase(5, "01245")]
        [TestCase(18, "92510")]
        [TestCase(2018, "59414")]

        public void Part2TestData(int recipes, string search)
        {
            var result = Day14.Part2Solver(search);

            Assert.AreEqual(recipes, result);
        }

        [Test]
        public void Part2Solution()
        {
            var result = Day14.Part2Solver("702831");

            Assert.AreEqual(20340232, result);
        }
    }
}