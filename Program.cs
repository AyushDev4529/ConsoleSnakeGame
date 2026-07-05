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
            bool isEatingFood = false;
            int score = 0;
            Console.Clear();    
            int choice = InputHandler.ChooseMapSize();
            char[,] map = GameManager.MapGenrator(choice);
            List<int[]> snakeBody = new List<int[]>();
            int[] snakePos = GameManager.SnakePos(map);
            snakeBody.Add(snakePos);
            int[][] fruitPos = GameManager.SpawnFoodMultiple(map);

            Console.WriteLine("Press 'W' to move up, 'S' to move down, 'A' to move left, and 'D' to move right.");
            char playerInput = InputHandler.PlayerInput();

            while (!isGameOver)
            {
                Renderer.ClearScreen();
                GameManager.ClearMap(map, snakeBody);
                isGameOver = GameManager.DetectCollision(snakeBody, map);



                if (!isGameOver)
                {

                    isEatingFood = GameManager.DetectFoodCollision(snakeBody, fruitPos, map);
                    

                    Renderer.DisplayScore(score);
                    GameManager.UpdateMap(map, snakeBody, fruitPos);

                    Renderer.DisplayMap(map);
                    Console.WriteLine("\nPress 'Q' to quit the game.");

                    System.Threading.Thread.Sleep(300);

                    while(Console.KeyAvailable)
                    {
                        playerInput = InputHandler.PlayerInput();
                    }
                  
                        
                   

                GameManager.PlayerMovement(playerInput,snakeBody,isEatingFood);
                    if(isEatingFood)
                    {
                        score = GameManager.CountScore(isEatingFood,score);
                        isEatingFood = false;
                    }

                }
            }

            Renderer.DisplayGameOver(score);
            
        }     
}
}

