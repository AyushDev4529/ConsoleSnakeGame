using System;
namespace ConsoleSnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            // Prompt the user to choose a map size for the Snake Game
            int choise = ChooseMapSize();
            // Generate the map based on the user's choice
            char[,] map = MapGenrator(choise);
            //Display the generated map (for demonstration purposes)
            DisplayMap(map);
 
        }

        // This method prompts the user to choose a map size for the Snake Game. It presents three options: 24x24, 36x36, or EXIT. The user's input is read and parsed as an integer. Depending on the input, the method either returns the chosen size (1 or 2) or exits the program if the user selects option 3. If the input is invalid, it prompts the user again for a valid choice.
        private static int ChooseMapSize()
        {
            int input = 0;
            Console.WriteLine("Welcome to the Snake Game! \n !!Choose the Map Size.!! \n 1 : 24*24 \n 2 : 36*36  \n 3 : EXIT");
            input = int.Parse(Console.ReadLine()!);//TODO: Add input validation to handle non-integer inputs and out-of-range values.
            switch (input)
            {
                case 1:
                case 2:
                    return input;
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    return ChooseMapSize();
                    break;
            }
            return input;
        }


        // This method generates a map for the Snake Game based on the user's chosen size. It takes an integer parameter representing the size choice and maps it to specific dimensions (24x24, 36x36, or 64x64). The method creates a two-dimensional integer array to represent the map and returns it. It also prints a message indicating the size of the generated map.
        private static char[,] MapGenrator(int size)
        {
            switch(size)
            {
                case 1:
                    size = 24;
                    break;
                case 2:
                    size = 36;
                    break;
                default:
                    size = 24;
                    break;
            }

            char[,] map = new char[size, size];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                   map[i, j] = '.';
                }
            }
            Console.WriteLine($"Generating map of size {size}*{size} ....");
            Task.Delay(1000).Wait(); // Simulate a delay for map generation
            return map;

        }

        private static void DisplayMap(char[,] map)
        {
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j<map.GetLength(1); j++)
                {
                    Console.Write(map[i,j]);
                }
                Console.WriteLine();
            }

        }
    }
    
}
