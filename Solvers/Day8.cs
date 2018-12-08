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
            public int MetaDataCount { get; set; }
            public int ChildNodeCount { get; set; }
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

        public static IEnumerable<Node> ParseTree(IEnumerator<int> numbers, Node parent)
        {
            var newNode = new Node();
            numbers.MoveNext();
            newNode.ChildNodeCount = numbers.Current;
            numbers.MoveNext();
            newNode.MetaDataCount = numbers.Current;
            if (parent != null)
            {
                parent.ChildNodes.Add(newNode);
            }
            yield return newNode;
            for(int child = 0; child < newNode.ChildNodeCount; child++)
            {
                foreach (var children in ParseTree(numbers, newNode))
                {
                    yield return children;
                }
            }
            for (int meta = 0; meta < newNode.MetaDataCount; meta++)
            {
                numbers.MoveNext();
                newNode.MetaData.Add(numbers.Current);
            }

        }

        public static int Part1Solver(string[] input)
        {
            var numbers = input[0].Split(' ').Select(int.Parse).GetEnumerator();
            var nodes = ParseTree(numbers, null).ToList();
            return nodes.Sum(n => n.MetaData.Sum());
        }


        public static int Part2Solver(string[] input)
        {
            var numbers = input[0].Split(' ').Select(int.Parse).GetEnumerator();
            var nodes = ParseTree(numbers, null).ToList();
            return nodes[0].Value;
        }
    }
}
