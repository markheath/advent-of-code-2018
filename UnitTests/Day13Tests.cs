using NUnit.Framework;
using Solvers;

namespace Tests
{
    public class Day13Tests
    {
        private const string testData = @"/->-\        
|   |  /----\
| /-+--+-\  |
| | |  | v  |
\-+-/  \-+--/
  \------/   ";

        private const string testData2 = @"/>-<\  
|   |  
| /<+-\
| | | v
\>+</ |
  |   ^
  \<->/";

        [Test]
        public void Part1TestData()
        {
            var collision = Day13.Part1Solver(testData.Split("\r\n"));

            Assert.AreEqual("7,3", collision);
        }

        [Test]
        public void Part1Solution()
        {
            var collision = Day13.Part1Solver(Helpers.GetInputLines(13));

            Assert.AreEqual("130,104", collision);
        }

        [Test]
        public void Part2TestData()
        {
            var collision = Day13.Part2Solver(testData2.Split("\r\n"));

            Assert.AreEqual("6,4", collision);
        }

        [Test]
        public void Part2Solution()
        {
            var collision = Day13.Part2Solver(Helpers.GetInputLines(13));

            Assert.AreEqual("29,83", collision);
        }
    }
}