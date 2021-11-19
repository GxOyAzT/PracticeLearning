using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsolePractice.Parallelism
{
    public static class ForLoop
    {
        public static void TestA()
        {
            var stopWatchParallel = Stopwatch.StartNew();

            int[] nums = Enumerable.Range(0, 10000).ToArray();
            long total = 0;

            // Use type parameter to make subtotal a long, not an int
            Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
            {
                subtotal += nums[j];
                Thread.Sleep(2);
                return subtotal;
            },
                (x) => Interlocked.Add(ref total, x)
            );

            stopWatchParallel.Stop();

            Console.WriteLine($"Parallel: {stopWatchParallel.ElapsedMilliseconds}");

            Console.WriteLine("The total is {0:N0}", total);
            Console.WriteLine("Press any key to exit");

            long x = 0;

            var stopWatchSync = Stopwatch.StartNew();

            for (int i = 1; i < 10000; i++)
            {
                x += i;
                Thread.Sleep(2);
            }

            stopWatchSync.Stop();

            Console.WriteLine($"Sync: {stopWatchSync.ElapsedMilliseconds}");

            Console.WriteLine(x);
        }

        public static void WaitForOneSecond(string message)
        {
            Thread.Sleep(1000);
            Console.WriteLine(message);
        }
    }
}
