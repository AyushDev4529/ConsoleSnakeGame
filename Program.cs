using System;
namespace ConsoleSnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            GameLogic();

        }

        // This method contains the main game logic for the Snake Game. It initializes the snake's position and spawns food on the map. The method then updates the map with the snake's position and the food's position. This is a placeholder for additional game logic, such as handling user input for snake movement, collision detection, and score tracking.
        private static void GameLogic()
        {
            bool isGameOver = false;
            // Placeholder for the main game logic, including snake movement, collision detection, and score tracking.
            Console.Clear();
            // Prompt the user to choose a map size for the Snake Game
            int choice = ChooseMapSize();
            // Generate the map based on the user's choice
            char[,] map = MapGenrator(choice);

            int[] snakePos = SnakePos();
            int[] fruitPos = SpawnFood(map);

            while (!isGameOver)
            {
                UpdateMap(map, snakePos, fruitPos); // Update the map with the snake's position and food's position);
                Console.WriteLine("\nPress 'Q' to quit the game.");

                char playerInput = PlayerInput(); // Handle player input for snake movement (not implemented yet)
                
                snakePos = PlayerMovement(playerInput, snakePos); // Update the snake's position based on player input (not implemented yet)
            }
        }

        // This method handles player input for controlling the snake's movement in the Snake Game. It reads a key press from the console and checks if the input is valid. The valid inputs are 'W', 'A', 'S', 'D' for movement and 'Q' to quit the game. If the input is valid, it returns the corresponding character. If the input is invalid, it recursively calls itself to prompt the user again for valid input.
        private static char PlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            char keyInfoUpper = char.ToUpper(keyInfo.KeyChar);

            if (keyInfoUpper == 'Q')
            {
                return 'Q';
            }
            else if (keyInfoUpper == 'W' || keyInfoUpper == 'A' || keyInfoUpper == 'S' || keyInfoUpper == 'D')
            {
                return keyInfoUpper;
            }
            else
            {
                return PlayerInput();
            } 
        }


        private static int[] PlayerMovement(char input, int[] snakePos)
        {
            int snakePosX = snakePos[0];
            int snakePosY = snakePos[1];
            // Update the snake's position based on the input (W, A, S, D)
            switch (input)
            {
                case 'W':
                    snakePosX--; // Move up
                    break;
                case 'A':
                    snakePosY--; // Move left
                    break;
                case 'S':
                    snakePosX++; // Move down
                    break;
                case 'D':
                    snakePosY++; // Move right
                    break;
                case 'Q':
                    Environment.Exit(0);// Exit the game
                    break;
            }
            return new int[2] { snakePosX, snakePosY }; // Return the updated snake position
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
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    return ChooseMapSize();
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

        // This method initializes the snake's position on the map. It sets the initial coordinates of the snake to (0, 0) and returns an array containing these coordinates. The snake's position is represented as an array of two integers, where the first element is the x-coordinate and the second element is the y-coordinate.

        private static int[] SnakePos()
        { 
            int x = 0;
            int y = 0;
            int[] snakePos = new int[2] { x, y };

            return snakePos;
        }

        // This method spawns food on the map at a random empty position. It takes a two-dimensional character array representing the map as input. The method uses a random number generator to select coordinates (x, y) within the bounds of the map. It checks if the selected position is empty (represented by '.') and continues generating new coordinates until an empty cell is found. Once an empty cell is located, it places food (represented by 'F') at that position on the map and returns an array containing the coordinates of the spawned food.
        private static int[] SpawnFood(char[,] map)
        {
            Random rand = new Random();
            int x, y;
            do
            {
                x = rand.Next(0, map.GetLength(0));
                y = rand.Next(0, map.GetLength(1));
            } while (map[x, y] != '.'); // Ensure food spawns on an empty cell
            map[x, y] = 'F'; // Represent food with 'F'
            return new int[2] { x, y };

        }


        // This method updates the map with the snake's new position and the food's position. It takes a two-dimensional character array representing the map, an array containing the snake's coordinates, and an array containing the food's coordinates as input. The method clears the console, updates the map to represent the snake with '0' at its new position, and represents food with 'F' at its position. Finally, it calls the DisplayMap method to show the updated map on the console.
        private static void UpdateMap(char[,] map, int[] snakePosXY, int[] foodXY)
        {
            int snakeX = snakePosXY[0];
            int snakeY = snakePosXY[1];
            int foodX = foodXY[0];
            int foodY = foodXY[1];
            // Clear the console
            Console.Clear();
            // Update the map with the snake's new position
            map[snakeX, snakeY] = '0'; // Represent the snake with '0'
            // Update the map with the food's position
            map[foodX, foodY] = 'F'; // Represent food with 'F'
            // Display the updated map
            DisplayMap(map);
        }
}
}
