using NUnit.Framework;
using Solvers;
using System;
using System.Linq;

namespace Tests
{
    public class Day12Tests
    {
        private const string testData = @"initial state: #..#.#..##......###...###

...## => #
..#.. => #
.#... => #
.#.#. => #
.#.## => #
.##.. => #
.#### => #
#.#.# => #
#.### => #
##.#. => #
##.## => #
###.. => #
###.# => #
####. => #";

        [Test]
        public void CanParseTestInput()
        {
            var (state, lookup) = Day12.ParseInput(testData.Split("\r\n"));
            Assert.AreEqual("#..#.#..##......###...###", state);
            Assert.AreEqual(14, lookup.Count);
            Assert.AreEqual('#', lookup[".####"]);
        }

        private readonly (int,string)[] testStates = new[]
        {
            (0,"#..#.#..##......###...###"),
            (0,"#...#....#.....#..#..#..#"),
            (0,"##..##...##....#..#..#..##"),
            (-1,"#.#...#..#.#....#..#..#...#"),
            (0,"#.#..#...#.#...#..#..##..##"),
            (1,"#...##...#.#..#..#...#...#"), // 5
            (1,"##.#.#....#...#..##..##..##"), // 6
            (0,"#..###.#...##..#...#...#...#") // 7
                    /*
 7: ...#..###.#...##..#...#...#...#........
 8: ...#....##.#.#.#..##..##..##..##.......
 9: ...##..#..#####....#...#...#...#.......
10: ..#.#..#...#.##....##..##..##..##......
11: ...#...##...#.#...#.#...#...#...#......
12: ...##.#.#....#.#...#.#..##..##..##.....
13: ..#..###.#....#.#...#....#...#...#.....
14: ..#....##.#....#.#..##...##..##..##....
15: ..##..#..#.#....#....#..#.#...#...#....
16: .#.#..#...#.#...##...#...#.#..##..##...
17: ..#...##...#.#.#.#...##...#....#...#...
18: ..##.#.#....#####.#.#.#...##...##..##..
19: .#..###.#..#.#.#######.#.#.#..#.#...#..
20: .#....##....#####...#######....#.#..##.*/
 };

        [Test]
        public void CanMutateState()
        {
            var (currentState, lookup) = Day12.ParseInput(testData.Split("\r\n"));
            int currentIndex = 0;
            foreach(var (expectedIndex, expectedState) in testStates.Skip(1))
            {
                var (index, newState) = Day12.Mutate(currentState, lookup);
                Assert.AreEqual(expectedState, newState);
                currentState = newState;
                Assert.AreEqual(expectedIndex, index + currentIndex);
                currentIndex = index + currentIndex;
            }
        }

        [Test]
        public void Part1TestData()
        {
            var result = Day12.Part1Solver(testData.Split("\r\n"));

            Assert.AreEqual(325, result);
        }


        [Test]
        public void Part1Solution()
        {
            var result = Day12.Part1Solver(Helpers.GetInputLines(12));

            Assert.AreEqual(2995, result);
        }


    }
}