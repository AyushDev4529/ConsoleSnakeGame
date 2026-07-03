using System;

//TODO :  Check for collision with Snake itself
//TODO :  Implement Score Tracking
//TODO :  Implement Snake Growth on Eating Food
//TODO :  Implement Food Quantity scale as per map size
//TODO :  Spawn Snake in Center of the Map
//TODO :  Implement Game Over Screen with Score Display
//TODO :  Implement Game Restart Option
//TODO :  Implement Snake Movement with Arrow Keys

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
            Console.Clear();    
            int choice = InputHandler.ChooseMapSize();
            char[,] map = GameManager.MapGenrator(choice);

            int[] snakePos = GameManager.SnakePos();
            int[] fruitPos = GameManager.SpawnFood(map);

            while (!isGameOver)
            {
                Renderer.ClearScreen();
                GameManager.ClearMap(map, snakePos);
                GameManager.DetectCollision(snakePos, map);
                GameManager.DetectFoodCollision(snakePos, fruitPos, map);
                GameManager.UpdateMap(map, snakePos, fruitPos);
                
                Renderer.DisplayMap(map);
                Console.WriteLine("\nPress 'Q' to quit the game.");
                
                char playerInput = InputHandler.PlayerInput(); 
                
                snakePos = GameManager.PlayerMovement(playerInput, snakePos); 
            }
        }     
}
}
