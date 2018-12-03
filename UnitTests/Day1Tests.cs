using NUnit.Framework;
using Solvers;

namespace Tests
{
    public class Day1Tests
    {
        [TestCase("+1, -2, +3, +1", 3)]
        [TestCase("+1, +1, +1", 3)]
        [TestCase("+1, +1, -2", 0)]
        [TestCase("-1, -2, -3", -6)]
        public void BasicAdding(string input, int expected)
        {
            var total = Day1.Part1Solver(input.Split(", "));
            Assert.AreEqual(expected, total);
        }

        [Test]
        public void Part1Solution()
        {
            var total = Day1.Part1Solver(Helpers.GetInputLines(1));
            Assert.AreEqual(445, total);
        }

        [TestCase("+1, -2, +3, +1", 2)]
        [TestCase("+1, -1", 0)]
        [TestCase("+3, +3, +4, -2, -4", 10)]
        [TestCase("-6, +3, +8, +5, -6", 5)]
        [TestCase("+7, +7, -2, -7, -4", 14)]
        public void SeenTwice(string input, int expected)
        {
            var answer = Day1.Part2Solver(input.Split(','));
            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Part2Solution()
        {
            var answer = Day1.Part2Solver(Helpers.GetInputLines(1));
            Assert.AreEqual(219, answer);
        }
    }
}