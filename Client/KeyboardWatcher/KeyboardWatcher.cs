using System;
using System.Threading;

namespace Client
{
    public class KeyboardWatcher
    {
        private Thread workThread;
        private KeyboardWatcherThreadArgs threadArgs;

        public event EventHandler<NewKeyPressedEventArgs> NewKeyPressed;

        public KeyboardWatcher()
        {
            this.threadArgs = new KeyboardWatcherThreadArgs(false, 100);
            this.workThread = new Thread(Worker);
        }

        public void Start()
        {
            if (this.threadArgs.IsRunning == true && this.workThread != null && this.workThread.IsAlive)
            {
                throw new InvalidOperationException("The keyboardwatcher is already running!");
            }
            else
            {
                this.threadArgs.IsRunning = true;

                this.workThread.Start(threadArgs);
            }
        }

        public void Stop()
        {
            if (this.threadArgs.IsRunning == false && this.workThread == null && !this.workThread.IsAlive)
            {
                throw new InvalidOperationException("The keyboardwatcher is already stopped!");
            }
            else
            {
                this.threadArgs.IsRunning = false;

                this.workThread.Join();
            }
        }

        public void Worker(object data)
        {
            KeyboardWatcherThreadArgs args = (KeyboardWatcherThreadArgs)data;

            while (this.threadArgs.IsRunning == true)
            {
                if (!Console.KeyAvailable)
                {
                    Thread.Sleep(args.Delay);
                    continue;
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                FireOnNewKeyPressed(key.Key);
            }
        }

        protected virtual void FireOnNewKeyPressed(ConsoleKey key)
        {
            if (this.NewKeyPressed != null)
            {
                this.NewKeyPressed(this, new NewKeyPressedEventArgs(key));
            }
        }
    }
}
