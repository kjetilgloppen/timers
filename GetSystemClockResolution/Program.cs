using System;
using System.Runtime.InteropServices;

namespace GetSystemClockResolution
{
    /// <summary>
    /// Based on code found here:
    /// https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer.interval?view=netcore-3.1
    /// 
    /// Updated a bit to show more information if timeAdjustmentDisabled is true from here:
    /// https://docs.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getsystemtimeadjustment
    /// </summary>
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetSystemTimeAdjustment(out long lpTimeAdjustment,
                                                   out long lpTimeIncrement,
                                                   out bool lpTimeAdjustmentDisabled);
        public static void Main()
        {
            if (GetSystemTimeAdjustment(out long timeAdjustment, out long timeIncrement, out bool timeAdjustmentDisabled))
            {
                if (!timeAdjustmentDisabled)
                    Console.WriteLine("System clock resolution: {0:N3} milliseconds",
                                      timeIncrement / 10000.0);
                else
                    Console.WriteLine($"The 'timeAdjustmentDisabled' value is true meaning that the time increment of {(timeIncrement / 10000.0):N4} ms is not in effect, " +
                        $"and that and the system time-of-day clock advances at the normal rate. " +
                        $"In this mode, the system may adjust the time of day using its own internal time synchronization mechanisms.");
            }
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
