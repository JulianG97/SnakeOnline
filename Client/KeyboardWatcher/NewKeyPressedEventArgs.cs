using System;

namespace Client
{
    public class NewKeyPressedEventArgs
    {
        public NewKeyPressedEventArgs(ConsoleKey key)
        {
            this.Key = key;
        }

        public ConsoleKey Key
        {
            get;
            set;
        }
    }
}
