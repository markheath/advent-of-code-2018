using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Solvers
{
    public static class Day13
    {
        public static string Part1Solver(string[] input)
        {
            var carts = GetCarts(input);
            for(int iteration = 0; true; iteration++)
            {
                foreach(var cart in carts.OrderBy(c => c.Y).ThenBy(c => c.X))
                {
                    cart.Move(input);
                    var collision = carts.Where(c => c != cart).Any(c => c.X == cart.X && c.Y == cart.Y);
                    if (collision)
                        return $"{cart.X},{cart.Y}";
                }
            }
        }

        private static IList<CartState> GetCarts(string[] map)
        {
            var carts = new List<CartState>();
            for (int y = 0; y < map.Length; y++)
                for (int x = 0; x < map[y].Length; x++)
                    if (map[y][x] == '<' ||
                        map[y][x] == '>' ||
                        map[y][x] == 'v' ||
                        map[y][x] == '^')
                        carts.Add(new CartState(x, y, map[y][x]));
            return carts;
        }

        class CartState
        {
            public CartState(int x, int y, char dir)
            {
                X = x;
                Y = y;
                Dir = dir;
            }
            public int X { get; private set; }
            public int Y { get; private set; }
            public char Dir { get; private set; } // < > v ^
            public int Intersections { get; private set; }
            public void Move(string[] map)
            {
                char newPos;
                switch(Dir)
                {
                    case '>':
                        X++;
                        newPos = map[Y][X];
                        if (newPos == '\\')
                        {
                            Dir = 'v';
                        }
                        else if (newPos == '/')
                        {
                            Dir = '^';
                        }
                        else if (newPos == '+')
                        {
                            if (Intersections % 3 == 0)
                                Dir = '^';
                            else if (Intersections % 3 == 2)
                                Dir = 'v';
                            Intersections++;
                        }
                        break;
                    case '<':
                        X--;
                        newPos = map[Y][X];
                        if (newPos == '\\')
                        {
                            Dir = '^';
                        }
                        else if (newPos == '/')
                        {
                            Dir = 'v';
                        }
                        else if (newPos == '+')
                        {
                            if (Intersections % 3 == 0)
                                Dir = 'v';
                            else if (Intersections % 3 == 2)
                                Dir = '^';
                            Intersections++;
                        }
                        break;
                    case 'v':
                        Y++;
                        newPos = map[Y][X];
                        if (newPos == '\\')
                        {
                            Dir = '>';
                        }
                        else if (newPos == '/')
                        {
                            Dir = '<';
                        }
                        else if (newPos == '+')
                        {
                            if (Intersections % 3 == 0)
                                Dir = '>';
                            else if (Intersections % 3 == 2)
                                Dir = '<';
                            Intersections++;
                        }
                        break;
                    case '^':
                        Y--;
                        newPos = map[Y][X];
                        if (newPos == '\\')
                        {
                            Dir = '<';
                        }
                        else if (newPos == '/')
                        {
                            Dir = '>';
                        }
                        else if (newPos == '+')
                        {
                            if (Intersections % 3 == 0)
                                Dir = '<';
                            else if (Intersections % 3 == 2)
                                Dir = '>';
                            Intersections++;
                        }
                        break;
                }
            }
        }
        

    }
}
