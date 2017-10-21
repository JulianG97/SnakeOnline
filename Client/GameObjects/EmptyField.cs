using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class EmptyField : GameObject
    {
        public EmptyField(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
            this.Color = Console.BackgroundColor;
            this.Symbol = ' ';
        }
    }
}
