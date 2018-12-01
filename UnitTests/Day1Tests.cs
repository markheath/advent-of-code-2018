using NUnit.Framework;
using Solvers;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Tests
{
    public class Day1Tests
    {

        public static string[] GetInputFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "UnitTests.day1.txt";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                var input = reader.ReadToEnd();
                return Regex.Split(input, "\r\n|\n")
                       .Where(s => !string.IsNullOrEmpty(s))
                       .ToArray();
            }
        }



        [Test]
        public void BasicAdding()
        {
            var total = Day1.Part1Solver("+5,-2,+4".Split(','));
            Assert.AreEqual(7, total);
        }

        [Test]
        public void Part1Solution()
        {
            var total = Day1.Part1Solver(GetInputFile());
            Assert.AreEqual(445, total);
        }

        [Test]
        public void SeenTwice()
        {
            var answer = Day1.Part2Solver("+7,+7,-2,-7,-4".Split(','));
            Assert.AreEqual(14, answer);
        }

        [Test]
        public void Part2Solution()
        {
            var answer = Day1.Part2Solver(GetInputFile());
            Assert.AreEqual(219, answer);
        }
    }
}