using System;

namespace Client
{
    public abstract class GameObject
    {
        public char Symbol
        {
            get;
            set;
        }

        public ConsoleColor Color
        {
            get;
            set;
        }

        public int PositionX
        {
            get;
            set;
        }

        public int PositionY
        {
            get;
            set;
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition(this.PositionX, this.PositionY);
            Console.ForegroundColor = this.Color;
            Console.Write(this.Symbol);
            Console.ResetColor();
        }
    }
}
