using NUnit.Framework;
using Solvers;

namespace Tests
{

    public class Day3Tests
    {

        [Test]
        public void Part1Solution()
        {
            var overlaps = Day3.Part1Solver(Helpers.GetInputLines(3));
            Assert.AreEqual(115304, overlaps);
        }

        [Test]
        public void Part1TestData()
        {
            var overlaps = Day3.Part1Solver("#1 @ 1,3: 4x4;#2 @ 3,1: 4x4;#3 @ 5,5: 2x2".Split(';'));
            Assert.AreEqual(4, overlaps);
        }

        [Test]
        public void Part2Solution()
        {
            var claimId = Day3.Part2Solver(Helpers.GetInputLines(3));
            Assert.AreEqual(275, claimId);
        }

        [Test]
        public void Part2TestData()
        {
            var claimId = Day3.Part2Solver("#1 @ 1,3: 4x4;#2 @ 3,1: 4x4;#3 @ 5,5: 2x2".Split(';'));
            Assert.AreEqual(3, claimId);
        }
    }

}