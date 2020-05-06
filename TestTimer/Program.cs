using System;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace TestTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Timer!");

            Timer timer = new Timer
            {
                Interval = 1000
            };
            timer.Elapsed += (sender, e) => { Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}"); Thread.Sleep(100); };

            timer.Start();

            Console.ReadLine();
        }
    }
}
