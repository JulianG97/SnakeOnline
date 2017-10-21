using System;
using System.Collections.Generic;

namespace Client
{
    public class Game
    {
        private KeyboardWatcher keyboardWatcher;
        private Snake snake;
        private List<Fruit> fruits;
        private bool exit;

        public Game()
        {
            this.keyboardWatcher = new KeyboardWatcher();
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

            snake = new Snake(ConsoleColor.Green, 0, 0, 100, MoveDirection.RIGHT);
            SnakePart part1 = new SnakePart(1, 0, ConsoleColor.Green, ' ');
            snake.Head.Next = part1;
            part1.Previous = snake.Head;
            snake.DrawWholeSnake();
            snake.isMoving = true;
            snake.FruitEaten += IncreaseScore;

            this.keyboardWatcher.NewKeyPressed += NewKeyPressed;
            this.keyboardWatcher.Start();

            snake.Move();
        }

        public void SpawnFruit()
        {
            while (exit == false)
            {
                Fruit fruit = null;

                Random random = new Random();
                int randomNumber = random.Next(1, 101);

                if (randomNumber <= 10)
                {
                    fruit = new Kiwi();
                }
                else if (randomNumber > 10 && randomNumber <= 50)
                {
                    fruit = new Banana();
                }
                else if (randomNumber > 50)
                {
                    fruit = new Apple();
                }
            }
        }

        public void NewKeyPressed(object sender, NewKeyPressedEventArgs args)
        {
            snake.ChangeDirection(args.Key);
        }

        public void IncreaseScore(object sender, FruitEatenEventArgs args)
        {
            this.Score += args.Points;
        }
    }
}
