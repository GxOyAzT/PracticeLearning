using System;
using System.Diagnostics;

namespace ConsolePractice
{
    public static class ExecutionMeasure
    {
        public static void Measure(Action task, string taskName, int repeats)
        {
            Console.WriteLine($"Start Measure {taskName}");
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < repeats; i++)
            {
                stopwatch.Start();
                task.Invoke();
                stopwatch.Stop();
            }

            Console.WriteLine($"Task {taskName} took {stopwatch.ElapsedMilliseconds / repeats} ms.");
        }
    }
}
