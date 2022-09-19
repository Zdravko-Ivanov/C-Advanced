using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P01
{
    internal class Program
    {
        static void Main()
        {
            const int SINK_COUNT = 40;
            const int OVEN_COUNT = 50;
            const int COUTERTOP_COUNT = 60;
            const int WALL_COUNT = 70;
           
            Dictionary<string, int> tiles = new Dictionary<string, int>()
            {
                { "Sink",  0},
                { "Oven",  0},
                { "Countertop", 0},
                { "Wall", 0},
                { "Floor", 0}

            };

            Stack<int> whiteTiles = new Stack<int>();
            Queue<int> greyTiles = new Queue<int>();

            int[] wT = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] gT = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < wT.Length; i++)
            {
                whiteTiles.Push(wT[i]);
            }
            for(int i = 0; i < gT.Length; i++)
            {
                greyTiles.Enqueue(gT[i]);
            }


            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                if (greyTiles.Peek() == whiteTiles.Peek())
                {
                    int temp = greyTiles.Peek() + whiteTiles.Peek();
                    if (temp == SINK_COUNT)
                    {
                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                        tiles["Sink"]++;
                    }
                    else if (temp == OVEN_COUNT)
                    {

                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                        tiles["Oven"]++;
                    }
                    else if (temp == COUTERTOP_COUNT)
                    {

                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                        tiles["Countertop"]++;
                    }
                    else if (temp == WALL_COUNT)
                    {

                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                        tiles["Wall"]++;
                    }
                    else
                    {
                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                        tiles["Floor"]++;
                    }
                }
                else
                {
                    int wtt = whiteTiles.Peek();
                    int gtt = greyTiles.Peek();

                    whiteTiles.Pop();
                    greyTiles.Dequeue();

                    whiteTiles.Push(wtt/2);
                    greyTiles.Enqueue(gtt);

                }

            }

            if (whiteTiles.Count == 0)
                Console.WriteLine("White tiles left: none");
            else
                Console.WriteLine($"White tiles left: {string.Join(", ",whiteTiles.ToArray())}" );

            if (greyTiles.Count == 0)
                Console.WriteLine("Grey tiles left: none");
            else
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles.ToArray())}");


            foreach (var tile in tiles.Where(tile => tile.Value > 0).OrderByDescending(tile => tile.Value).ThenBy(tile => tile.Key))
            {
                Console.WriteLine($"{tile.Key}: {tile.Value}");
            }
       
        }
    }
}
