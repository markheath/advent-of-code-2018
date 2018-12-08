using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solvers
{
    public static class Day8
    {
        private class Node
        {
            public List<Node> ChildNodes { get; } = new List<Node>();
            public List<int> MetaData { get; } = new List<int>();
            public int Value
            {
                get
                {
                    if (ChildNodes.Count == 0)
                        return MetaData.Sum();
                    return MetaData
                        .Where(n => n > 0 && n <= ChildNodes.Count)
                        .Sum(n => ChildNodes[n - 1].Value);
                }
            }
        }

        private static Node ParseTree(Func<int> getNextNumber)
        {
            var newNode = new Node();
            var childNodeCount = getNextNumber();
            var metaDataCount = getNextNumber();
            newNode.ChildNodes.AddRange(
                Enumerable.Range(0, childNodeCount).Select(_ => ParseTree(getNextNumber)));
            newNode.MetaData.AddRange(
                Enumerable.Range(0, metaDataCount).Select(_ => getNextNumber()));
            return newNode;
        }

        private static Node ParseTree(string input)
        {
            var numbers = input.Split(' ').Select(int.Parse)
                .GetEnumerator();
            return ParseTree(() => {
                numbers.MoveNext(); return numbers.Current; });

        }
    
        public static int Part1Solver(string[] input)
        {
            var rootNode = ParseTree(input[0]);
            return MoreEnumerable.TraverseDepthFirst(rootNode, n => n.ChildNodes).Sum(n => n.MetaData.Sum());
        }

        public static int Part2Solver(string[] input)
        {
            var rootNode = ParseTree(input[0]);
            return rootNode.Value;
        }
    }
}
