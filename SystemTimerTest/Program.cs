using System;
using System.Diagnostics;
using System.Timers;

namespace SystemTimerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("System Timer Test!");

            var sw = new Stopwatch();
            int counter = 0;
            Timer timer = new Timer
            {
                Interval = 1000
            };
            timer.Elapsed += (sender, e) => counter++;

            var startTime = DateTime.Now;
            timer.Start();
            sw.Start();
            Log(startTime, "starting...");

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
                
                var now = DateTime.Now;
                var elapsedTime = now - startTime;
                Log(now, $"Counter: {counter} Elapsed ms: {elapsedTime.TotalMilliseconds} Stop watch elapsed ms: {sw.ElapsedMilliseconds}");

            } while (key.Key != ConsoleKey.Enter);


            Log(DateTime.Now, "stopping");
            Console.ReadLine();
        }

        private static void Log(DateTime time, string message)
        {
            Console.WriteLine($"{time:HH:mm:ss.fff}\t{message}");
        }
    }
}
