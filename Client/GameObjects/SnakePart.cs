using System;

namespace Client
{
    public class SnakePart : GameObject
    {
        public SnakePart(int positionX, int positionY, ConsoleColor color, char symbol)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Color = color;
            this.Symbol = symbol;
        }

        public SnakePart Next
        {
            get;
            set;
        }

        public SnakePart Previous
        {
            get;
            set;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(this.PositionX, this.PositionY);
            Console.ForegroundColor = this.Color;
            Console.Write(this.Symbol);
            Console.ResetColor();
        }
    }
}
