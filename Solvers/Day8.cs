using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solvers
{
    public static class Day8
    {
        public class Node
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

        public static Node ParseTree(IEnumerator<int> numbers, Node parent)
        {
            var newNode = new Node();
            numbers.MoveNext();
            var childNodeCount = numbers.Current;
            numbers.MoveNext();
            var metaDataCount = numbers.Current;
            if (parent != null)
            {
                parent.ChildNodes.Add(newNode);
            }
            for(int child = 0; child < childNodeCount; child++)
            {
                ParseTree(numbers, newNode);
            }
            for (int meta = 0; meta < metaDataCount; meta++)
            {
                numbers.MoveNext();
                newNode.MetaData.Add(numbers.Current);
            }
            return newNode;
        }

        public static int Part1Solver(string[] input)
        {
            var numbers = input[0].Split(' ').Select(int.Parse).GetEnumerator();
            var rootNode = ParseTree(numbers, null);
            return MoreEnumerable.TraverseDepthFirst(rootNode, n => n.ChildNodes).Sum(n => n.MetaData.Sum());
        }


        public static int Part2Solver(string[] input)
        {
            var numbers = input[0].Split(' ').Select(int.Parse).GetEnumerator();
            var rootNode = ParseTree(numbers, null);
            return rootNode.Value;
        }
    }
}
