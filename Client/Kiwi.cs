using System;

namespace Client
{
    public class Kiwi : Fruit
    {
        public Kiwi(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Points = 50;
            this.SnakeParts = 0;
            this.Symbol = 'O';
            this.Color = ConsoleColor.Green;
        }
    }
}
