using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Solvers
{
    public static class Day14
    {
        public static string Part1Solver(int numberOfRecipes)
        {
            var elfPos = new[] { 0, 1 };
            var recipes = new List<int>(numberOfRecipes+10) { 3, 7 };
            for(int steps = 1; recipes.Count < numberOfRecipes + 10; steps++)
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
            var elfPos = new[] { 0, 1 };
            var recipes = new List<int>() { 3, 7 };
            for (int steps = 1; true; steps++)
            {
                var newRecipe = recipes[elfPos[0]] + recipes[elfPos[1]];
                if (newRecipe < 10)
                {
                    recipes.Add(newRecipe);
                }
                else
                {
                    recipes.Add(newRecipe / 10);
                    if (Matches(recipes, searchNums))
                    {
                        return recipes.Count - searchNums.Length;
                    }
                    recipes.Add(newRecipe % 10);
                }
                if (Matches(recipes, searchNums))
                {
                    return recipes.Count - searchNums.Length;
                }

                elfPos[0] = (elfPos[0] + 1 + recipes[elfPos[0]]) % recipes.Count;
                elfPos[1] = (elfPos[1] + 1 + recipes[elfPos[1]]) % recipes.Count;
            }
        }

        private static bool Matches(List<int> recipes, int[] searchNums)
        {
            if (recipes.Count < searchNums.Length) return false;
            for(int n = 0, r = recipes.Count - searchNums.Length; n < searchNums.Length; n++, r++)
            {
                if (recipes[r] != searchNums[n]) return false;
            }
            return true;
        }
    }
}
