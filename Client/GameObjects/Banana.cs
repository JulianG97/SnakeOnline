using System;

namespace Client
{
    public class Banana : Fruit
    {
        public Banana(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Points = 25;
            this.SnakeParts = 2;
            this.Symbol = 'O';
            this.Color = ConsoleColor.Yellow;
        }
    }
}
