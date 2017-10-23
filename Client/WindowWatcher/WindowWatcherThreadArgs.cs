using System;

namespace Client
{
    public class WindowWatcherThreadArgs
    {
        public WindowWatcherThreadArgs(bool isRunning)
        {
            this.IsRunning = isRunning;
        }

        public bool IsRunning
        {
            get;
            set;
        }
    }
}
