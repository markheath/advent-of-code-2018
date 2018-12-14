using MoreLinq;
using System.Collections.Generic;
using System.Linq;

namespace Solvers
{
    public static class Day14
    {
        public static string Part1Solver(int numberOfRecipes)
        {
            var elfPos = new[] { 0, 1 };
            var recipes = new List<int>(numberOfRecipes+10) { 3, 7 };
            while(recipes.Count < numberOfRecipes + 10)
            {
                var newRecipe = recipes[elfPos[0]] + recipes[elfPos[1]];
                if (newRecipe < 10)
                    recipes.Add(newRecipe);
                else
                {
                    recipes.Add(newRecipe / 10);
                    recipes.Add(newRecipe % 10);
                }
                elfPos[0] = (elfPos[0] + 1 + recipes[elfPos[0]]) % recipes.Count;
                elfPos[1] = (elfPos[1] + 1 + recipes[elfPos[1]]) % recipes.Count;
            }
            return recipes.Skip(numberOfRecipes).Take(10).ToDelimitedString("");
        }

        public static int Part2Solver(string search)
        {
            var searchNums = search.Select(c => c - '0').ToArray();
            int matchPos = 0;
            var elfPos = new[] { 0, 1 };
            var recipes = new List<int> { 3, 7 };
            while (true)
            {
                var newRecipe = recipes[elfPos[0]] + recipes[elfPos[1]];
                if (newRecipe < 10)
                {
                    recipes.Add(newRecipe);
                }
                else
                {
                    var newNum = newRecipe / 10;
                    recipes.Add(newNum);
                    matchPos = newNum == searchNums[matchPos] ? matchPos+1 : newNum == searchNums[0] ? 1 : 0;
                    if (matchPos == searchNums.Length) return recipes.Count - searchNums.Length;
                    recipes.Add(newRecipe % 10);
                }

                newRecipe = newRecipe % 10;
                matchPos = newRecipe == searchNums[matchPos] ? matchPos + 1 : newRecipe == searchNums[0] ? 1 : 0;
                if (matchPos == searchNums.Length) return recipes.Count - searchNums.Length;

                elfPos[0] = (elfPos[0] + 1 + recipes[elfPos[0]]) % recipes.Count;
                elfPos[1] = (elfPos[1] + 1 + recipes[elfPos[1]]) % recipes.Count;
            }
        }
    }
}
