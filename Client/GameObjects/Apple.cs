using System;

namespace Client
{
    public class Apple : Fruit
    {
        public Apple (int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Points = 10;
            this.SnakeParts = 1;
            this.Symbol = 'O';
            this.Color = ConsoleColor.Red;
        }
    }
}
