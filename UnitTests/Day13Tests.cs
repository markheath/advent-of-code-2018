using NUnit.Framework;
using Solvers;
using System.Linq;

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

    }
}