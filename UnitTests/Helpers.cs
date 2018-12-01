using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Tests
{
    static class Helpers
    {
        public static string[] GetInputLines(int day)
        {
            var input = GetEmbeddedResourceAsText($"UnitTests.day{day}.txt");
            return Regex.Split(input, "\r\n|\n")
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToArray();
        }

        public static string GetEmbeddedResourceAsText(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}