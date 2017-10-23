using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Menu
    {
        public static void DisplayMainMenu()
        {
            Console.Title = "Snake Online";
            string[] menuItems = { "Singleplayer (Offline)", "Multiplayer (Online)", "Help", "Exit" };

            Console.SetWindowSize(61, 25);
            Console.CursorVisible = false;

            int menuPosition = DisplayMenu(menuItems, true, true);

            switch (menuPosition)
            {
                case 0:
                    Console.Clear();
                    DisplaySingleplayerMenu();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    //Environment.Exit(0);
                    break;
            }
        }

        public static void DisplaySingleplayerMenu()
        {
            Console.Title = "Snake Online | Singleplayer";
            string[] menuItems = { "Quick Game (Default Settings)", "Advanced Game (Custom Settings)", "Return To Main Menu..." };

            int menuPosition = DisplayMenu(menuItems, true, true);

            switch (menuPosition)
            {
                case 0:
                    Console.Clear();

                    Settings gameSettings = new Settings();

                    Console.Clear();

                    Game game = new Game(gameSettings);
                    game.Start();
                    break;
                case 1:
                    Console.Clear();

                    gameSettings = new Settings();
                    gameSettings.SetGameSettings();

                    Console.Clear();

                    game = new Game(gameSettings);
                    game.Start();
                    break;
                case 2:
                    DisplayMainMenu();
                    break;
            }
        }

        private static int DisplayMenu(string[] menuItems, bool displaySnake, bool displayCopyright)
        {
            int menuPosition = 0;

            while (true)
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

                    Console.WriteLine("                " + menuItems[i]);
                }

                if (displaySnake == true)
                {
                    Console.WriteLine();

                    PrintSnake();
                }

                if (displayCopyright == true)
                {
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("         " + "(C) 2017 Patrick Gamauf and Julian Gamauf");
                }

                ConsoleKeyInfo cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (menuPosition - 1 >= 0)
                        {
                            menuPosition--;
                        }
                        else if (menuPosition - 1 < 0)
                        {
                            menuPosition = menuItems.Length - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (menuPosition + 1 < menuItems.Length)
                        {
                            menuPosition++;
                        }
                        else if (menuPosition + 1 > menuItems.Length - 1)
                        {
                            menuPosition = 0;

                        }
                        break;
                    case ConsoleKey.Enter:
                        return menuPosition;
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
