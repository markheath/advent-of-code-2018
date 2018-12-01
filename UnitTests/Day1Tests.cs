using NUnit.Framework;
using Solvers;

namespace Tests
{

    public class Day1Tests
    {
        [Test]
        public void BasicAdding()
        {
            var total = Day1.Part1Solver("+5,-2,+4".Split(','));
            Assert.AreEqual(7, total);
        }

        [Test]
        public void Part1Solution()
        {
            var total = Day1.Part1Solver(Helpers.GetInputLines(1));
            Assert.AreEqual(445, total);
        }

        [Test]
        public void SeenTwice()
        {
            var answer = Day1.Part2Solver("+7,+7,-2,-7,-4".Split(','));
            Assert.AreEqual(14, answer);
        }

        [Test]
        public void Part2Solution()
        {
            var answer = Day1.Part2Solver(Helpers.GetInputLines(1));
            Assert.AreEqual(219, answer);
        }
    }
}