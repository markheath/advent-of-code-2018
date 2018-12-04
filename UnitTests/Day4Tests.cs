using NUnit.Framework;
using Solvers;

namespace Tests
{
    public class Day4Tests
    {
        private const string testData = @"[1518-11-01 00:00] Guard #10 begins shift
[1518-11-01 00:05] falls asleep
[1518-11-01 00:25] wakes up
[1518-11-01 00:30] falls asleep
[1518-11-01 00:55] wakes up
[1518-11-01 23:58] Guard #99 begins shift
[1518-11-02 00:40] falls asleep
[1518-11-02 00:50] wakes up
[1518-11-03 00:05] Guard #10 begins shift
[1518-11-03 00:24] falls asleep
[1518-11-03 00:29] wakes up
[1518-11-04 00:02] Guard #99 begins shift
[1518-11-04 00:36] falls asleep
[1518-11-04 00:46] wakes up
[1518-11-05 00:03] Guard #99 begins shift
[1518-11-05 00:45] falls asleep
[1518-11-05 00:55] wakes up";

        [Test]
        public void Part1TestData()
        {
            var guardMinute = Day4.Part1Solver(testData.Split('\n'));
            Assert.AreEqual(240, guardMinute);
        }

        [Test]
        public void Part1Solution()
        {
            var guardMinute = Day4.Part1Solver(Helpers.GetInputLines(4));
            Assert.AreEqual(104764, guardMinute);
        }

        [Test]
        public void Part2TestData()
        {
            var guardMinute = Day4.Part2Solver(testData.Split('\n'));
            Assert.AreEqual(4455, guardMinute);
        }

        [Test]
        public void Part2Solution()
        {
            var guardMinute = Day4.Part2Solver(Helpers.GetInputLines(4));
            Assert.AreEqual(128617, guardMinute);
        }
    }

}