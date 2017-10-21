using System;

namespace Client
{
    public class KeyboardWatcherThreadArgs
    {
        public KeyboardWatcherThreadArgs(bool isRunning, int delay)
        {
            this.IsRunning = isRunning;
            this.Delay = delay;
        }

        public bool IsRunning
        {
            get;
            set;
        }

        public int Delay
        {
            get;
            set;
        }
    }
}
