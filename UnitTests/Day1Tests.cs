using NUnit.Framework;
using Solvers;
using System.IO;
using System.Reflection;

namespace Tests
{
    public class Day1Tests
    {

        public static string GetInputFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "UnitTests.day1.txt";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }


        [Test]
        public void BasicAdding()
        {
            var total = Day1.Part1Solver("+5\r\n-2\r\n+4");
            Assert.AreEqual(7, total);
        }

        [Test]
        public void Part1Solution()
        {
            var total = Day1.Part1Solver(GetInputFile());
            Assert.AreEqual(445, total);
        }
    }
}