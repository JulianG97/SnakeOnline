using System;

namespace Client
{
    public abstract class Fruit : GameObject
    {
        public int Points
        {
            get;
            set;
        }

        public int SnakeParts
        {
            get;
            set;
        }
    }
}
