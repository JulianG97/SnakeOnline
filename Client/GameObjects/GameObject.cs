using System;

namespace Client
{
    public abstract class GameObject
    {
        private static object locker = new object();

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
            lock (locker)
            {
                if (this.PositionX >= 0 && this.PositionY >= 0)
                {
                    Console.SetCursorPosition(this.PositionX, this.PositionY);
                    Console.ForegroundColor = this.Color;
                    Console.Write(this.Symbol);
                    Console.ResetColor();
                }
            }
        }
    }
}
