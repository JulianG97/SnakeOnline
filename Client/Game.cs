﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Client
{
    public class Game
    {
        private KeyboardWatcher keyboardWatcher;
        private WindowWatcher windowWatcher;
        private Snake snake;
        private Music music;
        private List<Fruit> fruits;
        private Thread spawnFruits;
        private Settings gameSettings;
        private bool exit;

        public Game(Settings gameSettings)
        {
            this.music = new Music();
            this.gameSettings = gameSettings;
            this.keyboardWatcher = new KeyboardWatcher();
            this.windowWatcher = new WindowWatcher(this.gameSettings.GameBoardHeight, this.gameSettings.GameBoardWidth, false);
            this.spawnFruits = new Thread(SpawnFruit);
            this.fruits = new List<Fruit>();
            this.exit = false;
        }

        private int Score
        {
            get;
            set;
        }

        public void Start()
        {
            Console.CursorVisible = false;

            this.windowWatcher.Start();

            int moveDelay = 0;

            switch (gameSettings.SpeedMultiplicator)
            {
                case 1:
                    moveDelay = 100;
                    break;
                case 2:
                    moveDelay = 50;
                    break;
                case 3:
                    moveDelay = 25;
                    break;
            }

            snake = new Snake(ConsoleColor.Green, 2, 0, moveDelay, MoveDirection.RIGHT, 'O');
            SnakePart part1 = new SnakePart(1, 0, snake.Color, 'O');
            snake.Head.Next = part1;
            part1.Previous = snake.Head;
            SnakePart part2 = new SnakePart(0, 0, snake.Color, 'O');
            part1.Next = part2;
            part2.Previous = part1;

            snake.DrawWholeSnake();
            snake.isMoving = true;
            snake.SnakeMoved += CheckIfFruitEaten;
            snake.SnakeCollided += SnakeDied;

            this.keyboardWatcher.NewKeyPressed += NewKeyPressed;
            this.keyboardWatcher.Start();

            this.spawnFruits.Start();

            Console.Title = "Snake Online | Singleplayer | Score: " + this.Score;

            Song song = new Song();

            switch (gameSettings.SongNumber)
            {
                case 0:
                    song = Song.Song0;
                    break;
                case 1:
                    song = Song.Song1;
                    break;
                case 2:
                    song = Song.Song2;
                    break;
            }

            this.music.PlayMusic(song);

            snake.Move();
        }

        public void SpawnFruit()
        {
            while (exit == false)
            {
                Fruit fruit = null;
                int positionX;
                int positionY;

                GenerateFruitPosition(out positionX, out positionY);

                Random random = new Random();
                int randomNumber = random.Next(1, 101);

                if (randomNumber <= 10)
                {
                    fruit = new Papaya(positionX, positionY);
                }
                else if (randomNumber > 10 && randomNumber <= 50)
                {
                    fruit = new Banana(positionX, positionY);
                }
                else if (randomNumber > 50)
                {
                    fruit = new Apple(positionX, positionY);
                }

                this.fruits.Add(fruit);
                fruit.Draw();

                int fruitDelay = 0;

                switch (gameSettings.FruitMultiplicator)
                {
                    case 1:
                        fruitDelay = 10000;
                        break;
                    case 2:
                        fruitDelay = 5000;
                        break;
                    case 3:
                        fruitDelay = 2500;
                        break;
                }

                Thread.Sleep(fruitDelay);
            }
        }

        private void GenerateFruitPosition(out int positionX, out int positionY)
        {
            while (true)
            {
                Random random = new Random();

                int randomPositionX = random.Next(0, Console.WindowWidth);
                int randomPositionY = random.Next(0, Console.WindowHeight);

                if (LegitFruitPosition(randomPositionX, randomPositionY) == true)
                {
                    positionX = randomPositionX;
                    positionY = randomPositionY;
                    break;
                }
            }
        }

        private bool LegitFruitPosition(int positionX, int positionY)
        {
            SnakePart currentPart = this.snake.Head;

            while (currentPart != null)
            {
                if (currentPart.PositionX == positionX && currentPart.PositionY == positionY)
                {
                    return false;
                }

                currentPart = currentPart.Next;
            }

            foreach (Fruit fruit in this.fruits)
            {
                if (fruit.PositionX == positionX && fruit.PositionY == positionY)
                {
                    return false;
                }
            }

            return true;
        }

        public void NewKeyPressed(object sender, NewKeyPressedEventArgs args)
        {
            snake.ChangeDirection(args.Key);
        }

        private void CheckIfFruitEaten(object sender, EventArgs args)
        {
            foreach (Fruit fruit in this.fruits)
            {
                if (fruit.PositionX == this.snake.Head.PositionX && fruit.PositionY == this.snake.Head.PositionY)
                {
                    this.music.PlaySound(Sound.Sound0);

                    this.Score += fruit.Points;
                    this.fruits.Remove(fruit);

                    Console.Title = "Snake Online | Singleplayer | Score: " + this.Score;

                    snake.AddSnakeParts += fruit.SnakeParts;

                    break;
                }
            }
        }

        public void SnakeDied(object sender, EventArgs args)
        {
            this.music.StopMusic();
            this.music.PlaySound(Sound.Sound1);
            GameOver();
        }

        public void GameOver()
        {
            this.exit = true;

            try
            {
                this.spawnFruits.Abort();
            }
            catch (Exception) { }

            this.keyboardWatcher.Stop();
            this.windowWatcher.Stop();
            this.snake.isMoving = false;

            Console.Clear();

            this.windowWatcher = new WindowWatcher(12, 62, false);
            this.windowWatcher.Start();

            Console.Title = "Snake Online | Singeplayer | Game Over";

            Menu.PrintGameHeader();

            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("            " + "You died! Your score was {0}!", this.Score);
            Console.WriteLine();
            Console.WriteLine("            " + "Press [ENTER] to return to the menu!");

            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            this.windowWatcher.Stop();

            Console.Clear();

            Menu.DisplayMainMenu();
        }
    }
}
