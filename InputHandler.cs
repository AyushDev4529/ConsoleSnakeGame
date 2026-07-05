using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnakeGame
{
    internal class InputHandler
    {

        // This method handles player input for controlling the snake's movement in the Snake Game. It reads a key press from the console and checks if the input is valid. The valid inputs are 'W', 'A', 'S', 'D' for movement and 'Q' to quit the game. If the input is valid, it returns the corresponding character. If the input is invalid, it prompts the user again for valid input.
        public static char PlayerInput()
        {

            while (true)
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
                    Console.WriteLine("\nInvalid input. Please enter W, A, S, D for movement or Q to quit.");
                }

            }

        }




        // This method prompts the user to choose a map size for the Snake Game. It displays a menu with three options: 1 for a 24x24 map, 2 for a 36x36 map, and 3 to exit the game. The method reads the user's input and checks if it is valid (between 1 and 3). If the input is valid, it returns the corresponding integer value. If the input is invalid, it clears the console and prompts the user again for valid input.
        public static int ChooseMapSize()
        {
            while (true)
            {
                int input = 0;
                Console.WriteLine("Welcome to the Snake Game! \n !!Choose the Map Size.!! \n 1 : 24*24 \n 2 : 36*36  \n 3 : EXIT");
                string? inputChar = Console.ReadLine();
                if ((int.TryParse(inputChar, out input)) && input >= 1 && input <= 3)
                {
                    if (input == 3)
                    {
                        Environment.Exit(0);
                    }
                    return input;

                }
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            }
        }


    }
}
