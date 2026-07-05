using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeGame
{
    internal class Renderer
    {
        public static void ClearScreen()
        {
            Console.Clear();
        }
        public static void DisplayMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }

        }

        public static void DisplayScore(int score)
        {
            Console.WriteLine($"Score: {score}");
        }

        public static void DisplayGameOver(int score)
        {
            Console.Clear();
            Console.WriteLine("Game Over! Press any key to exit.");
            DisplayScore(score);
            Environment.Exit(0 );
        }
    }
}
