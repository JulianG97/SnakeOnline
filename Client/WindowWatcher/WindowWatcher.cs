using System;
using System.Threading;

namespace Client
{
    public class WindowWatcher
    {
        private int height;
        private int width;
        private bool cursorVisibleAfterResize;
        private Thread workThread;
        private WindowWatcherThreadArgs threadArgs;

        public WindowWatcher(int height, int width, bool cursorVisibleAfterResize)
        {
            this.height = height;
            this.width = width;
            this.cursorVisibleAfterResize = cursorVisibleAfterResize;
            this.workThread = new Thread(Worker);
            this.threadArgs = new WindowWatcherThreadArgs(false);
        }

        public void Start()
        {
            if (this.threadArgs.IsRunning == true && this.workThread.IsAlive && this.workThread != null)
            {
                throw new InvalidOperationException("The window watcher is already running!");
            }
            else
            {
                this.threadArgs.IsRunning = true;

                this.workThread.Start();
            }
        }

        public void Stop()
        {
            if (this.threadArgs.IsRunning == false && !this.workThread.IsAlive && this.workThread == null)
            {
                throw new InvalidOperationException("The window watcher has been already stopped!");
            }
            else
            {
                this.threadArgs.IsRunning = false;

                this.workThread.Join();
            }
        }

        private void Worker()
        {
            while (this.threadArgs.IsRunning == true)
            {
                if (Console.WindowHeight != this.height || Console.WindowWidth != this.width)
                {
                    if (this.cursorVisibleAfterResize == false)
                    {
                        Console.CursorVisible = false;
                    }

                    try
                    {
                        Console.SetWindowSize(this.width, this.height);
                    }
                    catch(Exception) {}
                }

                Thread.Sleep(10);
            }
        }
    }
}
