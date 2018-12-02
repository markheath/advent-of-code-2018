using NUnit.Framework;
using Solvers;

namespace Tests
{

    public class Day2Tests
    {

        [Test]
        public void Part1Solution()
        {
            var checksum = Day2.Part1Solver(Helpers.GetInputLines(2));
            Assert.AreEqual(7221, checksum);
        }

        [Test]
        public void Part1TestData()
        {
            var checksum = Day2.Part1Solver("abcdef,bababc,abbcde,abcccd,aabcdd,abcdee,ababab".Split(','));
            Assert.AreEqual(12, checksum);
        }

    }
}