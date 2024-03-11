using System;
using System.Threading;

namespace timer
{
    public delegate void TimerEvent();

    public class Timer
    {
        private TimerEvent methodToExecute;
        private int interval;
        private bool isRunning;

        public Timer(int intervalInSeconds, TimerEvent method)
        {
            interval = intervalInSeconds * 1000; // convert seconds to milliseconds
            methodToExecute = method;
            isRunning = false;
        }

        public void Start()
        {
            if (!isRunning)
            {
                isRunning = true;
                Thread thread = new Thread(RunTimer);
                thread.Start();
            }
        }

        private void RunTimer()
        {
            while (isRunning)   
            {
                Thread.Sleep(interval);
                methodToExecute();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage:
            Timer timer = new Timer(2, SomeMethod); // Fires SomeMethod every 2 seconds
            timer.Start();
            Timer timer1 = new Timer(4, SomeMethod1); // Fires SomeMethod every 4 seconds
            timer1.Start();

            // Keep the console application running
            Console.ReadLine();
        }

        static void SomeMethod()
        {
            Console.WriteLine("Executing SomeMethod...");
        }
        static void SomeMethod1()
        {
            Console.WriteLine("Executing SomeMethodааааа...");
        }
    }
}
