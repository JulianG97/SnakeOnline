using System;

namespace Client
{
    public class Game
    {
        private KeyboardWatcher keyboardWatcher;
        private Snake snake;

        public Game()
        {
            this.keyboardWatcher = new KeyboardWatcher();
        }

        public void Start()
        {
            Console.CursorVisible = false;

            snake = new Snake(ConsoleColor.Green, 'X', 0, 0, 300, MoveDirection.RIGHT);
            SnakePart part1 = new SnakePart(1, 0, ConsoleColor.Green, 'X');
            snake.Head.Next = part1;
            part1.Previous = snake.Head;
            snake.DrawWholeSnake();
            snake.isMoving = true;

            this.keyboardWatcher.NewKeyPressed += NewKeyPressed;
            this.keyboardWatcher.Start();

            snake.Move();
        }

        public void NewKeyPressed(object sender, NewKeyPressedEventArgs args)
        {
            snake.ChangeDirection(args.Key);
        }
    }
}
