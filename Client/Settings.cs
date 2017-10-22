﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Settings
    {
        private int gameBoardWidth;
        private int gameBoardHeight;
        private int speedMultiplicator;

        public int GameBoardWidth
        {
            get
            {
                return this.gameBoardWidth;
            }
            private set
            {
                if (value < 60)
                {
                    throw new ArgumentException("The game board width must be equal or greather than 60!");
                }
                else if (value > Console.LargestWindowWidth)
                {
                    throw new ArgumentException("The game board width must not be greather than the largest window width (" + Console.LargestWindowWidth + ")!");
                }

                this.gameBoardWidth = value;
            }
        }

        public int GameBoardHeight
        {
            get
            {
                return this.gameBoardHeight;
            }
            private set
            {
                if (value < 25)
                {
                    throw new ArgumentException("The game board height must be equal or greather than 25!");
                }
                else if (value > Console.LargestWindowHeight)
                {
                    throw new ArgumentException("The game board height must not be greather than the largest window height (" + Console.LargestWindowHeight + ")!");
                }

                this.gameBoardHeight = value;
            }
        }

        public int SpeedMultiplicator
        {
            get
            {
                return this.speedMultiplicator;
            }
            private set
            {
                if (value < 1 || value > 6)
                {
                    throw new ArgumentException("The speed multiplicator must be between 1 and 6!");
                }

                this.speedMultiplicator = value;
            }
        }

        public void SetGameSettings()
        {
            Console.Title = "Snake Online | Singleplayer | Set Game Settings";
            Console.SetWindowSize(80, 25);

            bool validSettings = false;

            while (validSettings == false)
            {
                try
                {
                    Menu.PrintGameHeader();

                    Console.WriteLine();
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("[!] Set the game settings below for the singleplayer game!");
                    Console.WriteLine("For more information about the game settings view the help!");
                    Console.WriteLine();

                    Console.CursorVisible = true;

                    Console.Write("Enter the game board height: ");
                    string gameBoardHeight = Console.ReadLine();

                    if (CheckIfStringIsInteger(gameBoardHeight) == false)
                    {
                        throw new ArgumentException("The game board height must be an integer!");
                    }
                    else
                    {
                        this.GameBoardHeight = Int32.Parse(gameBoardHeight);
                    }

                    Console.WriteLine();

                    Console.Write("Enter the game board width: ");
                    string gameBoardWidth = Console.ReadLine();

                    if (CheckIfStringIsInteger(gameBoardWidth) == false)
                    {
                        throw new ArgumentException("The game board width must be an integer!");
                    }
                    else
                    {
                        this.GameBoardWidth = Int32.Parse(gameBoardWidth);
                    }

                    Console.WriteLine();

                    Console.Write("Enter the speed multiplicator: ");
                    string speedMultiplicator = Console.ReadLine();

                    if (CheckIfStringIsInteger(speedMultiplicator) == false)
                    {
                        throw new ArgumentException("The speed multiplicator must be an integer!");
                    }
                    else
                    {
                        this.SpeedMultiplicator = Int32.Parse(speedMultiplicator);
                    }

                    validSettings = true;
                }
                catch (Exception e)
                {
                    Console.CursorVisible = false;

                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey(true);

                    Console.Clear();
                }            
            }
        }

        private bool CheckIfStringIsInteger(string input)
        {
            int checkInput;

            if (input == null || input == string.Empty)
            {
                return false;
            }
            else if (Int32.TryParse(input, out checkInput) == false)
            {
                return false;
            }

            return true;
        }
    }
}