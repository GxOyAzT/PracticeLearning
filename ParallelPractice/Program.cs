using System;

namespace ParallelPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            DoParallelTask.DoTenTasks();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            DoParallelTask.DoTenTasksParallel();
            watch2.Stop();
            var elapsedMs2 = watch2.ElapsedMilliseconds;

            Console.WriteLine(elapsedMs);
            Console.WriteLine(elapsedMs2);
            Console.ReadKey();
        }
    }
}
