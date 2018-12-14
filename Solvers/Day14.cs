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

        public static string Part2Solver(string[] input)
        {
            throw new NotImplementedException();
        }
    }
}
