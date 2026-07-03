using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleSnakeGame
{
    internal class GameManager
    {
        // This method generates a map for the Snake Game based on the user's chosen size. It takes an integer parameter representing the size choice and maps it to specific dimensions (24x24, 36x36, or 64x64). The method creates a two-dimensional integer array to represent the map and returns it. It also prints a message indicating the size of the generated map.
        public static char[,] MapGenrator(int size)
        {
            switch (size)
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
            return map;

        }

        // This method updates the game map with the current positions of the snake and the food. It takes a 2D character array representing the map, an array containing the snake's X and Y coordinates, and an array containing the food's X and Y coordinates. The method updates the map by placing a '0' character at the snake's position and an 'F' character at the food's position. This allows for visual representation of the snake and food on the game map.
        public static void UpdateMap(char[,] map, int[] snakePosXY, int[] foodXY)
        {
            int snakeX = snakePosXY[0];
            int snakeY = snakePosXY[1];
            int foodX = foodXY[0];
            int foodY = foodXY[1];
            map[snakeX, snakeY] = '0'; // Represent the snake with '0'
            map[foodX, foodY] = 'F'; // Represent food with 'F'
        }

        // This method clears the previous position of the snake on the game map. It takes a 2D character array representing the map and an array containing the snake's current and previous X and Y coordinates. The method updates the map by replacing the character at the snake's previous position with a '.' character, effectively clearing that position. This is important for maintaining an accurate representation of the snake's movement on the map.
        public static void ClearMap(char[,] map, int[] snakePosXY)
        {
            int oldSnakeX = snakePosXY[2];
            int oldSnakeY = snakePosXY[3];
            map[oldSnakeX, oldSnakeY] = '.'; // Clear the old snake position

        }

        // This method handles the player's input for controlling the snake's movement in the Snake Game. It takes a character input representing the direction (W, A, S, D) and an array containing the snake's current X and Y coordinates. The method updates the snake's position based on the input: 'W' moves up, 'A' moves left, 'S' moves down, and 'D' moves right. If the player inputs 'Q', the game exits. The method returns an array containing the updated snake position along with its previous position for clearing purposes.
        public static int[] PlayerMovement(char input, int[] snakePos)
        {
            int snakePosX = snakePos[0];
            int snakePosY = snakePos[1];
            int oldSnakePosX = snakePosX;
            int oldSnakePosY = snakePosY;
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
            return new int[4] { snakePosX, snakePosY ,oldSnakePosX , oldSnakePosY}; // Return the updated snake position
        }

        // This method spawns food on the game map at a random position. It takes a 2D character array representing the map as input. The method generates random X and Y coordinates within the bounds of the map and checks if the position is empty (represented by '.'). If the position is empty, it places an 'F' character at that position to represent food. The method returns an array containing the X and Y coordinates of the spawned food.
        public static int[] SpawnFood(char[,] map)
        {
            Random rand = new Random();
            int x, y;
            do
            {
                x = rand.Next(0, map.GetLength(0));
                y = rand.Next(0, map.GetLength(1));
            } while (map[x, y] != '.');
            map[x, y] = 'F';
            return new int[2] { x, y };
        }

        // This method initializes the snake's position on the game map. It sets the initial coordinates of the snake to (0, 0) and returns an array containing the snake's current and previous positions. The previous positions are also set to (0, 0) initially, as the snake has not moved yet. This method is useful for setting up the initial state of the game before any player input is received.
        public static int[] SnakePos()
        {
            int x = 0;
            int y = 0;
            int[] snakePos = new int[4] { x, y , x , y};

            return snakePos;
        }

        // This method detects if the snake has collided with the walls of the game map. It takes an array containing the snake's current X and Y coordinates and a 2D character array representing the map. The method checks if the snake's position is outside the bounds of the map. If a collision with a wall is detected, it prints a "Game Over" message and exits the game. This method is essential for ensuring that the player cannot move the snake outside the playable area.
        public static void DetectCollision(int[] snakePos, char[,] map)
        {
            int snakeX = snakePos[0];
            int snakeY = snakePos[1];
            // Check for collision with walls
            if (snakeX < 0 || snakeX >= map.GetLength(0) || snakeY < 0 || snakeY >= map.GetLength(1))
            {
                Console.WriteLine("Game Over! You hit the wall.");
                Environment.Exit(0);
            }


        }

        // This method detects if the snake has collided with the food on the game map. It takes an array containing the snake's current X and Y coordinates, an array containing the food's X and Y coordinates, and a 2D character array representing the map. The method checks if the snake's position matches the food's position. If a collision is detected, it prints a message indicating that the food has been eaten and spawns new food at a random position on the map. The food's position is updated accordingly.
        public static void DetectFoodCollision(int[] snakePos, int[] foodPos, char[,] map)
        {
            int snakeX = snakePos[0];
            int snakeY = snakePos[1];
            int foodX = foodPos[0];
            int foodY = foodPos[1];
            // Check for collision with food
            if (snakeX == foodX && snakeY == foodY)
            {
                Console.WriteLine("You ate the food!");

                // Spawn new food
                int[] newFoodPos = SpawnFood(map);
                foodPos[0] = newFoodPos[0];
                foodPos[1] = newFoodPos[1];
            }
        }

        public static void GameOver()
        {
            Console.WriteLine("Game Over!");
            Renderer.DisplayGameOver();
        }
}
}
