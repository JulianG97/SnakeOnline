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
        private int fruitMultiplicator;
        private int songNumber;

        public Settings()
        {
            this.GameBoardHeight = 25;
            this.GameBoardWidth = 60;
            this.SpeedMultiplicator = 1;
            this.FruitMultiplicator = 1;
            this.SongNumber = 0;
        }

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
                if (value < 1 || value > 3)
                {
                    throw new ArgumentException("The speed multiplicator must be between 1 and 3!");
                }

                this.speedMultiplicator = value;
            }
        }

        public int FruitMultiplicator
        {
            get
            {
                return this.fruitMultiplicator;
            }
            private set
            {
                if (value < 1 || value > 3)
                {
                    throw new ArgumentException("The fruit multiplicator must be between 1 and 3!");
                }

                this.fruitMultiplicator = value;
            }
        }

        public int SongNumber
        {
            get
            {
                return this.songNumber;
            }
            private set
            {
                if (value < 0 || value > 2)
                {
                    throw new ArgumentException("The song number must be between 0 and 2!");
                }

                this.songNumber = value;
            }
        }

        public void SetGameSettings()
        {
            Console.Title = "Snake Online | Singleplayer | Set Game Settings";

            WindowWatcher windowWatcher = new WindowWatcher(25, 80, true);
            windowWatcher.Start();

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

                    Console.Write("Enter the game board height (max height: {0}): ", Console.LargestWindowHeight);
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

                    Console.Write("Enter the game board width (max width: {0}): ", Console.LargestWindowWidth);
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

                    Console.Write("Enter the speed multiplicator (1-3): ");
                    string speedMultiplicator = Console.ReadLine();

                    if (CheckIfStringIsInteger(speedMultiplicator) == false)
                    {
                        throw new ArgumentException("The speed multiplicator must be an integer!");
                    }
                    else
                    {
                        this.SpeedMultiplicator = Int32.Parse(speedMultiplicator);
                    }

                    Console.WriteLine();

                    Console.Write("Enter the fruit multiplicator (1-3): ");
                    string fruitMultiplicator = Console.ReadLine();

                    if (CheckIfStringIsInteger(fruitMultiplicator) == false)
                    {
                        throw new ArgumentException("The fruit multiplicator must be an integer!");
                    }
                    else
                    {
                        this.FruitMultiplicator = Int32.Parse(fruitMultiplicator);
                    }

                    Console.WriteLine();

                    Console.Write("Enter the song number (0-2): ");
                    string songNumber = Console.ReadLine();

                    if (CheckIfStringIsInteger(songNumber) == false)
                    {
                        throw new ArgumentException("The song number must be an integer!");
                    }
                    else
                    {
                        this.SongNumber = Int32.Parse(songNumber);
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

            windowWatcher.Stop();
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
