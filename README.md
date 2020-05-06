# Timers
Various small timer test programs

## GetSystemClockResolution
Will get the resolution of the Windows system clock, ususally 15.6 ms,
by using the GetSystemTimeAdjustment in kernel32.dll.

## SystemTimerTest
Will use a System.Timer to increment a counter every second. When user press a key,
it will print out the count and the time duration since start. Also, a StopWatch is used to 
compare the time difference.

## TestTimer
Will simply print out current time by using a SystemTimer with 1000 ms interval.
This will show that the milli second part of the time stamp will vary for each second.