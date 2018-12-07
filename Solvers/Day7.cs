using MoreLinq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Solvers
{
    public static class Day7
    {
        public static string Part1Solver(string[] input)
        {
            var tree = new Dictionary<char, Links>();
            foreach(var (pre,next) in input.Select(l => (l[5],l[36])))
            {
                if (!tree.ContainsKey(pre))
                    tree[pre] = new Links();
                if (!tree.ContainsKey(next))
                    tree[next] = new Links();

                tree[pre].Children.Add(next);
                tree[next].Parents.Add(pre);
            }

            
            var visited = new List<char>();

            while (true)
            {
                var rootNode = tree.Where(n => n.Value.Parents.Count == 0).OrderBy(n => n.Key).FirstOrDefault();
                if (rootNode.Key == 0) break;
                visited.Add(rootNode.Key);
                tree.Remove(rootNode.Key);
                foreach (var n in tree.Values)
                {
                    n.Parents.Remove(rootNode.Key);
                }

            }
            return visited.ToDelimitedString("");
        }

        class Links
        {
            public HashSet<char> Parents { get;  } = new HashSet<char>();
            public HashSet<char> Children { get; } = new HashSet<char>();
        }

        public static int Part2Solver(string[] input, int minutes, int workers)
        {
            var tree = new Dictionary<char, Links>();
            foreach (var (pre, next) in input.Select(l => (l[5], l[36])))
            {
                if (!tree.ContainsKey(pre))
                    tree[pre] = new Links();
                if (!tree.ContainsKey(next))
                    tree[next] = new Links();

                tree[pre].Children.Add(next);
                tree[next].Parents.Add(pre);
            }


            var elves = Enumerable.Range(0,workers).Select(_ => new ElfState()).ToArray();
            var visited = new List<char>();
            var timeTaken = 0;
            bool done = false;
            while (!(done && elves.All(e => e.MinutesLeft == 0)))
            {
                timeTaken++;
                foreach (var elf in elves)
                {
                    if (elf.MinutesLeft == 0)
                    {
                        if (elf.CurrentTask != '.')
                        {
                            visited.Add(elf.CurrentTask);
                            foreach (var n in tree.Values)
                            {
                                n.Parents.Remove(elf.CurrentTask);
                            }

                            elf.CurrentTask = '.';
                        }
                    }
                }

                foreach (var elf in elves)
                {
                    if (elf.MinutesLeft == 0)
                    {
                        var nextTask = tree.Where(n => n.Value.Parents.Count == 0).OrderBy(n => n.Key).FirstOrDefault();
                        if (nextTask.Key == 0)
                        {
                            if (tree.Count == 0)
                                done = true;
                        }
                        else
                        {
                            elf.MinutesLeft = minutes + nextTask.Key - 'A' + 1;
                            elf.CurrentTask = nextTask.Key;
                            tree.Remove(elf.CurrentTask);
                        }
                    }
                    Console.Write($"{elf.CurrentTask}   ");

                    if (elf.MinutesLeft > 0) elf.MinutesLeft--;
                }
                Console.WriteLine();

            }
            return timeTaken;
        }

        class ElfState
        {
            public char CurrentTask { get; set; } = '.';
            public int MinutesLeft { get; set; }
        }
    }
}
