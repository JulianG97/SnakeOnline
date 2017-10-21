using System;
using System.Threading;

namespace Client
{
    public class Snake : GameObject
    {
        private MoveDirection currentDirection;
        private Thread moveThread;

        public Snake(ConsoleColor color, char symbol, int positionX, int positionY, int speed, MoveDirection direction)
        {
            this.Color = color;
            this.Symbol = symbol;
            this.Head = new SnakePart(positionX, positionY, color, symbol);
            this.currentDirection = direction;
            this.moveThread = new Thread(Move);
            this.Speed = speed;
        }

        public SnakePart Head
        {
            get;
            set;
        }

        public int Speed
        {
            get;
            set;
        }

        public bool isMoving
        {
            get;
            set;
        }

        public void ChangeDirection(ConsoleKey key)
        {
            // Change the current direction.
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    this.currentDirection = MoveDirection.UP;
                    break;
                case ConsoleKey.DownArrow:
                    this.currentDirection = MoveDirection.DOWN;
                    break;
                case ConsoleKey.LeftArrow:
                    this.currentDirection = MoveDirection.LEFT;
                    break;
                case ConsoleKey.RightArrow:
                    this.currentDirection = MoveDirection.RIGHT;
                    break;
            }
        }

        public void Move()
        {
            while (this.isMoving == true)
            {
                // Gets the position of the last snake part and overrides it with a space.
                SnakePart currentPart = this.Head;

                while (currentPart.Next != null)
                {
                    currentPart = currentPart.Next;
                }

                Console.SetCursorPosition(currentPart.PositionX, currentPart.PositionY);
                Console.Write(" ");

                // Sets the positions of each snake part to the positions of the previous snake part.
                // The position of the head of the snake gets changed later.
                currentPart = this.Head;

                while (currentPart != null)
                {
                    if (currentPart.Previous != null)
                    {
                        currentPart.PositionX = currentPart.Previous.PositionX;
                        currentPart.PositionY = currentPart.Previous.PositionY;
                    }

                    currentPart = currentPart.Next;
                }

                // Change the positions of the head dependent on the current direction.
                switch (this.currentDirection)
                {
                    case MoveDirection.UP:
                        this.Head.PositionY--;
                        break;
                    case MoveDirection.DOWN:
                        this.Head.PositionY++;
                        break;
                    case MoveDirection.LEFT:
                        this.Head.PositionX--;
                        break;
                    case MoveDirection.RIGHT:
                        this.Head.PositionX++;
                        break;
                }

                this.Head.Draw();

                Thread.Sleep(this.Speed);
            }
        }

        public void DrawWholeSnake()
        {
            SnakePart currentPart = this.Head;

            while (currentPart != null)
            {
                Console.SetCursorPosition(currentPart.PositionX, currentPart.PositionY);
                Console.ForegroundColor = currentPart.Color;
                Console.Write(currentPart.Symbol);
                Console.ResetColor();

                currentPart = currentPart.Next;
            }
        }
    }
}