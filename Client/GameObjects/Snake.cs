﻿using System;
using System.Threading;

namespace Client
{
    public class Snake : GameObject
    {
        private MoveDirection currentDirection;
        private Thread moveThread;

        public event EventHandler<EventArgs> SnakeMoved;

        public Snake(ConsoleColor color, int positionX, int positionY, int speed, MoveDirection direction, char symbol)
        {
            this.Color = color;
            this.Symbol = symbol;
            this.Head = new SnakePart(positionX, positionY, color, this.Symbol);
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

        public int AddSnakeParts
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
                    if (this.currentDirection != MoveDirection.DOWN)
                    {
                        this.currentDirection = MoveDirection.UP;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (this.currentDirection != MoveDirection.UP)
                    {
                        this.currentDirection = MoveDirection.DOWN;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (this.currentDirection != MoveDirection.RIGHT)
                    {
                        this.currentDirection = MoveDirection.LEFT;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (this.currentDirection != MoveDirection.LEFT)
                    {
                        this.currentDirection = MoveDirection.RIGHT;
                    }
                    break;
            }
        }

        public void Move()
        {
            while (this.isMoving == true)
            {
                // Gets the position of the last snake part and overrides it with a space.
                SnakePart currentPart = GetLastPart();

                // If one or more snake parts will be added, the last element should not get removed.
                if (this.AddSnakeParts == 0)
                {
                    Console.SetCursorPosition(currentPart.PositionX, currentPart.PositionY);
                    Console.Write(" ");
                }

                currentPart = this.Head;

                SnakePart partToAdd = null;

                // If snake parts will be added, it finds the last part of the snake and store it as partToAdd
                if (this.AddSnakeParts > 0)
                {
                    while (currentPart != null)
                    {
                        if (currentPart.Next == null)
                        {
                            partToAdd = new SnakePart(currentPart.PositionX, currentPart.PositionY, this.Color, this.Symbol);

                            this.AddSnakeParts--;
                        }

                        currentPart = currentPart.Next;
                    }

                    currentPart = this.Head;
                }

                //Get last part
                while(currentPart.Next != null)
                {
                    currentPart = currentPart.Next;
                }

                // Sets the positions of each snake part to the positions of the previous snake part.
                // The position of the head of the snake gets changed later.
                while (currentPart != null)
                {
                    if (currentPart.Previous != null)
                    {
                        currentPart.PositionX = currentPart.Previous.PositionX;
                        currentPart.PositionY = currentPart.Previous.PositionY;
                    }

                    currentPart = currentPart.Previous;
                }

                if (partToAdd != null)
                {
                    currentPart = this.Head;

                    while(currentPart.Next != null)
                    {
                        currentPart = currentPart.Next;
                    }

                    currentPart.Next = partToAdd;
                    partToAdd.Previous = currentPart;
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

                this.FireOnSnakeMoved();

                Thread.Sleep(this.Speed);
            }
        }

        private SnakePart GetLastPart()
        {
            SnakePart currentPart = this.Head;

            while (currentPart.Next != null)
            {
                currentPart = currentPart.Next;
            }

            return currentPart;
        }

        public void DrawWholeSnake()
        {
            SnakePart currentPart = this.Head;

            while (currentPart != null)
            {
                Console.SetCursorPosition(currentPart.PositionX, currentPart.PositionY);
                Console.ForegroundColor = currentPart.Color;
                Console.Write(this.Symbol);
                Console.ResetColor();

                currentPart = currentPart.Next;
            }
        }

        protected virtual void FireOnSnakeMoved()
        {
            if (this.SnakeMoved != null)
            {
                this.SnakeMoved(this, new EventArgs());
            }
        }
    }
}