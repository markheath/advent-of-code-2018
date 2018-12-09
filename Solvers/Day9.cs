using MoreLinq;
using System;
using System.Collections.Generic;
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
        public static int PlayGame(int players, int lastMarble)
        {
            var scores = new int[players];
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
    
        public static int Part1Solver(string[] input)
        {
            var matches = Regex.Matches(input[0], @"\d+");
            var players = int.Parse(matches[0].Value);
            var lastMarble = int.Parse(matches[1].Value);
            return PlayGame(players, lastMarble);
        }

        public static int Part2Solver(string[] input)
        {
            throw new NotImplementedException();
        }
    }
}
