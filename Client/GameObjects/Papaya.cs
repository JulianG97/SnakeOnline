using System;

namespace Client
{
    public class Papaya : Fruit
    {
        public Papaya(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Points = 50;
            this.SnakeParts = 3;
            this.Symbol = 'O';
            this.Color = ConsoleColor.Magenta;
        }
    }
}
