using NUnit.Framework;
using Solvers;

namespace Tests
{
    public class Day7Tests
    {
        const string testData = @"Step C must be finished before step A can begin.
Step C must be finished before step F can begin.
Step A must be finished before step B can begin.
Step A must be finished before step D can begin.
Step B must be finished before step E can begin.
Step D must be finished before step E can begin.
Step F must be finished before step E can begin.";
        [Test]
        public void Part1TestData()
        {
            var result = Day7.Part1Solver(testData.Split("\r\n"));
            Assert.AreEqual("CABDFE", result);
        }

        [Test]
        public void Part1Solution()
        {
            var result = Day7.Part1Solver(Helpers.GetInputLines(7));
            Assert.AreEqual("EBICGKQOVMYZJAWRDPXFSUTNLH", result);
        }

        [Test]
        public void Part7TestData()
        {
            var result = Day7.Part2Solver(testData.Split("\r\n"));
            Assert.AreEqual(16, result);
        }

        [Test]
        public void Part7Solution()
        {
            var result = Day7.Part2Solver(Helpers.GetInputLines(7));
            Assert.AreEqual(42036, result);
        }
    }

}