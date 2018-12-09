using System.Linq;
using System.Text.RegularExpressions;

namespace Solvers
{
    public static class Day9
    {
        class Position
        {
            public int MarbleNumber { get; set; }
            public Position Left { get; set; }
            public Position Right { get; set; }

        }

        // n.b. I'm sure high score can be solved without actually playing the game!
        // going the linked list route worked well for part 2
        public static long PlayGame(int players, int lastMarble)
        {
            var scores = new long[players];
            var currentBoard = new Position();
            currentBoard.Left = currentBoard;
            currentBoard.Right = currentBoard;
            int currentPlayer = 0;
            for(var currentMarble = 1; currentMarble <= lastMarble; currentMarble++)
            {
                if (currentMarble % 23 == 0)
                {
                    scores[currentPlayer] += currentMarble;
                    var toRemove = currentBoard.Left.Left.Left.Left.Left.Left.Left;
                    scores[currentPlayer] += toRemove.MarbleNumber;
                    currentBoard = toRemove.Right;
                    toRemove.Left.Right = currentBoard;
                    currentBoard.Left = toRemove.Left;
                }
                else
                {
                    // regular insert
                    var placeAfter = currentBoard.Right;
                    var newMarble = new Position() { MarbleNumber = currentMarble, Left = placeAfter, Right = placeAfter.Right };
                    placeAfter.Right = newMarble;
                    newMarble.Right.Left = newMarble;
                    currentBoard = newMarble;
                }
                currentPlayer++;
                if (currentPlayer == players) currentPlayer = 0;
            }

            return scores.Max();
        }
    
        public static long Part1Solver(string[] input)
        {
            var (players, lastMarble) = ParseInput(input[0]);
            return PlayGame(players, lastMarble);
        }

        private static (int,int) ParseInput(string input)
        {
            var matches = Regex.Matches(input, @"\d+");
            return(int.Parse(matches[0].Value),int.Parse(matches[1].Value));
        }

        public static long Part2Solver(string[] input)
        {
            var (players, lastMarble) = ParseInput(input[0]);
            return PlayGame(players, lastMarble*100);
        }
    }
}
