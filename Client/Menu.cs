﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Menu
    {
        public static void DisplayGameMenu()
        {
            string[] menuItems = { "Singleplayer (Offline)", "Multiplayer (Online)", "Help", "Exit" };

            Console.CursorVisible = false;

            bool exit = false;
            int menuPosition = 0;

            while (exit == false)
            {
                Console.Clear();

                PrintGameHeader();

                Console.WriteLine();
                Console.WriteLine();

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == menuPosition)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine("                    " + menuItems[i]);
                }

                Console.WriteLine();

                PrintSnake();

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("         " + "(C) 2017 Patrick Gamauf and Julian Gamauf");

                ConsoleKeyInfo cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (menuPosition - 1 >= 0)
                        {
                            menuPosition--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (menuPosition + 1 < menuItems.Length)
                        {
                            menuPosition++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        switch (menuPosition)
                        {
                            case 0:
                                Console.Clear();
                                Game game = new Game();
                                game.Start();
                                break;
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                exit = true;
                                break;
                        }
                        break;
                }
            }
        }

        public static void PrintGameHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("   _____             _           ____        _ _             ");
            Console.WriteLine("  / ____|           | |         / __ \\      | (_)            ");
            Console.WriteLine(" | (___  _ __   __ _| | _____  | |  | |_ __ | |_ _ __   ___  ");
            Console.WriteLine("  \\___ \\| '_ \\ / _` | |/ / _ \\ | |  | | '_ \\| | | '_ \\ / _ \\ ");
            Console.WriteLine("  ____) | | | | (_| |   <  __/ | |__| | | | | | | | | |  __/ ");
            Console.WriteLine(" |_____/|_| |_|\\__,_|_|\\_\\___|  \\____/|_| |_|_|_|_| |_|\\___| ");

            Console.ResetColor();
        }

        public static void PrintSnake()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("                           __");
            Console.WriteLine("                          {0O}");
            Console.WriteLine("                          \\__/");
            Console.WriteLine("                          /^/");
            Console.WriteLine("                         ( (");
            Console.WriteLine("                         \\_\\_____");
            Console.WriteLine("                         (_______)");
            Console.WriteLine("                        (_________()Oo");

            Console.ResetColor();
        }
    }
}