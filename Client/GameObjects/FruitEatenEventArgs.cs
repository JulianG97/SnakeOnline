using System;

namespace Client
{
    public class FruitEatenEventArgs
    {
        public FruitEatenEventArgs(int points)
        {
            this.Points = points;
        }

        public int Points
        {
            get;
            set;
        }
    }
}